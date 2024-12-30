using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WardGames.Web.Apple.AppStoreConnect.AppStore.InAppPurchase.InAppPurchases;

namespace WardGames.Web.Apple.AppStoreConnect
{
    /// <summary>
    /// App Store Connect API 객체를 위한 JSON 컨버터입니다.
    /// 이 컨버터는 JSON 객체의 'type' 필드를 기반으로 특정 클래스로의 역직렬화를 선택하여 App Store Connect API 객체의 목록을 처리합니다.
    /// </summary>
    public class AppStoreConnectAPIObjectConverter : JsonConverter
    {
        /// <summary>
        /// 이 컨버터가 변환 가능한 타입인지 확인합니다.
        /// 이 커스텀 컨버터는 변환할 해당 오브젝트의 타입이 <see cref="IAppStoreConnectAPIObject"/>의 List인지 확인합니다.
        /// </summary>
        /// <param name="objectType">확인할 타입</param>
        /// <returns>변환 가능한 경우 true를 반환합니다.</returns>
        public override bool CanConvert(Type objectType)
        {
            return typeof(List<IAppStoreConnectAPIObject>).IsAssignableFrom(objectType);
        }

        /// <summary>
        /// JSON을 읽어서 객체로 변환합니다.
        /// JSON 객체의 'type' 필드를 기반으로 특정 클래스로 역직렬화하고 결과 목록에 추가합니다.
        /// </summary>
        /// <param name="reader">JSON을 읽는 데 사용되는 JsonReader 객체</param>
        /// <param name="objectType">대상 객체 타입</param>
        /// <param name="existingValue">변경 중인 객체의 현재 값</param>
        /// <param name="serializer">사용되는 JsonSerializer</param>
        /// <returns>역직렬화된 객체를 반환합니다.</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JArray array = JArray.Load(reader);
            List<IAppStoreConnectAPIObject> result = new List<IAppStoreConnectAPIObject>();

            foreach (var item in array)
            {
                switch (item["type"].Value<string>())
                {
                    case "inAppPurchasePricePoints":
                        result.Add(item.ToObject<InAppPurchasePricePoint>(serializer));
                        break;
                    // 기타 타입에 대한 case문 추가
                    default:
                        throw new InvalidOperationException("Unknown type");
                }
            }

            return result;
        }

        /// <summary>
        /// 객체를 JSON으로 쓰는 메소드입니다.
        /// 이 컨버터는 역직렬화만을 담당하므로, 이 메소드는 구현되지 않았습니다.
        /// </summary>
        /// <param name="writer">JSON을 쓰는 데 사용되는 JsonWriter 객체</param>
        /// <param name="value">변환할 객체</param>
        /// <param name="serializer">사용되는 JsonSerializer</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}