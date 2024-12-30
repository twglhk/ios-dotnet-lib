
namespace WardGames.Web.Apple.AppStoreConnect.AppStore.InAppPurchase.InAppPurchases.QueryParams
{
    public sealed class FieldsInAppPurchaseContents : AppStoreConnectQueryParamField
    {
        /// <summary>
        /// Key
        /// </summary>
        public override string Key => "fields[inAppPurchaseContents]";

        /// <summary>
        /// IncludeValue
        /// </summary>
        public override string IncludeValue => ListAllInAppPurchasesParamInclude.Options.content.ToString();

        /// <summary>
        /// 사용하고자 하는 <see cref="FieldsInAppPurchaseContents.Options"/>의 배열로 초기화
        /// </summary>
        /// <param name="options"></param>
        public FieldsInAppPurchaseContents(Options[] options)
        {
            base.SetValues(options);
        }

        /// <summary>
        /// InAppPurchasesLocalizations가 incldue 되었을 때 필터링할 필드 옵션
        /// </summary>
        public enum Options
        {
            /// <summary>
            /// 파일명
            /// TODO: (설명 추가 필요)
            /// </summary>
            fileName, 

            /// <summary>
            /// 파일 크기
            /// TODO: (설명 추가 필요)
            /// </summary>
            fileSize, 

            /// <summary>
            /// TODO: (설명 추가 필요)
            /// </summary>
            inAppPurchaseV2, 

            /// <summary>
            /// TODO: (설명 추가 필요)
            /// </summary>
            lastModifiedDate, 

            /// <summary>
            /// TODO: (설명 추가 필요)
            /// </summary>
            url
        }
    }
}