
using System.Configuration;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using HangrySoT.ApiClient.Models;

namespace HangrySoT.ApiClient.Zomato
{
    public class ZomatoClient
    {
        readonly string userKey = ConfigurationManager.AppSettings["ZomatoApiKey"];  //Read api key from AppSecret.config

        public async Task<ZomatoResponse> SearchByLatLon(decimal latitude = -36.8441547m, decimal longitude = 174.7576598m)
        {
            int radius = 5000;
            var requestUri = $"https://developers.zomato.com/api/v2.1/search?lat={latitude}&lon={longitude}&radius={radius}";
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("user-key", userKey);
                var response = await client.GetAsync(requestUri);
                var responseString = await response.Content.ReadAsStringAsync();

                var deserialised = JsonConvert.DeserializeObject<ZomatoResponse>(responseString);

                return deserialised;
            }
        }
    }
}
