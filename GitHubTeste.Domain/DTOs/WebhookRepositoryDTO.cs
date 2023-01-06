using GitHubTeste.Data.Responses;
using Newtonsoft.Json;

namespace GitHubTeste.Data.DTOs
{
    public class WebhookRepositoryDTO
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("active")]
        public bool Active { get; set; }
        [JsonProperty("events")]
        public List<string> Events { get; set; }
        [JsonProperty("config")]
        public Config Config { get; set; }
    }
}
