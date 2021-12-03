using Newtonsoft.Json;

namespace HeartbeatSharp.Endpoints
{
    public struct LastBeat
    {
        [JsonProperty("device_name")] 
        public string DeviceName { get; set; }

        [JsonProperty("timestamp")] 
        public long Timestamp { get; set; }
    }
}