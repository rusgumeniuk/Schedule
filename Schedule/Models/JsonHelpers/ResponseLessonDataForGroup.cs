using Newtonsoft.Json;

namespace Schedule.Models.JsonHelpers
{
    public class ResponseLessonDataForGroup : ResponseLessonData
    {
        [JsonProperty("group_id")]
        public long GroupId { get; set; }      
    }
}
