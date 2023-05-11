using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ServiceLayer.Models
{
    public class FighterModel
    {
        [JsonPropertyName("Name")]
        public string Name { get; set; }
        [JsonPropertyName("DebutGame")]
        public string DebutGame { get; set; }
        [JsonPropertyName("Origin")]
        public string Origin { get; set; }
        [JsonPropertyName("Weight")]
        public string Weight { get; set; }
        [JsonPropertyName("FinalSmashName")]
        public string FinalSmashName { get; set; }
    }
}
