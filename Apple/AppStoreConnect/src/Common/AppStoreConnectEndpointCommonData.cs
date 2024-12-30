
namespace WardGames.Web.Apple.AppStoreConnect
{
    internal static class AppStoreConnectEndpointCommonData
    {
        public static Dictionary<AppStoreConnectAPIVersion, string> AppleConnectStoreAPIUrl = new Dictionary<AppStoreConnectAPIVersion, string>(2)
        {
            { AppStoreConnectAPIVersion.v1, "https://api.appstoreconnect.apple.com/v1" },
            { AppStoreConnectAPIVersion.v2, "https://api.appstoreconnect.apple.com/v2" },
        };

        public const string Include = "include";
        public const string Included = "included";
        public const string Limit = "limit";
    }
}