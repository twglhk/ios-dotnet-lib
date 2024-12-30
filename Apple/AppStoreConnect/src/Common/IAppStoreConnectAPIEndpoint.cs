
namespace WardGames.Web.Apple.AppStoreConnect
{
    /// <summary>
    /// App Store Connect API Endpoint.
    /// </summary>
    public interface IAppStoreConnectAPIEndpoint
    {
        /// <summary>
        /// App Store Connect API Endpoint.
        /// </summary>
        public string Endpoint { get; }

        /// <summary>
        /// App Store Connect API Endpoint Path Parameter.
        /// </summary>
        public string PathPram { get; }
    }
}