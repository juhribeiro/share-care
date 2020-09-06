using System.Text.Json.Serialization;

namespace ShareCare.Model.Models
{
    public class SpecialtyRecord
    {
        [JsonPropertyName("especialidade_descricao")]
        public string SpecialtyDescription { get; set; }
    }
}
