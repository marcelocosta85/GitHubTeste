using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubTeste.Data.DTOs
{
    public class RepositoryDTO
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("homepage")]
        public string Homepage { get; set; }

        [JsonProperty("private")]
        public bool Private { get; set; }

        [JsonProperty("is_template")]
        public bool IsTemplate { get; set; }
    }
}
