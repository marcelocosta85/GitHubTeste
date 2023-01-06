using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubTeste.Data.Responses
{
    public class Config
    {
        [JsonProperty("content_type")]
        public string ContentType { get; set; }

        [JsonProperty("insecure_ssl")]
        public string InsecureSsl { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
