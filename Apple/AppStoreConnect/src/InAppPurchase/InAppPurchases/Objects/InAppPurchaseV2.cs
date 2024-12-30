using Newtonsoft.Json;
namespace WardGames.Web.Apple.AppStoreConnect.AppStore.InAppPurchase.InAppPurchases
{
    /// <summary>
    /// https://developer.apple.com/documentation/appstoreconnectapi/inapppurchasev2
    /// </summary>
    public class InAppPurchaseV2 : IAppStoreConnectAPIObject
    {
        /// <summary>
        /// <see cref="InAppPurchaseV2Attributes"/> 속성 데이터. product name과 product ID가 있음.
        /// </summary>
        /// <value></value>
        [JsonProperty("attributes")]
        public InAppPurchaseV2Attributes Attributes { get; set; }

        /// <summary>
        /// IAP의 ID. App Store Connect에서 고유로 생성한 ID
        /// </summary>
        /// <value></value>
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}