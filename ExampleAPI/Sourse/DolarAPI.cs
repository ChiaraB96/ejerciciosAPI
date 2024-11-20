using System.Net.Http.Headers;

namespace ExampleAPI.Sourse
{
    public class DolarAPI
    {
        public async Task<string> GetQuote()
        {
            string responseBody = string.Empty;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://dolarapi.com/v1/dolares/blue");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
                response.EnsureSuccessStatusCode();
                responseBody = response.Content.ReadAsStringAsync().Result;
            }
            return responseBody;


        }
        public async Task<string> GetSpecificQuote(Currency Currency)
        {
            string responseBody = string.Empty;
            using (var client = new HttpClient())
            {
                switch (Currency.Code.ToUpper())
                {
                    case "BOLSA":
                        client.BaseAddress = new Uri("https://dolarapi.com/v1/dolares/bolsa");
                        break;
                    case "BLUE":
                        client.BaseAddress = new Uri("https://dolarapi.com/v1/dolares/blue");
                        break;
                    case "CRIPTO":
                        client.BaseAddress = new Uri("https://dolarapi.com/v1/dolares/cripto");
                        break;
                    default:
                        throw new ArgumentException("Currency Type Error");
                }
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
                response.EnsureSuccessStatusCode();
                responseBody = response.Content.ReadAsStringAsync().Result;
            }
            return responseBody;
        }
    }
}
