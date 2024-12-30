
namespace WardGames.Web.Apple.AppStoreConnect.AppStore.InAppPurchase.InAppPurchases
{
    /// <summary>
    /// App Store Connect에서 InAppPurchase 관련 query API 호출 시, 
    /// InAppPurchaseLocalizations와 관련된 데이터를 Include 하고, 
    /// 해당 데이터 내부에서 필터링할 필드 값을 지정하는 옵션 클래스
    /// </summary>
    public sealed class FieldsInAppPurchaseLocalizations : AppStoreConnectQueryParamField
    {
        /// <summary>
        /// Key
        /// </summary>
        public override string Key => "fields[inAppPurchaseLocalizations]";

        /// <summary>
        /// IncludeValue
        /// </summary>

        public override string IncludeValue => ListAllInAppPurchasesParamInclude.Options.inAppPurchaseLocalizations.ToString();

        /// <summary>
        /// 사용하고자 하는 <see cref="FieldsInAppPurchaseLocalizations.Options"/>의 배열로 초기화
        /// </summary>
        /// <param name="options"></param>
        public FieldsInAppPurchaseLocalizations(Options[] options)
        {
            base.SetValues(options);
        }

        /// <summary>
        /// InAppPurchasesLocalizations가 incldue 되었을 때 필터링할 필드 옵션
        /// </summary>
        public enum Options
        {
            /// <summary>
            /// 지역별 IAP 상세 설명
            /// </summary>
            description,

            /// <summary>
            /// inAppPurchaseV2
            /// </summary>
            inAppPurchaseV2,

            /// <summary>
            /// 지역
            /// </summary>
            locale,

            /// <summary>
            /// 지역별 IAP 이름
            /// </summary>
            name,

            /// <summary>
            /// 지역별 IAP 상태
            /// </summary>
            state
        }
    }
}