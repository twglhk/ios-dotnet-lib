
namespace WardGames.Web.Apple.AppStoreConnect
{
    /// <summary>
    /// App Store Connect Query관련 API 호출 시, 옵션으로 넣을 수 있는 Query Param의 base 클래스 
    /// Value로 사용될 수 있는 옵션은, 서브 클래스에서 enum으로 구현.
    /// </summary>
    public abstract class AppStoreConnectQueryParamBase
    {
        private List<string> _values;

        /// <summary>
        /// Query Param의 Key. 
        /// <see cref="AppStoreConnectQueryParamField"/>와 <see cref="AppStoreConnectQueryParamFilter"/> 는 반드시 해당 값 명시 필요.
        /// </summary>
        /// <value></value>
        public virtual string Key { get; }

        /// <summary>
        /// Query Param의 value array
        /// </summary>
        /// <returns></returns>
        public string[] Values => _values.ToArray();

        /// <summary>
        /// Query Param의 Value를 셋업하는 메서드. 
        /// 하위 클래스 생성자에서 반드시 호출 필요.
        /// </summary>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        protected void SetValues<T>(T[] options) where T : Enum
        {
            if (options?.Length == 0)
                return;

            _values = new List<string>(options.Length);
            foreach (var option in options)
            {
                AddValue(option);
            }
        }

        /// <summary>
        /// Query Param에 value를 추가.  
        /// </summary>
        /// <param name="option"></param>
        /// <typeparam name="T"></typeparam>
        public virtual void AddValue<T>(T option) where T : Enum
        {
            if (_values.Contains(option.ToString())) return;
            _values.Add(option.ToString());
        }
    }
}