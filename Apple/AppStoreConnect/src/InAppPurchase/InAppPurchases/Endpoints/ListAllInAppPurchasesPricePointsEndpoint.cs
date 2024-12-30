namespace WardGames.Web.Apple.AppStoreConnect.AppStore.InAppPurchase.InAppPurchases
{
    /// <summary>
    /// 특정 IAP의 PricePoints를 GET하는 Endpoint 클래스
    /// </summary>
    public class ListAllInAppPurchasesPricePointsEndpoint
    {
        private const AppStoreConnectAPIVersion _apiVersion = AppStoreConnectAPIVersion.v2;
        private const string _listAllPricePoints = "/inAppPurchases/{0}/pricePoints";
    }
}