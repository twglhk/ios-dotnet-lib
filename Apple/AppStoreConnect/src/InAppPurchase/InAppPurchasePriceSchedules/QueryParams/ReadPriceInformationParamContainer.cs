
namespace WardGames.Web.Apple.AppStoreConnect.AppStore.InAppPurchase.InAppPurchasePriceSchedules
{
    /// <summary>
    /// <see cref="ReadPriceInformationEndPoint"/> 에 요청을 보낼 때 필요한 query 파라미터를 패키징하는 클래스
    /// </summary>
    public sealed class ReadPriceInformationParamContainer : AppStoreConnectQueryParamContainer
    {
        private ReadPriceInformationParamInclude _include;

        /// <summary>
        /// 자세한 사항은 <see cref="ReadPriceInformationParamInclude.Options"/> 참조
        /// </summary>
        public ReadPriceInformationParamInclude Include
        {
            get => _include;
            set
            {
                if (value == null) return;

                _include = value;
                QueryParams.Add(value);
            }
        }
    }
}