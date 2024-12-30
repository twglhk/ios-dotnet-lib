using Newtonsoft.Json;
namespace WardGames.Web.Apple.AppStoreConnect
{
    public class InAppPurchaseV2Relationships
    {
        [JsonProperty("inAppPurchaseLocalizations")]
        public AppStoreConnectLinks InAppPurchaseLocalizations { get; set; }
    }
}