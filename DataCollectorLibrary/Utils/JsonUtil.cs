using Newtonsoft.Json;

namespace DataCollectorLibrary.Utils
{
    public static class JsonUtil
    {
        public static string Serialize<T>(T payload)
        {
            return JsonConvert.SerializeObject(payload, Newtonsoft.Json.Formatting.None,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
        }

        public static T Deserialize<T>(string message)
        {
            return JsonConvert.DeserializeObject<T>(message);
        }
    }
}
