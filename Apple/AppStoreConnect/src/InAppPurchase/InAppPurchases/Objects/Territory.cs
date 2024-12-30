using Newtonsoft.Json;
namespace WardGames.Web.Apple.AppStoreConnect.AppStore.Territories
{
    /// <summary>
    /// https://developer.apple.com/documentation/appstoreconnectapi/territory
    /// </summary>
    public class Territory
    {
        [JsonProperty("attributes")]
        public TerritoryAttributes Attributes { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}