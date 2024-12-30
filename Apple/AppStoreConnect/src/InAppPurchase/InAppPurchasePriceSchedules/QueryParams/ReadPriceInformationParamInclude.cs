
namespace WardGames.Web.Apple.AppStoreConnect.AppStore.InAppPurchase.InAppPurchasePriceSchedules
{
    /// <summary>
    /// <see cref="ReadPriceInformationEndPoint"/>의 query param 중, include 관련 옵션을 설정하는 클래스
    /// </summary>
    public sealed class ReadPriceInformationParamInclude : AppStoreConnectQueryParamInclude
    {
        /// <summary>
        /// Constructor. 필요한 옵션을 배열 형태로 전달.
        /// </summary>
        /// <param name="options"></param>
        public ReadPriceInformationParamInclude(Options[] options)
        {
            base.SetValues(options);
        }

        /// <summary>
        /// <see cref="ReadPriceInformationEndPoint"/>의 include 옵션.
        /// </summary>
        public enum Options
        {
            /// <summary>
            /// 해당 IAP의 가격 정보를 포함
            /// </summary>
            inAppPurchasePricePoint,

            /// <summary>
            /// 해당 IAP의 지역 정보를 포함
            /// </summary>
            territory
        }
    }
}