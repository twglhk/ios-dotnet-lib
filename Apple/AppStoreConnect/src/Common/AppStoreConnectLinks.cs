using Newtonsoft.Json;
namespace WardGames.Web.Apple.AppStoreConnect
{
    /// <summary>
    /// App Store Connect API의 Object 일부에 포함되어 있는 특정 endpoint의 url 값을 표현하는 클래스
    /// </summary>
    public class AppStoreConnectLinks
    {
        /// <summary>
        /// 타깃 endpont 주소
        /// (warning) 해당 값은 App Store Connect API의 links 값 중, related 값임.
        /// </summary>
        /// <value></value>
        [JsonProperty("related")]
        public string Url { get; set; }
    }
}