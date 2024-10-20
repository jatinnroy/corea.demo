using Newtonsoft.Json;

namespace demo.Database.Responses
{
    public class ResponseModel
    {
        [JsonProperty("message", NullValueHandling = NullValueHandling.Include)]
        public string Message { get; set; }

        [JsonProperty("data", NullValueHandling = NullValueHandling.Include)]
        public object Data { get; set; }

        public bool Status { get; set; }
    }
}
