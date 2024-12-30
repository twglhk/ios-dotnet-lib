using Newtonsoft.Json;
namespace WardGames.Web.Apple.AppStoreConnect.AppStore.InAppPurchase.InAppPurchases
{
    /// <summary>
    /// https://developer.apple.com/documentation/appstoreconnectapi/inapppurchasesv2response
    /// </summary>
    public class InAppPurchasesV2Response
    {
        /// <summary>
        /// <see cref="InAppPurchaseV2"/> 데이터의 리스트 
        /// </summary>
        [JsonProperty("data")]
        public List<InAppPurchaseV2> InAppPurchaseV2List { get; set; }
    }
}