using Newtonsoft.Json;
namespace WardGames.Web.Apple.AppStoreConnect.AppStore.InAppPurchase.InAppPurchasePriceSchedules
{
    /// <summary>
    /// App Store Connect에서 특정 IAP의 가격 정보를 query 할 수 있는 Endpoint.
    /// https://developer.apple.com/documentation/appstoreconnectapi/read_price_information_for_an_in-app_purchase_price_schedule
    /// </summary>
    public sealed class ReadPriceInformationEndPoint
    {
        private const AppStoreConnectAPIVersion _appStoreConnectAPIVersion = AppStoreConnectAPIVersion.v1;

        /// <summary>
        /// input : IAP Id
        /// </summary>
        /// <value></value>
        private const string _pathParam = "/inAppPurchasePriceSchedules/{0}/manualPrices";

        /// <summary>
        /// App Store에서 가격과 관련된 데이터 Get
        /// </summary>
        /// <param name="client"></param>
        /// <param name="iapId"> 애플에서 생성한 IAP 고유 Id </param>
        /// <param name="paramContainer"><see cref="ReadPriceInformationParamContainer"/> 내부 프로퍼티 참조. </param>
        /// <returns></returns>
        public static async Task<InAppPurchasePricesResponse> GetInAppPurchasePricesResponse(AppStoreConnectClient client, string iapId, ReadPriceInformationParamContainer paramContainer = null)
        {
            string resultJson = await AppStoreConnectAPIHelper.GetRequest(
                client: client,
                apiVersion: _appStoreConnectAPIVersion, 
                pathFormat: _pathParam, 
                pathArgs: new string[] {iapId}, 
                paramContainer: paramContainer);
            return JsonConvert.DeserializeObject<InAppPurchasePricesResponse>(resultJson);
        }
    }
}