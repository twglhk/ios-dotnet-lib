
namespace WardGames.Web.Apple.AppStoreConnect.AppStore.InAppPurchase.InAppPurchases
{
    /// <summary>
    /// <see cref="ListAllInAppPurchasesEndPoint"/> 에 Query 요청을 보낼 때 필요한 query 파라미터를 패키징하는 클래스
    /// </summary>
    public sealed class ListAllInAppPurchasesParamContainer : AppStoreConnectQueryParamContainer
    {
        private ListAllInAppPurchasesParamInclude _listAllInAppPurchasesInclude;
        private FieldsInAppPurchaseLocalizations _fieldsLocalizations;

        /// <summary>
        /// Include 가능 value는 <see cref="ListAllInAppPurchasesParamInclude"/> 참조
        /// </summary>
        /// <value></value>
        public ListAllInAppPurchasesParamInclude ListAllInAppPurchasesInclude
        {
            get => _listAllInAppPurchasesInclude;
            set
            {
                if (value == null) return;

                _listAllInAppPurchasesInclude = value;
                QueryParams.Add(value);
            }
        }

        /// <summary>
        /// 가능한 Field value는 <see cref="FieldsInAppPurchaseLocalizations"/> 참조 
        /// </summary>
        /// <value></value>
        public FieldsInAppPurchaseLocalizations FieldsLocalizations
        {
            get => _fieldsLocalizations;
            set
            {
                if (value == null) return;

                _fieldsLocalizations = value;
                QueryParams.Add(value);
            }
        }
    }
}