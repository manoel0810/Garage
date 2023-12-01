using Domain.Models;
using System.Text.Json;

namespace Domain.Request
{
    public class APIRequest
    {
        private readonly string _API_SERVICE_HOST = "https://localhost:32770/";
        private readonly string _routeAllClient = "Client";

        public async Task<IEnumerable<Pass>?> GetPassesAsync()
        {
            HttpClientHost host = new HttpClientHost(_API_SERVICE_HOST, _routeAllClient);
            string response = await host.DoRequest();

            if (response != null)
            {
                PassStruct? passes = JsonSerializer.Deserialize<PassStruct?>(response);
                if (passes != null)
                {
                    return passes.Passagens as IEnumerable<Pass>;
                }
                else
                    return null;
            }
            else
            {
                return null;
            }
        }


        private class HttpClientHost
        {
            private readonly string _host;
            private readonly string _endPoint;

            public HttpClientHost(string host, string endPoint)
            {
                _host = host;
                _endPoint = endPoint;
            }

            public async Task<string> DoRequest()
            {
                using (HttpClient client = new())
                {
                    client.BaseAddress = new Uri(_host);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync(_endPoint);

                    if (response.IsSuccessStatusCode)
                    {
                        string sq = await response.Content.ReadAsStringAsync();
                        return sq;
                    }
                    else
                    {
                        return "";
                    }
                }
            }
        }
    }
}
