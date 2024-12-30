using Newtonsoft.Json;
namespace WardGames.Web.Apple.AppStoreConnect.AppStore.InAppPurchase.InAppPurchases
{
    /// <summary>
    /// https://developer.apple.com/documentation/appstoreconnectapi/list_all_in-app_purchases_for_an_app
    /// 모든 인앱 상품의 정보를 불러옴.
    /// </summary>
    public class ListAllInAppPurchasesEndPoint
    {
        private const AppStoreConnectAPIVersion _appStoreConnectAPIVersion = AppStoreConnectAPIVersion.v1;
        /// <summary>
        /// input : App Id
        /// </summary>
        /// <value></value>
        private const string _pathParam = "/apps/{0}/inAppPurchasesV2";
        
        /// <summary>
        /// App에 존재하는 모든 인앱구매 상품 데이터를 쿼리하고, <see cref="InAppPurchasesV2Response"/> 반환
        /// </summary>
        /// <param name="client"></param>
        /// <param name="queryParamsContainer"></param>
        /// <returns></returns>
        public static async Task<InAppPurchasesV2Response> GetListAllInAppPurchases(AppStoreConnectClient client, ListAllInAppPurchasesParamContainer queryParamsContainer = null)
        {
            string resultJson = await AppStoreConnectAPIHelper.GetRequest(
                client: client,
                apiVersion: _appStoreConnectAPIVersion, 
                pathFormat: _pathParam, 
                pathArgs: new string[] {client.AppId}, 
                paramContainer: queryParamsContainer);
            return JsonConvert.DeserializeObject<InAppPurchasesV2Response>(resultJson);
        }
    }
}