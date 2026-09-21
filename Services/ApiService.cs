using System.Net.Http.Headers;
using System.Text.Json;

namespace PruebaTecnicaNET.Services
{
    public class ApiService
    {

        private static HttpClient httpClient = new HttpClient();
        private static string access_token = "";
        private static JsonElement item_list;

        // Para la obtención del token
        static KeyValuePair<string, string>[] accessParams = new KeyValuePair<string, string>[] {
            new KeyValuePair<string, string>("username", "pruebaNET"),
            new KeyValuePair<string, string>("password", "PruebaNET123"),
            new KeyValuePair<string, string>("grant_type", "password")
        };


        // Llama a las funciones que realizan la comunicación con el servicio
        public static async Task<JsonElement> GetItems()
        {
            access_token = await GetToken(httpClient);

            item_list = await GetItemList(httpClient, access_token);

            return item_list;
        }


        // Obtención del token de acceso
        static async Task<string> GetToken(HttpClient httpClient)
        {

            FormUrlEncodedContent requestContent = new FormUrlEncodedContent(accessParams);

            
            HttpResponseMessage response = await httpClient.PostAsync("http://url:8082/Service/Token", requestContent);

            if (response.IsSuccessStatusCode)
            {
                using JsonDocument jsonResponse = JsonDocument.Parse(await response.Content.ReadAsStringAsync());

                if (jsonResponse.RootElement.TryGetProperty("access_token", out JsonElement tokenValue))
                {
                    string access_token = tokenValue.GetString() ?? throw new Exception("Token value is null");
                    return access_token;

                }
                else
                {
                    throw new Exception("token_access not found in response");
                }
            }

            throw new HttpRequestException($"HTTP Error: {response.StatusCode}");
        }


        // Devuelve un objeto Json con la lista de clientes obtenidos en la petición
        static async Task<JsonElement> GetItemList(HttpClient httpClient, string access_token)
        {

            string baseURL = "http://url:8082/Service/api/customers";
            string orderby = "Id";
            int top = 100;
            int skip = 0;

            HttpRequestMessage request;
            HttpResponseMessage response;

            string responseBody;

            request = new HttpRequestMessage(HttpMethod.Get, baseURL + "?orderby=" + orderby + "&top=" + top.ToString() + "&skip=" + skip.ToString());
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", access_token);

            response = await httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {

                responseBody = await response.Content.ReadAsStringAsync();

                JsonDocument jsonDocument = JsonDocument.Parse(responseBody);
                JsonElement customers = jsonDocument.RootElement.GetProperty("Items");

                return customers;

            }
            else
            {
                throw new HttpRequestException($"HTTP Error: {response.StatusCode}");
            }
        }
    }
}
