using Newtonsoft.Json;
namespace WardGames.Web.Apple.AppStoreConnect.AppStore.InAppPurchase.InAppPurchaseLocalization
{
    /// <summary>
    /// 특정 IAP의 모든 지역 Localization 메타데이터를 요청했을 때 응답으로 들어오는 데이터 클래스
    /// https://developer.apple.com/documentation/appstoreconnectapi/inapppurchaselocalizationsresponse
    /// </summary>
    public class InAppPurchaseLocalizationsResponse : AppStoreConnectAPIResponse
    {
        /// <summary>
        /// 모든 지역의 <see cref="InAppPurchaseLocalization"/> 데이터 리스트
        /// </summary>
        /// <value></value>
        [JsonProperty("data")]
        public List<InAppPurchaseLocalization> Data { get; set; }
    }
}