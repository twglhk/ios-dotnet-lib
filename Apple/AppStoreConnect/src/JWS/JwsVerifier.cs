using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace WardGames.Web.Apple.AppStoreConnect.AppStore.JWS
{
    /// <summary>
    /// JWS 검증을 위한 클래스
    /// </summary>
    public class JwsVerifier
    {
        private readonly bool _isVerified;

        /// <summary>
        /// JWS 검증을 위한 클래스의 생성자
        /// </summary>
        public bool IsVerified => _isVerified;

        /// <summary>
        /// JWS 검증을 위한 클래스의 생성자
        /// </summary>
        /// <param name="header"></param>
        /// <param name="payload"></param>
        /// <param name="signature"></param>
        /// <param name="x5c"></param>
        public JwsVerifier(string header, string payload, string signature, string x5c)
        {
            // 첫 번째 X.509 인증서를 디코딩합니다.
            byte[] certBytes = DecodeBase64Helper.DecodeBase64UrlToBytes(x5c);
            var cert = new X509Certificate2(certBytes);
            
            // 해당 인증서의 공개키를 가져옵니다.
            ECDsa? publicKey = cert.GetECDsaPublicKey();
            if (publicKey == null)
            {
                Console.WriteLine("Failed to get public key from certificate.");
                _isVerified = false;
                return;
            }

            // 서명 검증을 수행합니다.
            var signedData = Encoding.UTF8.GetBytes(header + "." + payload);
            var signedSignature = DecodeBase64Helper.DecodeBase64UrlToBytes(signature);
            _isVerified = publicKey.VerifyData(signedData, signedSignature, HashAlgorithmName.SHA256);
            
            cert.Reset();
            publicKey.Clear();
        }
    }
}