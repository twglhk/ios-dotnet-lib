
namespace WardGames.Web.Apple.AppStoreConnect.AppStore.InAppPurchase.InAppPurchases
{
    /// <summary>
    /// <see cref="ListAllInAppPurchasesEndPoint"/>의 query param 중, include 관련 옵션을 설정하는 클래스
    /// </summary>
    public sealed class ListAllInAppPurchasesParamInclude : AppStoreConnectQueryParamInclude
    {
        /// <summary>
        /// Constructor. 필요한 옵션을 배열 형태로 전달.
        /// </summary>
        /// <param name="options"></param>
        public ListAllInAppPurchasesParamInclude(Options[] options)
        {
            base.SetValues(options);
        }

        /// <summary>
        /// <see cref="ListAllInAppPurchasesEndPoint"/>의 include 옵션.
        /// </summary>
        public enum Options
        {
            /// <summary>
            /// TODO: (설명 추가 필요)
            /// </summary>
            appStoreReviewScreenshot,

            /// <summary>
            /// TODO: (설명 추가 필요)
            /// </summary>
            content,

            /// <summary>
            /// IAP의 가격 스케쥴링과 관련된 정보를 포함시킵니다.
            /// </summary>
            iapPriceSchedule,

            /// <summary>
            /// TODO: (설명 추가 필요)
            /// </summary>
            inAppPurchaseAvailability,

            /// <summary>
            /// IAP의 Localization(출시 지역마다의 정보)과 관련된 정보를 가져옵니다. 
            /// </summary>
            inAppPurchaseLocalizations,

            /// <summary>
            /// TODO: (설명 추가 필요)
            /// </summary>
            promotedPurchase
        }
    }
}