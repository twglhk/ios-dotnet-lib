using Newtonsoft.Json;
namespace WardGames.Web.Apple.AppStoreConnect.AppStore.InAppPurchase.InAppPurchases
{
    /// <summary>
    /// https://developer.apple.com/documentation/appstoreconnectapi/inapppurchasepricepoint/attributes
    /// </summary>
    public class InAppPurchasePricePointAttributes
    {
        /// <summary>
        /// IAP 소비자 가격
        /// </summary>
        /// <value></value>
        [JsonProperty("customerPrice")]
        public string CustomerPrice { get; set; }
    }
}
