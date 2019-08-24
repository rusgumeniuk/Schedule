using Newtonsoft.Json;

namespace Schedule.Models.JsonHelpers
{
    public class ResponseMeta
    {
        [JsonProperty("total_count")]
        public long TotalCount { get; set; }

        [JsonProperty("offset")]
        public long Offset { get; set; }

        [JsonProperty("limit")]
        public long Limit { get; set; }
    }
}
