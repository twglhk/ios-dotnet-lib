using System.Net;
using System.Text;

namespace WardGames.Web.Apple.AppStoreConnect
{
    internal class AppStoreConnectAPIHelper
    {
        internal static async Task<string> GetRequest(
            AppStoreConnectClient client,
            AppStoreConnectAPIVersion apiVersion,
            string pathFormat,
            object[] pathArgs,
            AppStoreConnectQueryParamContainer paramContainer = null)
        {
            string targetEndpoint = AppStoreConnectAPIHelper.CreateAppStoreConnectAPIQueryEndpoint(
                apiVersion: apiVersion,
                pathFormat: pathFormat,
                pathArgs: pathArgs,
                paramContainer: paramContainer);
            return await AppStoreConnectAPIHelper.GetResultJsonFromTargetEndpoint(client, targetEndpoint);
        }

        internal static string CreateAppStoreConnectAPIQueryEndpoint(
            AppStoreConnectAPIVersion apiVersion,
            string pathFormat,
            object[] pathArgs,
            AppStoreConnectQueryParamContainer paramContainer = null)
        {
            StringBuilder stringBuilder = new StringBuilder();

            // 기본 Endpont path 생성
            string path = string.Format(pathFormat, pathArgs);
            stringBuilder.Append(AppStoreConnectEndpointCommonData.AppleConnectStoreAPIUrl[apiVersion]);
            stringBuilder.Append(path);

            // 옵션 param이 없었다면 종료
            if (paramContainer == null || paramContainer?.QueryParams.Count == 0)
                return stringBuilder.ToString();

            // Query Param을 Endpoint에 추가
            // Collects all includes from each queryParams
            List<string> queryParamValues = new List<string>();
            List<string> includeValues = new List<string>();

            AppStoreConnectQueryParamInclude includeParam =
                paramContainer.QueryParams.OfType<AppStoreConnectQueryParamInclude>().SingleOrDefault();
            List<AppStoreConnectQueryParamField> fieldsList =
                paramContainer.QueryParams.OfType<AppStoreConnectQueryParamField>().ToList();

            // include param이 있었다면 추가. 이 param은 하나만 존재해야 함.
            if (includeParam != null && includeParam.Values.Any())
            {
                includeValues.AddRange(includeParam.Values);
            }

            // field param이 있었다면 추가. 이 param은 include를 필요로하기 때문에, Include에 중복되는 값이 없다면 추가.
            if (fieldsList.Count > 0)
            {
                // add values from fieldsList
                foreach (AppStoreConnectQueryParamField field in fieldsList)
                {
                    // Include 추가
                    if (!includeValues.Contains(field.IncludeValue))
                    {
                        includeValues.Add(field.IncludeValue);
                    }

                    // Field 추가
                    queryParamValues.Add($"{WebUtility.UrlEncode(field.Key)}={WebUtility.UrlEncode(string.Join(",", field.Values))}");
                }
            }

            //TODO: Filter, Limit 등 다른 Query Param 처리 필요

            // include 파라미터 추가
            if (includeValues.Count > 0)
            {
                queryParamValues.Insert(0, $"include={WebUtility.UrlEncode(string.Join(",", includeValues))}");
            }

            // Query Param 엔드 포인트 생성
            // 옵션을 위한 '?' 추가
            stringBuilder.Append("?");
            stringBuilder.Append(string.Join("&", queryParamValues));

            return stringBuilder.ToString();
        }

        internal static async Task<string> GetResultJsonFromTargetEndpoint(AppStoreConnectClient client, string uri)
        {
            HttpResponseMessage message = await client.SendHttpRequest(HttpMethod.Get, uri);
            return await message.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// App Store Connect API Query 호출 
        /// TODO: 위에 레가시 코드 중복 제거 (위에 버전이 Api version을 사용하고 있는데, 저걸 사용하지 않는 방식으로 변경 예정 - 범용성이 낮음)
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="pathArgs"></param>
        /// <param name="paramContainer"></param>
        /// <returns></returns>
        internal static string CreateAppStoreConnectAPIQueryEndpoint(
            IAppStoreConnectAPIEndpoint endpoint,
            object[] pathArgs,
            AppStoreConnectQueryParamContainer paramContainer = null)
        {
            StringBuilder stringBuilder = new StringBuilder();

            // 기본 Endpont path 생성
            stringBuilder.Append(endpoint.Endpoint);
            string path = string.Format(endpoint.PathPram, pathArgs);
            stringBuilder.Append(path);

            // 옵션 param이 없었다면 종료
            if (paramContainer == null || paramContainer.QueryParams.Count == 0)
                return stringBuilder.ToString();

            // Query Param을 Endpoint에 추가
            // Collects all includes from each queryParams
            List<string> queryParamValues = new List<string>();
            List<string> includeValues = new List<string>();

            AppStoreConnectQueryParamInclude includeParam =
                paramContainer.QueryParams.OfType<AppStoreConnectQueryParamInclude>().SingleOrDefault();
            List<AppStoreConnectQueryParamField> fieldsList =
                paramContainer.QueryParams.OfType<AppStoreConnectQueryParamField>().ToList();

            // include param이 있었다면 추가. 이 param은 하나만 존재해야 함.
            if (includeParam != null && includeParam.Values.Any())
            {
                includeValues.AddRange(includeParam.Values);
            }

            // field param이 있었다면 추가. 이 param은 include를 필요로하기 때문에, Include에 중복되는 값이 없다면 추가.
            if (fieldsList.Count > 0)
            {
                // add values from fieldsList
                foreach (AppStoreConnectQueryParamField field in fieldsList)
                {
                    // Include 추가
                    if (!includeValues.Contains(field.IncludeValue))
                    {
                        includeValues.Add(field.IncludeValue);
                    }

                    // Field 추가
                    queryParamValues.Add($"{WebUtility.UrlEncode(field.Key)}={WebUtility.UrlEncode(string.Join(",", field.Values))}");
                }
            }

            //TODO: Filter, Limit 등 다른 Query Param 처리 필요

            // include 파라미터 추가
            if (includeValues.Count > 0)
            {
                queryParamValues.Insert(0, $"include={WebUtility.UrlEncode(string.Join(",", includeValues))}");
            }

            // Query Param 엔드 포인트 생성
            // 옵션을 위한 '?' 추가
            stringBuilder.Append("?");
            stringBuilder.Append(string.Join("&", queryParamValues));

            return stringBuilder.ToString();
        }
    }
}