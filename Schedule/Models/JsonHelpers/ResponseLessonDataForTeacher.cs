using Newtonsoft.Json;

namespace Schedule.Models.JsonHelpers
{
    public class ResponseLessonDataForTeacher : ResponseLessonData
    {
        [JsonProperty("groups")]
        public ResponseGroupData[] Groups { get; set; }
    }
}
