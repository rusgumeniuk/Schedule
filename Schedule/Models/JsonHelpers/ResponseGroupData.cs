using Newtonsoft.Json;
using System;

namespace Schedule.Models.JsonHelpers
{
    public class ResponseGroupData : IResponseData
    {
        [JsonProperty("group_id")]
        public long Id { get; set; }

        [JsonProperty("group_full_name")]
        public string FullName { get; set; }

        [JsonProperty("group_prefix")]
        public string GroupPrefix { get; set; }

        [JsonProperty("group_okr")]
        public string GroupOkr { get; set; }

        [JsonProperty("group_type")]
        public string GroupType { get; set; }

        [JsonProperty("group_url")]
        public Uri Url { get; set; }
    }
}
