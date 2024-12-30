
namespace WardGames.Web.Apple.AppStoreConnect
{
    /// <summary>
    /// App Store Connect에서 Query 관련 API를 호출할 때, 
    /// 옵션으로 넣을 수 있는 <see cref="AppStoreConnectQueryParamBase"/>들을 패키징하는 클래스
    /// 컨테이너에 포함될 수 있는 Query Param은 서브 클래스에서 프로퍼티로 선언하여 구현.
    /// </summary>
    public abstract class AppStoreConnectQueryParamContainer
    {
        /// <summary>
        /// Query Param의 리스트
        /// </summary>
        /// <value></value>
        public List<AppStoreConnectQueryParamBase> QueryParams { get; protected set; }
    
        /// <summary>
        /// Container 생성자. QueryParams에 빈 리스트 생성.
        /// </summary>
        protected AppStoreConnectQueryParamContainer()
        {
            QueryParams = new List<AppStoreConnectQueryParamBase>();
        }
    }
}