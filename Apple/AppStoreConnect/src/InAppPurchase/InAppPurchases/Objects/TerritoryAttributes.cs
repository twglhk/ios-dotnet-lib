using Newtonsoft.Json;
namespace WardGames.Web.Apple.AppStoreConnect.AppStore.Territories
{
    /// <summary>
    /// https://developer.apple.com/documentation/appstoreconnectapi/territory/attributes
    /// </summary>
    public class TerritoryAttributes
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }
    }
}