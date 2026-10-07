using System.Text.Json.Serialization;

namespace ConsumerAdviceApi
{
    public class Slip
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("advice")]
        public string Advice { get; set; } = string.Empty;
    }

    public class AdviceResponse
    {
        [JsonPropertyName("slip")]
        public Slip Slip { get; set; } = new Slip();
    }
}