
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;

namespace WardGames.Web.Apple.AppStoreConnect
{
    /// <summary>
    /// AppStoreConnect API를 사용하기 위한 클라이언트 클래스
    /// </summary>
    public class AppStoreConnectClient
    {
        private static AppStoreConnectClient? _instance;

        /// <summary>
        /// App Id
        /// </summary>
        public readonly string AppId;

        /// <summary>
        /// Issuer Id
        /// </summary>
        public readonly string IssuerId;

        /// <summary>
        /// Bundle Id
        /// </summary>
        public readonly string BundleId;

        /// <summary>
        /// Private Key Id
        /// </summary>
        public readonly string PrivateKeyId;

        /// <summary>
        /// PEM key
        /// </summary>
        private readonly ECDsa? _key;

        /// <summary>
        /// JWT 토큰의 Audience
        /// </summary>
        private static readonly string AUDIENCE = "appstoreconnect-v1";


        // HTTP 요청을 보내기 위한 HttpClient 인스턴스
        private readonly HttpClient _httpClient;

        /// <summary>
        /// AppStoreConnectClient 클래스의 생성자
        /// 각 인자들은 AppStoreConnect API를 사용하기 위한 인증 정보
        /// </summary>
        /// <param name="httpClient"></param> 
        /// <param name="appId"></param>
        /// <param name="issuerId"></param>
        /// <param name="bundleId"></param>
        /// <param name="privateKeyId"></param>
        /// <param name="key"></param>
        private AppStoreConnectClient(HttpClient httpClient, string appId, string issuerId, string bundleId, string privateKeyId, string key)
        {
            _httpClient = httpClient;
            AppId = appId;
            IssuerId = issuerId;
            BundleId = bundleId;
            PrivateKeyId = privateKeyId;
            _key = LoadPrivateKeyFromPem(key);
        }

        /// <summary>
        /// AppStoreConnectClient 클래스의 인스턴스를 가져오는 메서드
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="appId"></param>
        /// <param name="issuerId"></param>
        /// <param name="bundleId"></param>
        /// <param name="privateKeyId"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static AppStoreConnectClient GetInstance(HttpClient httpClient, string appId, string issuerId, string bundleId, string privateKeyId, string key)
        {
            if (_instance == null)
            {
                _instance = new AppStoreConnectClient(httpClient, appId, issuerId, bundleId, privateKeyId, key);
            }
            return _instance;
        }

        private string CreateToken()
        {
            var now = DateTime.UtcNow;
            var unixTimeSeconds = new DateTimeOffset(now).ToUnixTimeSeconds();

            // JWT Header 만들기
            JwtHeader header = new JwtHeader(new SigningCredentials(new ECDsaSecurityKey(_key), SecurityAlgorithms.EcdsaSha256))
            {
                { "kid", PrivateKeyId },
            };

            // JWT Payload 만들기
            JwtPayload payload = new JwtPayload
            {
                { "iss", IssuerId },
                { "iat", unixTimeSeconds },
                { "exp", unixTimeSeconds + (20*60) },
                { "bid", BundleId },
                { "aud", AUDIENCE },
            };

            var jwt = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        private ECDsa LoadPrivateKeyFromPem(string privateKeyPem)
        {
            var lines = privateKeyPem.Split('\n');
            var trimmedLines = lines[1..^1]; // Exclude the first and last line
            var base64Key = string.Concat(trimmedLines);

            byte[] privateKeyDer = Convert.FromBase64String(base64Key);
            ECDsa privateKey = ECDsa.Create();
            privateKey.ImportPkcs8PrivateKey(privateKeyDer, out _);
            return privateKey;
        }

        /// <summary>
        /// HTTP 요청을 보내는 메서드. 내부적으로 필요한 JWT 토큰을 생성하여 요청에 포함합니다.
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="httpMethod"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> SendHttpRequest(HttpMethod httpMethod, string uri)
        {
            using (HttpRequestMessage request = new HttpRequestMessage(method: httpMethod, requestUri: uri))
            {
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", CreateToken());
                return await _httpClient.SendAsync(request);
            }
        }
    }
}