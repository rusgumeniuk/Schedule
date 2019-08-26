using Newtonsoft.Json;
using System;

namespace Schedule.Models.JsonHelpers
{
    public abstract class ResponseLessonData : IResponseData
    {
        [JsonProperty("lesson_id")]
        public long Id { get; set; }
        [JsonProperty("lesson_full_name")]
        public string FullName { get; set; }
        [JsonProperty("lesson_name")]
        public string LessonName { get; set; }

        [JsonProperty("lesson_type")]
        public string LessonType { get; set; }

        [JsonProperty("lesson_week")]
        public byte LessonWeek { get; set; }
        [JsonProperty("day_number")]
        public byte DayNumber { get; set; }
        [JsonProperty("day_name")]
        public string DayName { get; set; }
        [JsonProperty("lesson_number")]
        public byte LessonNumber { get; set; }        
        

        [JsonProperty("time_start")]
        public DateTimeOffset TimeStart { get; set; }
        [JsonProperty("time_end")]
        public DateTimeOffset TimeEnd { get; set; }

        [JsonProperty("rate")]
        public double Rate { get; set; }

        [JsonProperty("lesson_room")]
        public string LessonRoom { get; set; }
        [JsonProperty("rooms")]
        public ResponseRoomData[] Rooms { get; set; }
        [JsonProperty("teacher_name")]
        public string TeacherName { get; set; }
        [JsonProperty("teachers")]
        public ResponseTeacherData[] Teachers { get; set; }
    }
}
