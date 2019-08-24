using Newtonsoft.Json;
using System;

namespace Schedule.Models.JsonHelpers
{
    public class ResponseTeacherData : IResponseData
    {
        [JsonProperty("teacher_id")]
        public long Id { get; set; }

        [JsonProperty("teacher_name")]
        public string TeacherName { get; set; }

        [JsonProperty("teacher_full_name")]
        public string FullName { get; set; }

        [JsonProperty("teacher_short_name")]
        public string TeacherShortName { get; set; }

        [JsonProperty("teacher_url")]
        public Uri Url { get; set; }

        [JsonProperty("teacher_rating")]
        public string TeacherRating { get; set; }
    }
}
