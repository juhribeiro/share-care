using System.Text.Json.Serialization;

namespace ShareCare.Model.Models
{
    public class GetSpecialtyModels
    {
        [JsonPropertyName("result")]
        public SpeciltyResult Result { get; set; }
    }
}
