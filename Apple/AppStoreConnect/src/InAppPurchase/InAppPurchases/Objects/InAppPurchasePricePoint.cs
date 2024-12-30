using Newtonsoft.Json;
namespace WardGames.Web.Apple.AppStoreConnect.AppStore.InAppPurchase.InAppPurchases
{
    /// <summary>
    /// https://developer.apple.com/documentation/appstoreconnectapi/inapppurchasepricepoint
    /// </summary>
    public class InAppPurchasePricePoint : IAppStoreConnectAPIObject
    {
        /// <summary>
        /// IAP의 가격 속성
        /// </summary>
        /// <value></value>
        [JsonProperty("attributes")]
        public InAppPurchasePricePointAttributes Attributes { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

}