using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HeartbeatSharp.Core
{
    public class AuthenticatedHeartbeatApi : HeartbeatApi
    {
        public AuthenticatedHeartbeatApi(string token, string host) : base(host)
        {
            // Set the global variables.
            Host = host;
            // Initialise the HttpClient
            Client = new HttpClient();
            // Add our UserAgent to the client, to be used with each request.
            ProductInfoHeaderValue userAgent = new(nameof(HeartbeatApi), "1.0.0");
            Client.DefaultRequestHeaders.UserAgent.Add(userAgent);

            // Add the token header to each request.
            Client.DefaultRequestHeaders.Add("Auth", token);
        }

        public async Task Beat(string deviceName)
        {
            string url = Host + "/beat";

            using HttpRequestMessage requestMessage = new(HttpMethod.Post, url);
            requestMessage.Headers.Add("Device", deviceName);
    
            await Client.SendAsync(requestMessage);
        }
        
        public async void UpdateStats(string json)
        {
            await UpdateFromEndpoint("/update/stats", json);
        }
        
        public async void UpdateDevices(string json)
        {
            await UpdateFromEndpoint("/update/devices", json);
        }

        private async Task UpdateFromEndpoint(string json, string endpoint)
        {
            string url = Host + endpoint;
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            await Client.PostAsync(url, content);
        }
    }
}