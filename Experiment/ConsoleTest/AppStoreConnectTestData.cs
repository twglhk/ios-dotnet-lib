
public class AppStoreConnectTestData
{
    public static string KeyId = "XZJ5762P5R";
    public static string IssuerId = "f39f62c5-8b9b-40bf-bc6b-cd8592bdfae4";
    public static string Key = @"-----BEGIN PRIVATE KEY-----
MIGTAgEAMBMGByqGSM49AgEGCCqGSM49AwEHBHkwdwIBAQQgRkspzc2U4MvQyBoT
Gx0Z1TmtLfijdeUso6XGjpNuKf2gCgYIKoZIzj0DAQehRANCAARTURCYyGxp2vLL
kmaCdd5X+BpFAkYmCWKqR0bIsaxDSH3kzZslkyp5/iOEgGNK6GHznHwb/bhiz697
rUYorwhE
-----END PRIVATE KEY-----";
    // public static string Url = "https://api.appstoreconnect.apple.com/v1/apps/6448715516/inAppPurchasesV2?fields[inAppPurchaseLocalizations]=inAppPurchaseV2,name,description&include=inAppPurchaseLocalizations";
    // public static string Url = "https://api.appstoreconnect.apple.com/v2/inAppPurchases/6450658665/inAppPurchaseLocalizations?fields[inAppPurchaseLocalizations]=name,description";
    // public static string Url = "https://api.appstoreconnect.apple.com/v1/inAppPurchasePriceSchedules/6450658665/manualPrices?include=inAppPurchasePricePoint,territory";
    public static string Url = "https://api.appstoreconnect.apple.com/v1/inAppPurchasePriceSchedules/6456380813/manualPrices?include=inAppPurchasePricePoint";

    // URL for the in-app purchase details endpoint
    public static string AppId = "6448715516";

    public static string BundleId = "com.wardgames.zooportsbeta";

    public static string GetItemUrl(string itemId)
    {
        string itemUrl = $"https://api.appstoreconnect.apple.com/v2/inAppPurchases/{itemId}";
        Console.WriteLine($"GetItemUrl : {itemUrl}");
        return itemUrl;
    }

    public static string GetItemPrice(string productId)
    {
        string itemPriceUrl = $"https://api.appstoreconnect.apple.com/v2/inAppPurchases/{productId}/iapPriceSchedule?fields[inAppPurchasePrices]=manual";
  
        Console.WriteLine($"GetItemPrice : {itemPriceUrl}");
        return itemPriceUrl;
    }

    public static string GetFilteredItemPricePointEndpoint(string itemId)
    {
        return $"https://api.appstoreconnect.apple.com//v2/inAppPurchases/{itemId}/pricePoints?filter[territory]=USA&include=territory&limit=5";
    }
}