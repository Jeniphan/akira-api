using System.Text.Json.Serialization;

namespace akiira_api.models
{
  [JsonConverter(typeof(JsonStringEnumConverter))]
  public enum akiiraClass
  {
    Knight = 1,
    Mage = 2,
    Cleric = 3,
  }
}