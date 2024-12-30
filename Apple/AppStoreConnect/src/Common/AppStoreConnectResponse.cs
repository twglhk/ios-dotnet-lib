using Newtonsoft.Json;
namespace WardGames.Web.Apple.AppStoreConnect
{
    /// <summary>
    /// 모든 App Store Connect API response에 공통적으로 포함될 수 있는 데이터를 담은 base 클래스
    /// </summary>
    public abstract class AppStoreConnectAPIResponse
    {
        /// <summary>
        /// GET API 호출시 include 파라미터에 들어간 API Object의 리스트
        /// </summary>
        /// <value></value>
        [JsonProperty(AppStoreConnectEndpointCommonData.Included)]
        [JsonConverter(typeof(AppStoreConnectAPIObjectConverter))]
        public List<IAppStoreConnectAPIObject> Included { get; set; }
    }
}