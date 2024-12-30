
using System.Net;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WardGames.Web.Apple.AppStoreConnect;
using WardGames.Web.Apple.AppStoreConnect.AppStore.JWS;
namespace WardGames.Web.Apple.AppStoreConnect.AppStore.InAppPurchase.Transaction
{
    /// <summary>
    /// App Store Connect에서 특정 IAP의 가격 정보를 query 할 수 있는 Endpoint.
    /// https://developer.apple.com/documentation/appstoreconnectapi/read_price_information_for_an_in-app_purchase_price_schedule
    /// </summary>
    public sealed class GetTransactionInfoEndpoint : IAppStoreConnectAPIEndpoint
    {
        /// <summary>
        /// App Store Connect API Endpoint.
        /// </summary>
        public string Endpoint { get; private set; }

        /// <summary>
        /// App Store Connect API Endpoint Path Parameter.
        /// </summary>
        public string PathPram => "/transactions/{0}"; // transactionId

        /// <summary>
        /// Create GetTransactionInfoEndpoint.
        /// </summary>
        /// <param name="isSandBoxTest"></param>
        public GetTransactionInfoEndpoint(bool isSandBoxTest = false)
        {
            Endpoint = !isSandBoxTest ? AppStoreStorekitUrl.STORE_KIT_V1_URL : AppStoreStorekitUrl.STORE_KIT_SANDBOX_V1_URL;
        }

        /// <summary>
        /// Get information about a single transaction for your app.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="transactionId"></param>
        /// <param name="isSandBoxTest"></param>
        /// <returns></returns>
        public static async Task<TransactionInfoResponse> GetTransactionInfo(AppStoreConnectClient client, string transactionId, bool isSandBoxTest = false)
        {
            string url = AppStoreConnectAPIHelper.CreateAppStoreConnectAPIQueryEndpoint(
                endpoint: new GetTransactionInfoEndpoint(isSandBoxTest),
                pathArgs: new string[] { transactionId });
            string signedTransactionInfoJson = await AppStoreConnectAPIHelper.GetResultJsonFromTargetEndpoint(client, url);
            return new TransactionInfoResponse(signedTransactionInfoJson);
        }
    }
}