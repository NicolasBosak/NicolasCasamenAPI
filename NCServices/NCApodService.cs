using Newtonsoft.Json;
using NIcolasCasamenAPI.NCModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIcolasCasamenAPI.NCServices
{
    public class NCApodService
    {
        public async Task<NCApod> GetImage(DateTime dt)
        {
            NCApod dto = null;
            HttpResponseMessage response;
            string requestUrl = $"https://api.nasa.gov/planetary/apod?date={dt.ToString("yyyy-MM-dd")}&api_key=DxmgcnhZXliUyKEXC1Es8EH2Y1NFkgy3vmJmFPwL";
            try
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
                HttpClient client = new HttpClient();
                response = await client.SendAsync(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    dto = JsonConvert.DeserializeObject<NCApod>(json);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }
            return dto;
        }

    }
}
