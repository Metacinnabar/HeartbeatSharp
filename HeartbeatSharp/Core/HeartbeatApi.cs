using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using HeartbeatSharp.Endpoints;
using Newtonsoft.Json;

namespace HeartbeatSharp.Core
{
    /// <summary>
    /// Main API class where endpoints are accessed from.
    /// </summary>
    public class HeartbeatApi
    {
        /// <summary>
        /// HttpClient used with every request. Headers initialized in ctor.
        /// </summary>
        protected HttpClient Client { get; set; }

        /// <summary>
        /// Host for all requests.
        /// </summary>
        protected string Host { get; set; }

        /// <summary>
        /// Api initialisation with UserAgent header.
        /// </summary>
        /// <param name="host">The heartbeat host.</param>
        public HeartbeatApi(string host)
        {
            // Initialise the host variable.
            Host = host;
            // Initialise the HttpClient.
            Client = new HttpClient();
            // Add our UserAgent to the client, to be used with each request.
            ProductInfoHeaderValue userAgent = new(nameof(HeartbeatApi), "1.0.0");
            Client.DefaultRequestHeaders.UserAgent.Add(userAgent);
        }

        /// <summary>
        /// Return Info object from the /api/info endpoint.
        /// </summary>
        /// <returns>Info object from host.</returns>
        public async Task<ApiResponse<Info>> GetInfo()
        {
            return await GetFromEndpoint<Info>("/info");
        }
        
        /// <summary>
        /// Return Device list object from the /api/devices endpoint.
        /// </summary>
        /// <returns>Device list object from host.</returns>
        public async Task<ApiResponse<List<Device>>> GetDevices()
        {
            return await GetFromEndpoint<List<Device>>("/devices");
        }
        
        /// <summary>
        /// Return Stats object from the /api/stats endpoint.
        /// </summary>
        /// <returns>Stats object from host.</returns>
        public async Task<ApiResponse<Stats>> GetStats()
        {
            return await GetFromEndpoint<Stats>("/stats");
        }

        /// <summary>
        /// Get an API response from a provided endpoint.
        /// </summary>
        /// <param name="endpoint">The endpoint to query data from.</param>
        /// <typeparam name="T">Type to parse the data into.</typeparam>
        /// <returns>Returns an API response object of the provided type.</returns>
        private async Task<ApiResponse<T>> GetFromEndpoint<T>(string endpoint)
        {
            // Create a local variable to ease grabbing the url.
            string url = Host + endpoint;

            // Send request to the client and parse the headers for ratelimiting.
            using HttpResponseMessage response = await Client.GetAsync(url);
            
            // Query the endpoint and assign the API response to a local variable.
            string json = await response.Content.ReadAsStringAsync();
            
            // Return a parsed JSON string into our provided type argument.
            T? data = JsonConvert.DeserializeObject<T>(json);

            // Create and return ApiResponse object from returned data
            return new ApiResponse<T>(data, data != null);
        }
    }
}