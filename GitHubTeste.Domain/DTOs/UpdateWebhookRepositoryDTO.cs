using GitHubTeste.Data.Responses;
using Newtonsoft.Json;

namespace GitHubTeste.Data.DTOs
{
    public class UpdateWebhookRepositoryDTO
    {
        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("add_events")]
        public List<string> AddEvents { get; set; }

        [JsonProperty("config")]
        public Config Config { get; set; }
    }
}
