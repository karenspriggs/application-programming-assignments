using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace ServiceLayer.Models
{
    public class UserModel
    {
        [JsonPropertyName("id")]
        public int PlayerID { get; set; }

        [JsonPropertyName("attempts")]
        public int PlayerAttempts { get; set; }

        [JsonPropertyName("userName")]
        public string PlayerName { get; set; } = string.Empty;

        [JsonPropertyName("uniformColor")]
        public string UniformColor { get; set; } = string.Empty;

        [JsonPropertyName("gemstoneName")]
        public string GemstoneName { get; set; } = string.Empty;

        [JsonPropertyName("towerHeight")]
        public int TowerHeight { get; set; }

        [JsonPropertyName("itemOneID")]
        public int ItemOneID { get; set; }

        [JsonPropertyName("itemTwoID")]
        public int ItemTwoID { get; set; }
    }
}
