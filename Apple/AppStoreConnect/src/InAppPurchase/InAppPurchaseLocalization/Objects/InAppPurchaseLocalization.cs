using Newtonsoft.Json;
namespace WardGames.Web.Apple.AppStoreConnect.AppStore.InAppPurchase.InAppPurchaseLocalization
{
    /// <summary>
    /// IAP의 지역별 메타데이터 클래스
    /// InAppPurchaseLocalization을 Query param에서 Include할 시, 이 클래스로 Deserialize됨.
    /// https://developer.apple.com/documentation/appstoreconnectapi/inapppurchaselocalization
    /// </summary>
    public class InAppPurchaseLocalization : IAppStoreConnectAPIObject
    {
        /// <summary>
        /// IAP 속성 데이터
        /// </summary>
        /// <value></value>
        [JsonProperty("attributes")]
        public InAppPurchaseLocalizationAttributes Attributes { get; set; }
    }
}