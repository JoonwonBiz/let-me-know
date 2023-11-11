using Newtonsoft.Json;
using System.Reflection;
using System.Text;

namespace Core
{
    public class CostcoClient
    {
        public async Task<List<CostcoProduct>> GetCostcoDiscount()
        {
            List<CostcoProduct> product = new();

            try
            {
                Dictionary<string, string> headerKvps = new();

                string url = "https://www.cocodalin.com/api/front/productList/7";

                string responseJson = await RequestApi(url, string.Empty, "GET", string.Empty, headerKvps, 10);

                product = JsonConvert.DeserializeObject<List<CostcoProduct>>(responseJson)!;
            }
            catch (Exception ex)
            {
                Logging.WriteLog($"[{MethodBase.GetCurrentMethod()!.Name}] {ex.Message}");
            }

            return product;
        }

        private async Task<string> RequestApi(string url, string requestJson, string type, string formType, Dictionary<string, string> headerKvps, int timeout)
        {
            string responseJson = string.Empty;

            try
            {
                using (HttpClient client = new())
                {
                    client.Timeout = TimeSpan.FromSeconds(timeout);

                    HttpResponseMessage response = new();

                    foreach (var kvp in headerKvps)
                    {
                        client.DefaultRequestHeaders.Add(kvp.Key, kvp.Value);
                    }

                    if (type == "POST" && formType == "json")
                    {
                        StringContent content = new(requestJson, Encoding.UTF8, "application/json");
                        response = await client.PostAsync(url, content);
                    }
                    else if (type == "GET")
                    {
                        response = await client.GetAsync(url);
                    }

                    if (response.IsSuccessStatusCode == false)
                    {
                        Logging.WriteLog($"[{MethodBase.GetCurrentMethod()!.Name}] gpt-api Error : {response.StatusCode}");
                    }
                    else
                    {
                        responseJson = await response.Content.ReadAsStringAsync();
                    }

                    return responseJson;
                }
            }
            catch (Exception ex)
            {
                Logging.WriteLog($"[{MethodBase.GetCurrentMethod()!.Name}] {ex.Message}");
                throw;
            }
        }
    }

    public class CostcoProduct
    {
        public string category_name { get; set; } = string.Empty;
        public string from_date { get; set; } = string.Empty;
        public string product_image { get; set; } = string.Empty;
        public int discount { get; set; }
        public string product_name { get; set; } = string.Empty;
        public int sale_price { get; set; }
        public string category_image { get; set; } = string.Empty;
        public int share_cnt { get; set; }
        public int category_id { get; set; }
        public int normal_price { get; set; }
        public string to_date { get; set; } = string.Empty;
        public int product_id { get; set; }
        public int like_cnt { get; set; }
    }

    public class CostcoRoot
    {
        public List<CostcoProduct> products { get; set; } = new();
    }
}
