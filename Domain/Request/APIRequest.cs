using Domain.Models;
using System.Text.Json;

namespace Domain.Request
{
    public class APIRequest
    {
        private readonly string _API_SERVICE_HOST = "http://localhost:5180/";

        private static IEnumerable<Pass>? TreatResponseGarageContent(string response)
        {
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

        private static IEnumerable<GaragensModel>? TreatResponseGarage(string response)
        {
            if (response != null)
            {
                GaragensStruct? passes = JsonSerializer.Deserialize<GaragensStruct?>(response);
                if (passes != null)
                {
                    return passes.Garagens as IEnumerable<GaragensModel>;
                }
                else
                    return null;
            }
            else
            {
                return null;
            }
        }

        private static IEnumerable<PaymentFormModel>? TreatResponsePayment(string response)
        {
            if (response != null)
            {
                PaymentStruct? passes = JsonSerializer.Deserialize<PaymentStruct?>(response);
                if (passes != null)
                {
                    return passes.FormasPagamento as IEnumerable<PaymentFormModel>;
                }
                else
                    return null;
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<Pass>?> GetPassesAsync(string route)
        {
            HttpClientHost host = new(_API_SERVICE_HOST, route);
            string response = await host.DoRequest();

            return TreatResponseGarageContent(response);
        }

        public async Task<IEnumerable<Pass>?> GetPassesByGarageCode(string route, string param)
        {
            HttpClientHost host = new(_API_SERVICE_HOST, route, param);
            string response = await host.DoRequest();

            return TreatResponseGarageContent(response);
        }

        public async Task<IEnumerable<GaragensModel>?> GetGarageInformation(string route, string param)
        {
            HttpClientHost host = new(_API_SERVICE_HOST, route, param);
            string response = await host.DoRequest();

            return TreatResponseGarage(response);
        }

        public async Task<IEnumerable<PaymentFormModel>?> GetAllPaymentFormats()
        {
            HttpClientHost host = new(_API_SERVICE_HOST, "payment", "");
            string response = await host.DoRequest();

            return TreatResponsePayment(response);
        }


        private class HttpClientHost
        {
            private readonly string _host;
            private readonly string _endPoint;

            public HttpClientHost(string host, string endPoint, string param = "")
            {
                if (!string.IsNullOrWhiteSpace(param))
                    if (!param.StartsWith("/"))
                        param = $"/{param}";

                _host = host;
                _endPoint = $"{endPoint}{param}";
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
