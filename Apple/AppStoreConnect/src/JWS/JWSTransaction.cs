
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WardGames.Web.Apple.AppStoreConnect.AppStore.JWS
{
    /// <summary>
    /// Transaction information signed by the App Store, in JSON Web Signature (JWS) format.
    /// https://developer.apple.com/documentation/appstoreserverapi/jwstransaction
    /// </summary>
    public class JWSTransaction
    {
        /// <summary>
        /// Contains transaction information signed by the App Store, in JSON Web Signature (JWS) format.
        /// </summary>
        /// <returns></returns>
        public JWSTransactionDecodedPayload? JWSDecodedPayload { get; set; }

        /// <summary>
        /// Create JWSTransaction.
        /// </summary>
        /// <param name="jwsTransaction"></param>
        public JWSTransaction(string jwsTransaction)
        {
            // JWS를 세 부분으로 분할합니다: 헤더, 페이로드, 서명
            const int JWS_PARTS_COUNT = 3;
            const int JWS_HEADER = 0;
            const int JWS_PAYLOAD = 1;
            const int JWS_SIGNATURE = 2;
            string[] parts = jwsTransaction.Split('.');
            if (parts.Length != JWS_PARTS_COUNT)
            {
                throw new Exception("Invalid JWS format.");
            }

            // 유효성 검증에 필요한 데이터를 준비합니다
            string decodedHeader = DecodeBase64Helper.DecodeBase64UrlToString(parts[JWS_HEADER]);
            JObject decodedHeaderData = JObject.Parse(decodedHeader);
            JArray? x5cArray = (JArray?)decodedHeaderData["x5c"];
            if (x5cArray == null || x5cArray.Count == 0)
            {
                throw new Exception("x5c field is missing or empty in JWS header.");
            }
            
            // 요청 유효성을 검사합니다.
            JwsVerifier jwsVerifier = new JwsVerifier(parts[JWS_HEADER], parts[JWS_PAYLOAD], parts[JWS_SIGNATURE], x5cArray[0].ToString());
            if (!jwsVerifier.IsVerified) // 요청 유효성 검증 시에는 첫 번째 인증서를 사용합니다.
            {
                throw new Exception("Failed to verify JWS.");
            }

            // Payload를 디코딩하여 저장합니다.
            string decodedPayloadJson = DecodeBase64Helper.DecodeBase64UrlToString(parts[JWS_PAYLOAD]);
            JWSDecodedPayload = JsonConvert.DeserializeObject<JWSTransactionDecodedPayload>(decodedPayloadJson);
        }
    }
}