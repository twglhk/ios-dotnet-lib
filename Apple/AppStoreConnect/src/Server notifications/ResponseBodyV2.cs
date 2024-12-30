
namespace WardGames.Web.Apple.AppStoreConnect.AppStore.ServerNotifications
{
    /// <summary>
    /// The response body the App Store sends in a version 2 server notification. <br/>
    /// https://developer.apple.com/documentation/appstoreservernotifications/responsebodyv2
    /// </summary>
    public class ResponseBodyV2
    {
        /// <summary>
        /// The payload in JSON Web Signature (JWS) format, signed by the App Store.
        /// </summary>
        /// <value></value>
        public string signedPayload { get; private set; }
    }
}