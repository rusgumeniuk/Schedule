using Newtonsoft.Json;

namespace Schedule.Models.JsonHelpers
{
    public class ResponseRoomData : IResponseData
    {
        [JsonProperty("room_id")]
        public long Id { get; set; }

        [JsonProperty("room_name")]
        public string FullName { get; set; }

        [JsonProperty("room_latitude")]
        public string RoomLatitude { get; set; }

        [JsonProperty("room_longitude")]
        public string RoomLongitude { get; set; }
    }
}
