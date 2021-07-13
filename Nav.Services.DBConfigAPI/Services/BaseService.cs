using Nav.Services.DBConfigAPI.IServices;
using Nav.Services.DBConfigAPI.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Nav.Services.DBConfigAPI.Services
{
    public class BaseService :IBaseService
    {
        public IHttpClientFactory httpClient;
        public BaseService(IHttpClientFactory httpClient)
        {
           
            this.httpClient = httpClient;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<Fields>> SendAsync(ApiRequest apiRequest)
        {
             List<Fields> apiResponseDto = new List<Fields>();
            try
            {
                var client = httpClient.CreateClient("NavAPI");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.Url);
                client.DefaultRequestHeaders.Clear();

                 message.Content = new StringContent(JsonConvert.SerializeObject(""),
                              Encoding.UTF8, "application/json");
                message.Method = HttpMethod.Get;
                HttpResponseMessage apiResponse = null;
               
                apiResponse = await client.SendAsync(message);

                var apiContent = await apiResponse.Content.ReadAsStringAsync();
                apiResponseDto = JsonConvert.DeserializeObject<List<Fields>>(apiContent);
                return apiResponseDto;

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error --> {0} and at function -->{1}",
                   ex.Message.ToString(), ex.Source);
               
            }
            return apiResponseDto;
        }
    }

}
