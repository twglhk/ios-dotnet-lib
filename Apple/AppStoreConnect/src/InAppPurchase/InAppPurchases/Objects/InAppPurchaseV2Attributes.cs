using Newtonsoft.Json;
namespace WardGames.Web.Apple.AppStoreConnect.AppStore.InAppPurchase.InAppPurchases
{
    /// <summary>
    /// https://developer.apple.com/documentation/appstoreconnectapi/inapppurchasev2/attributes
    /// </summary>
    public class InAppPurchaseV2Attributes
    {
        /// <summary>
        /// IAP의 이름
        /// </summary>
        /// <value></value>
        [JsonProperty("name")]
        public string Name { get; set; }
        
        /// <summary>
        /// IAP에 아이템을 생성한 서비스 사용자가 임의로 지정한 ID. 
        /// </summary>
        /// <value></value>
        [JsonProperty("productId")]
        public string ProductId { get; set; }   
    }
}