
namespace WardGames.Web.Apple.AppStoreConnect.AppStore.ServerNotifications
{
    /// <summary>
    /// The app metadata and the signed renewal and transaction information.
    /// </summary>
    public class ResponseBodyV2DecodedPayloadData
    {
        /// <summary>
        /// The server environment that the notification applies to, either sandbox or production.
        /// </summary>
        public string environment { get; private set; }

        public string JWSTransaction { get; private set; }
    }
}