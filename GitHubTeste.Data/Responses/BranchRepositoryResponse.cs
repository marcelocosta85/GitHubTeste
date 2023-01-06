using Newtonsoft.Json;

namespace GitHubTeste.Data.Responses
{
    public class BranchRepositoryResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("commit")]
        public Commit Commit { get; set; }

        [JsonProperty("protected")]
        public bool Protected { get; set; }

        [JsonProperty("protection")]
        public Protection Protection { get; set; }

        [JsonProperty("protection_url")]
        public string ProtectionUrl { get; set; }
    }
    public class Commit
    {
        [JsonProperty("sha")]
        public string Sha { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class Protection
    {
        [JsonProperty("required_status_checks")]
        public RequiredStatusChecks RequiredStatusChecks { get; set; }
    }

    public class RequiredStatusChecks
    {
        [JsonProperty("enforcement_level")]
        public string EnforcementLevel { get; set; }

        [JsonProperty("contexts")]
        public List<string> Contexts { get; set; }
    }    
}
