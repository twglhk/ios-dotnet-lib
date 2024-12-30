
namespace WardGames.Web.Apple.AppStoreConnect
{
    /// <summary>
    /// App Store Connect Query API 호출 시, 사용할 수 있는 Query Param 중 
    /// 응답 결과인 Response 이외에, 다른 결과 값을 포함하고 싶을 때 사용하는 옵션인 include param 클래스.
    /// </summary>
    public abstract class AppStoreConnectQueryParamInclude : AppStoreConnectQueryParamBase
    {
        /// <summary>
        /// 기본 Key 값. 단순 key값 표시 용이며 사용하지는 않음.
        /// </summary>
         public override string Key => "include";
    }
}