
namespace WardGames.Web.Apple.AppStoreConnect.AppStore
{
    /// <summary>
    /// 영수증 파싱을 도와주는 클래스. <br/>
    /// </summary>
    public class AppStoreConnectReceiptParser 
    {
        /// <summary>
        /// 영수증 파싱 메서드. <br/>
        /// </summary>
        /// <param name="input">iOS 영수증</param>
        /// <returns></returns>
        public static Dictionary<string, string> ParseKeyValuePairs(string input)
        {
            Dictionary<string, string> parsedData = new Dictionary<string, string>();
            string[] lines = input.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string line in lines)
            {
                string[] keyValue = line.Split(new[] { '=' }, 2);
                if (keyValue.Length == 2)
                {
                    string key = keyValue[0].Trim().Trim(new[] { '\"', ' ' });
                    string value = keyValue[1].Trim().Trim(new[] { '\"', ';' });
                    parsedData[key] = value;
                }
            }

            return parsedData;
        }
    }
}