// See https://aka.ms/new-console-template for more information

#define URL_DEBUG
#undef URL_DEBUG

using System.Security.Cryptography;
using System.Text;
using WardGames.Web.Apple.AppStoreConnect;
using WardGames.Web.Apple.AppStoreConnect.AppStore.InAppPurchase.InAppPurchases;
using WardGames.Web.Apple.AppStoreConnect.AppStore.InAppPurchase.InAppPurchasePriceSchedules;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WardGames.Web.Apple.AppStoreConnect.AppStore.InAppPurchase.Transaction;
using WardGames.Web.Apple.AppStoreConnect.AppStore.JWS;

public class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            AppStoreConnectClient appStoreConnectClient = new AppStoreConnectClient(AppStoreConnectTestData.AppId,  AppStoreConnectTestData.IssuerId, AppStoreConnectTestData.BundleId, AppStoreConnectTestData.KeyId, AppStoreConnectTestData.Key);

            string receipt = "ewoJInNpZ25hdHVyZSIgPSAiQkJ4ZVpvRDVpS3NrUC93K1FvNHU4RFcxZ2x6TFVWR2VmZlNFOGEvSWdBOXJ4WTVXaGJTZXR1cGsrQjQ3RlJHWlQxUEcrR3VsWjcxS3JYandZMGliZ0JaMk0rb3dJVTE4Z2d2YmVZMWNQWnExbW1vY1N1bHNyRHhXN3hIWHQ0MU81dVF3a2tUWkVtdzY4YUFHZlpyQWdHL0txOHN0RVBFU1R2dlUxU3pWK3B4OG55WkdSLytxK3NDVzZKUlUzR3ZaQVRyNHdEU0xLa1pYUmNtOWtzU3BMVEJ4NjlpQlRPTC83c1o4Y2pUaUM2cmZKUVo0ZG93eTlrd2Y1blpKeWw3RWpIWGZnUjd2SStLZHI4UmFrS3hUbzNsMHUxRUs1WDQrZkRyTUdFZjMweG10Ty9QRVAwTmRKZm1RekcrMisraWtYWUgvZ1g5azFkZTNEQnVCTWZ6UnVHY0FBQVhLTUlJRnhqQ0NCSzZnQXdJQkFnSVFGZWVmemxKVkNtVUJmSkhmNU82eldUQU5CZ2txaGtpRzl3MEJBUXNGQURCMU1VUXdRZ1lEVlFRREREdEJjSEJzWlNCWGIzSnNaSGRwWkdVZ1JHVjJaV3h2Y0dWeUlGSmxiR0YwYVc5dWN5QkRaWEowYVdacFkyRjBhVzl1SUVGMWRHaHZjbWwwZVRFTE1Ba0dBMVVFQ3d3Q1J6VXhFekFSQmdOVkJBb01Da0Z3Y0d4bElFbHVZeTR4Q3pBSkJnTlZCQVlUQWxWVE1CNFhEVEl5TURrd01qRTVNVE0xTjFvWERUSTBNVEF3TVRFNU1UTTFObG93Z1lreE56QTFCZ05WQkFNTUxrMWhZeUJCY0hBZ1UzUnZjbVVnWVc1a0lHbFVkVzVsY3lCVGRHOXlaU0JTWldObGFYQjBJRk5wWjI1cGJtY3hMREFxQmdOVkJBc01JMEZ3Y0d4bElGZHZjbXhrZDJsa1pTQkVaWFpsYkc5d1pYSWdVbVZzWVhScGIyNXpNUk13RVFZRFZRUUtEQXBCY0hCc1pTQkpibU11TVFzd0NRWURWUVFHRXdKVlV6Q0NBU0l3RFFZSktvWklodmNOQVFFQkJRQURnZ0VQQURDQ0FRb0NnZ0VCQUx4RXpndXRhakIycjhBSkREUjZHV0h2dlNBTjlmcERuaFAxclBNOGt3N1haWnQwd2xvM0oxVHdqczFHT29MTWRiOFM0QXNwN2xocm9PZENLdmVIQUoraXpLa2k1bTNvRGVmTEQvVFFaRnV6djQxanpjS2JZckFwMTk3QW80MnRHNlQ0NjJqYmM0WXVYOHk3SVgxcnVEaHVxKzhpZzBnVDlrU2lwRWFjNVdMc2REdC9ONVNpZG1xSUlYc0VmS0hUczU3aU5XMm5qbyt3NDJYV3lETWZUbzZLQSt6cHZjd2Z0YWVHamdUd2tPKzZJWTV0a21KeXdZblFtUDdqVmNsV3hqUjAvdlFlbWtOd1lYMStoc0o1M1ZCMTNRaXc1S2kxZWpaOWwvejVTU0FkNXhKaXFHWGFQQlpZL2laUmo1RjVxejFidS9rdTB6dFNCeGd3NTM4UG1POENBd0VBQWFPQ0Fqc3dnZ0kzTUF3R0ExVWRFd0VCL3dRQ01BQXdId1lEVlIwakJCZ3dGb0FVR1l1WGpVcGJZWGhYOUtWY05SS0tPUWpqc0hVd2NBWUlLd1lCQlFVSEFRRUVaREJpTUMwR0NDc0dBUVVGQnpBQ2hpRm9kSFJ3T2k4dlkyVnlkSE11WVhCd2JHVXVZMjl0TDNkM1pISm5OUzVrWlhJd01RWUlLd1lCQlFVSE1BR0dKV2gwZEhBNkx5OXZZM053TG1Gd2NHeGxMbU52YlM5dlkzTndNRE10ZDNka2NtYzFNRFV3Z2dFZkJnTlZIU0FFZ2dFV01JSUJFakNDQVE0R0NpcUdTSWIzWTJRRkJnRXdnZjh3TndZSUt3WUJCUVVIQWdFV0syaDBkSEJ6T2k4dmQzZDNMbUZ3Y0d4bExtTnZiUzlqWlhKMGFXWnBZMkYwWldGMWRHaHZjbWwwZVM4d2djTUdDQ3NHQVFVRkJ3SUNNSUcyRElHelVtVnNhV0Z1WTJVZ2IyNGdkR2hwY3lCalpYSjBhV1pwWTJGMFpTQmllU0JoYm5rZ2NHRnlkSGtnWVhOemRXMWxjeUJoWTJObGNIUmhibU5sSUc5bUlIUm9aU0IwYUdWdUlHRndjR3hwWTJGaWJHVWdjM1JoYm1SaGNtUWdkR1Z5YlhNZ1lXNWtJR052Ym1ScGRHbHZibk1nYjJZZ2RYTmxMQ0JqWlhKMGFXWnBZMkYwWlNCd2IyeHBZM2tnWVc1a0lHTmxjblJwWm1sallYUnBiMjRnY0hKaFkzUnBZMlVnYzNSaGRHVnRaVzUwY3k0d01BWURWUjBmQkNrd0p6QWxvQ09nSVlZZmFIUjBjRG92TDJOeWJDNWhjSEJzWlM1amIyMHZkM2RrY21jMUxtTnliREFkQmdOVkhRNEVGZ1FVSXNrOGUyTVRoYjQ2TzhVenFiVDZzYkNDa3hjd0RnWURWUjBQQVFIL0JBUURBZ2VBTUJBR0NpcUdTSWIzWTJRR0N3RUVBZ1VBTUEwR0NTcUdTSWIzRFFFQkN3VUFBNElCQVFBOFJ1N1BxRHk0L1o2RHkxSHc5cWhSL09JSEhZSWszTzZTaWh2cVRhanFPMCtITXBvNU9kdGIrRnZhVFkzTit3bEtDN0hObWhsdlRzZjlhRnM3M1BsWGo1TWtTb1IwamFBa1ozYzVnamtOank5OGdZRVA3ZXRiK0hXMC9QUGVsSkc5VElVY2ZkR09aMlJJZ2dZS3NHRWt4UEJRSzFaYXJzMXV3SGVBWWM4SThxQlI1WFA1QVpFVFp6TC9NM0V6T3pCUFN6QUZmQzJ6T1d2ZkpsMnZmTGwyQnJtdUN4OWxVRlVCemFHelR6bHhCREhHU0hVVkpqOUszeXJrZ3NxT0dHWHBZTENPaHVMV1N0UnptU1N0VGhWT2JVVklhOFlEdTNjMFJwMUgxNlJvOXc5MFFFSTNlSVFvdmdJckNnNk0zbFpKbWxETkFuazdqTkE2cUsrWkhNcUIiOwoJInB1cmNoYXNlLWluZm8iID0gImV3b0pJbTl5YVdkcGJtRnNMWEIxY21Ob1lYTmxMV1JoZEdVdGNITjBJaUE5SUNJeU1ESXpMVEV4TFRJeUlESXhPalEzT2pNM0lFRnRaWEpwWTJFdlRHOXpYMEZ1WjJWc1pYTWlPd29KSW5CMWNtTm9ZWE5sTFdSaGRHVXRiWE1pSUQwZ0lqRTNNREEzTVRnME5UYzFNaklpT3dvSkluVnVhWEYxWlMxcFpHVnVkR2xtYVdWeUlpQTlJQ0l3TURBd09ERXdNUzB3TURFd05UazFOakpGT1VJd01ERkZJanNLQ1NKdmNtbG5hVzVoYkMxMGNtRnVjMkZqZEdsdmJpMXBaQ0lnUFNBaU1qQXdNREF3TURRMk5EUXdNREEyTXlJN0Nna2lZblp5Y3lJZ1BTQWlNQ0k3Q2draVlYQndMV2wwWlcwdGFXUWlJRDBnSWpZME5EZzNNVFUxTVRZaU93b0pJblJ5WVc1ellXTjBhVzl1TFdsa0lpQTlJQ0l5TURBd01EQXdORFkwTkRBd01EWXpJanNLQ1NKeGRXRnVkR2wwZVNJZ1BTQWlNU0k3Q2draWFXNHRZWEJ3TFc5M2JtVnljMmhwY0MxMGVYQmxJaUE5SUNKUVZWSkRTRUZUUlVRaU93b0pJbTl5YVdkcGJtRnNMWEIxY21Ob1lYTmxMV1JoZEdVdGJYTWlJRDBnSWpFM01EQTNNVGcwTlRjMU1qSWlPd29KSW5WdWFYRjFaUzEyWlc1a2IzSXRhV1JsYm5ScFptbGxjaUlnUFNBaVJVRXpORU15TmpNdE5EaEJOeTAwUlRnMkxVRXpSVE10TVRKR016a3pOVFUxTkVFMklqc0tDU0pwZEdWdExXbGtJaUE5SUNJMk5EY3hOelkwTnpnd0lqc0tDU0pwY3kxcGJpMXBiblJ5YnkxdlptWmxjaTF3WlhKcGIyUWlJRDBnSW1aaGJITmxJanNLQ1NKd2NtOWtkV04wTFdsa0lpQTlJQ0o2YjI5d2IzSjBjeTVrWlhZdVlXTnZjbTR1TlRBaU93b0pJbkIxY21Ob1lYTmxMV1JoZEdVaUlEMGdJakl3TWpNdE1URXRNak1nTURVNk5EYzZNemNnUlhSakwwZE5WQ0k3Q2draWFYTXRkSEpwWVd3dGNHVnlhVzlrSWlBOUlDSm1ZV3h6WlNJN0Nna2liM0pwWjJsdVlXd3RjSFZ5WTJoaGMyVXRaR0YwWlNJZ1BTQWlNakF5TXkweE1TMHlNeUF3TlRvME56b3pOeUJGZEdNdlIwMVVJanNLQ1NKaWFXUWlJRDBnSW1OdmJTNTNZWEprWjJGdFpYTXVlbTl2Y0c5eWRITmlaWFJoSWpzS0NTSndkWEpqYUdGelpTMWtZWFJsTFhCemRDSWdQU0FpTWpBeU15MHhNUzB5TWlBeU1UbzBOem96TnlCQmJXVnlhV05oTDB4dmMxOUJibWRsYkdWeklqc0tmUT09IjsKCSJlbnZpcm9ubWVudCIgPSAiU2FuZGJveCI7CgkicG9kIiA9ICIxMDAiOwoJInNpZ25pbmctc3RhdHVzIiA9ICIwIjsKfQ==";
            // 영수증 데이터 디코딩 및 파싱
            string receiptData = Encoding.UTF8.GetString(Convert.FromBase64String(receipt));
            Dictionary<string, string> receiptDataDict = ParseKeyValuePairs(receiptData);

            if (receiptDataDict.TryGetValue("signature", out string signature))
            {
                // var decodedReceiptSignature = Encoding.UTF8.GetString(Convert.FromBase64String(signature));
                string[] parsedSignature = signature.Split(".");
                // Console.WriteLine("Signature: " + decodedReceiptSignature);
            }

            // purchase-info 추출 및 파싱
            if (receiptDataDict.TryGetValue("purchase-info", out string purchaseInfoEncoded))
            {
                string purchaseInfoDecoded = Encoding.UTF8.GetString(Convert.FromBase64String(purchaseInfoEncoded));
                Dictionary<string, string> purchaseInfoDict = ParseKeyValuePairs(purchaseInfoDecoded);

                // 필요한 값 추출
                if (purchaseInfoDict.TryGetValue("product-id", out string productId))
                {
                    Console.WriteLine("Product ID: " + productId);
                }

                if (purchaseInfoDict.TryGetValue("original-transaction-id", out string originalTransactionId))
                {
                    Console.WriteLine("Original Transaction ID: " + originalTransactionId);
                }

                // TransactionId 검증   
                TransactionInfoResponse transactionInfoResponse = await GetTransactionInfoEndpoint.GetTransactionInfo(appStoreConnectClient, originalTransactionId, true);
                // JWSTransaction
                Console.WriteLine("TransactionInfoResponse : " + JsonConvert.SerializeObject(transactionInfoResponse));
            }

            // #if URL_DEBUG
            //     var resultMsg = await appStoreConnectClient.GetAppStoreInfoAsync(AppStoreConnectTestData.Url);
            //     var resultJson = await resultMsg.Content.ReadAsStringAsync();
            //     Console.WriteLine(resultJson);
            //     return;
            // #else
            //             ListAllInAppPurchasesParamContainer paramContainer = new ListAllInAppPurchasesParamContainer();
            //             paramContainer.FieldsLocalizations = new FieldsInAppPurchaseLocalizations(new FieldsInAppPurchaseLocalizations.Options[]
            //             {
            //                 FieldsInAppPurchaseLocalizations.Options.name,
            //                 FieldsInAppPurchaseLocalizations.Options.description,
            //             });
            //             var result = await ListAllInAppPurchasesEndPoint.GetListAllInAppPurchases(
            //                 appStoreConnectClient,
            //                 paramContainer
            //             );

            //             foreach (InAppPurchaseV2 iapData in result.InAppPurchaseV2List)
            //             {
            //                 Console.WriteLine($"{iapData.Id} / {iapData.Attributes.ProductId} / {iapData.Attributes.Name}");

            //                 var priceInfoQueryParam = new ReadPriceInformationParamContainer();
            //                 priceInfoQueryParam.Include = new ReadPriceInformationParamInclude(new ReadPriceInformationParamInclude.Options[]
            //                 {
            //                     ReadPriceInformationParamInclude.Options.inAppPurchasePricePoint
            //                 });
            //                 var priceResponse = await ReadPriceInformationEndPoint.GetInAppPurchasePricesResponse(
            //                     appStoreConnectClient,
            //                     iapData.Id,
            //                     priceInfoQueryParam);

            //                 var includeList = priceResponse.Included;
            //                 if (includeList != null)
            //                 {
            //                     foreach (var obj in includeList)
            //                     {
            //                         if (obj is InAppPurchasePricePoint)
            //                         {
            //                             var iapPricePoint = obj as InAppPurchasePricePoint;
            //                             Console.WriteLine($"price : {iapPricePoint?.Attributes.CustomerPrice}");
            //                         }
            //                     }
            //                 }
            //             }
            // #endif


        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine(e.StackTrace);
        }

        Dictionary<string, string> ParseKeyValuePairs(string input)
        {
            Dictionary<string, string> parsedData = new Dictionary<string, string>();
            string[] lines = input.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string line in lines)
            {
                string[] keyValue = line.Split(new[] { '=' }, 2);
                if (keyValue.Length == 2)
                {
                    string key = keyValue[0].Trim().Trim(new[] { '\"', ' ' });
                    string value = keyValue[1].Trim().Trim(new[] { '\"', ';' });
                    parsedData[key] = value;
                }
            }

            return parsedData;
        }
    }
}

