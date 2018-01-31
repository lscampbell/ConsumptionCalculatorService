using Newtonsoft.Json;

namespace EnergyBuyer.Consumption.API.WebSocketManager.Common
{
    public class InvocationDescriptor
    {
        [JsonProperty("methodName")]
        public string MethodName { get; set; }

        [JsonPropertyAttribute("arguments")]
        public object[] Arguments { get; set; }
    }
}