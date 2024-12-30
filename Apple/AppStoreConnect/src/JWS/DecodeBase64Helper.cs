
using System.Text;

namespace WardGames.Web.Apple.AppStoreConnect.AppStore.JWS
{
    /// <summary>
    /// Base64 URL-safe 인코딩을 디코딩하는 Helper 클래스
    /// </summary>
    public class DecodeBase64Helper
    {
        /// <summary>
        /// Base64 URL-safe 인코딩을 디코딩하여 문자열로 반환합니다.
        /// </summary>
        /// <param name="input">Base64 URL-safe 인코딩된 문자열</param>
        /// <returns>Base64 URL-safe로 디코딩된 문자열</returns>
        public static string DecodeBase64UrlToString(string input)
        {
            var bytes = DecodeBase64UrlToBytes(input);
            return Encoding.UTF8.GetString(bytes);
        }

        /// <summary>
        /// Base64 URL-safe 인코딩을 디코딩하여 바이트 배열로 반환합니다.
        /// </summary>
        /// <param name="input">Base64 URL-safe 인코딩된 문자열</param>
        /// <returns>Base64 URL-safe로 디코딩된 바이트 배열</returns>
        public static byte[] DecodeBase64UrlToBytes(string input)
        {
            string output = input;
            output = output.Replace('-', '+').Replace('_', '/');
            switch (output.Length % 4)
            {
                case 0: break;
                case 2: output += "=="; break;
                case 3: output += "="; break;
                default: throw new Exception("Illegal base64url string!");
            }
            return Convert.FromBase64String(output);
        }
    }
}