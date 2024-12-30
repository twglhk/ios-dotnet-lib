using Newtonsoft.Json;
namespace WardGames.Web.Apple.AppStoreConnect.AppStore.InAppPurchase.InAppPurchaseLocalization
{
    /// <summary>
    /// 특정 IAP와 연결된 모든 지역의 Localization 메타 데이터를 얻어올 수 있는 App Store Connect API endpoint.
    /// </summary>
    public class ListAllLocalizationsEndpoint
    {
        private const AppStoreConnectAPIVersion _appStoreConnectAPIVersion = AppStoreConnectAPIVersion.v2;

        /// <summary>
        /// input : IAP v2 ID
        /// </summary>
        /// <value></value>
        private const string _pathParam = "/inAppPurchases/{0}/inAppPurchaseLocalizations";

        /// <summary>
        /// App Store Connect로부터 타겟 IAP와 연관된 모든 지역의 Localization 메타 데이터를 얻어옵니다.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="iapId"></param>
        /// <returns></returns>
        public static async Task<InAppPurchaseLocalizationsResponse> GetListAllLocalizations(AppStoreConnectClient client, string iapId)
        {
            string resultJson = await AppStoreConnectAPIHelper.GetRequest(
                client: client,
                apiVersion: _appStoreConnectAPIVersion, 
                pathFormat: _pathParam, 
                pathArgs: new string[] {iapId});
            return JsonConvert.DeserializeObject<InAppPurchaseLocalizationsResponse>(resultJson);
        }
    }
}