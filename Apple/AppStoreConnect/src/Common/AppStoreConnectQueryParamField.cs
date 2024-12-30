
namespace WardGames.Web.Apple.AppStoreConnect
{
    /// <summary>
    /// App Store Connect Query API 호출 시, 사용할 수 있는 Query Param 중, 
    /// 외부 include에서 필터링할 수 있는 옵션인 Field param 클래스. 
    /// </summary>
    public abstract class AppStoreConnectQueryParamField : AppStoreConnectQueryParamBase
    {
        /// <summary>
        /// 해당 Field param 구현 시, 반드시 포함시켜야 하는 include 값
        /// </summary>
        /// <value></value>
        public abstract string IncludeValue { get; }
    }
}