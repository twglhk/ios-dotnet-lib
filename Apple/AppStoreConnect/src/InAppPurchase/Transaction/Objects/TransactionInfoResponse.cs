
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WardGames.Web.Apple.AppStoreConnect.AppStore.JWS;

namespace WardGames.Web.Apple.AppStoreConnect.AppStore.InAppPurchase.Transaction
{
    /// <summary>
    /// A response that contains signed transaction information for a single transaction.
    /// </summary>
    public class TransactionInfoResponse
    {
        /// <summary>
        /// A customer’s in-app purchase transaction, signed by Apple, in JSON Web Signature (JWS) format.
        /// </summary>
        [JsonIgnore] 
        public JWSTransaction SignedTransactionInfo { get; set; }

        /// <summary>
        /// Create TransactionInfoResponse.
        /// </summary>
        /// <param name="signedTransactionInfo"></param>
        [JsonConstructor]
        public TransactionInfoResponse(string signedTransactionInfo)
        {
            JObject signedTransactionInfoJObject = JObject.Parse(signedTransactionInfo);
            string? encodedJWSTransaction = signedTransactionInfoJObject["signedTransactionInfo"]?.ToString();
            if (encodedJWSTransaction == null)
            {
                throw new Exception("Failed to get signedTransactionInfo from App Store Connect API.");
            }

            SignedTransactionInfo = new JWSTransaction(encodedJWSTransaction);
        }
    }
}