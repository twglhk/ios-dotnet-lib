using Newtonsoft.Json;
namespace WardGames.Web.Apple.AppStoreConnect.AppStore.InAppPurchase.InAppPurchaseLocalization
{
    /// <summary>
    /// IAP의 지역별 상품 메타데이터의 속성값을 담고 있는 클래스
    /// https://developer.apple.com/documentation/appstoreconnectapi/inapppurchaselocalization/attributes
    /// </summary>
    public class InAppPurchaseLocalizationAttributes : IAppStoreConnectAPIObject
    {
        /// <summary>
        /// 지역 식별자
        /// </summary>
        /// <value></value>
        [JsonProperty("locale")]
        public string Locale { get; set; }

        /// <summary>
        /// 지역별 상품 이름
        /// </summary>
        /// <value></value>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 지역별 상품 상세 설명
        /// </summary>
        /// <value></value>
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}