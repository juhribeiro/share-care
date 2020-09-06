using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ShareCare.Model.Models
{
    public class SpeciltyResult
    {
        [JsonPropertyName("records")]
        public List<SpecialtyRecord> Records { get; set; }
    }
}
