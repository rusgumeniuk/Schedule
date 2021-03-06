﻿using Newtonsoft.Json;

namespace Schedule.Models.JsonHelpers
{
    public class ResponseRootSingeData<T> : ResponseRoot<T> where T : IResponseData
    {
        [JsonProperty("data")]
        public T Data { get; set; }
    }
}
