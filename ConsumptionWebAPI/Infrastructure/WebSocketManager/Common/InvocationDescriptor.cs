using Newtonsoft.Json;

namespace ConsumptionWebAPI.Infrastructure.WebSocketManager.Common
{
    public class InvocationDescriptor
    {
        [JsonProperty("methodName")]
        public string MethodName { get; set; }

        [JsonPropertyAttribute("arguments")]
        public object[] Arguments { get; set; }
    }
}