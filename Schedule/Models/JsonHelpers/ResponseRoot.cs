using Newtonsoft.Json;

namespace Schedule.Models.JsonHelpers
{
    abstract public class ResponseRoot<T>
        where T : IResponseData
    {
        [JsonProperty("statusCode")]
        public long StatusCode { get; set; }

        [JsonProperty("timeStamp")]
        public long TimeStamp { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("debugInfo")]
        public object DebugInfo { get; set; }

        [JsonProperty("meta")]
        public ResponseMeta Meta { get; set; }        
    }
}
