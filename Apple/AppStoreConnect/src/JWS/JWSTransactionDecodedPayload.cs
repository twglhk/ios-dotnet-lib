
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace WardGames.Web.Apple.AppStoreConnect.AppStore.JWS
{
    /// <summary>
    /// A decoded payload that contains transaction information. <br/>
    /// https://developer.apple.com/documentation/appstoreserverapi/jwstransactiondecodedpayload
    /// </summary>
    public class JWSTransactionDecodedPayload
    {
        /// <summary>
        /// The unique identifier of the transaction.
        /// </summary>
        [JsonProperty("transactionId")]
        public string? TransactionId { get; set; }

        /// <summary>
        /// The unique identifier of the product.
        /// </summary>
        [JsonProperty("productId")]
        public string? ProductId { get; set; }

        /// <summary>
        /// The time of the original app purchase.
        /// </summary>
        [JsonProperty("environment")]
        public string? Environment { get; set; }
    }
}