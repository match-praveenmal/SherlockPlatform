using System.Text.Json.Serialization;

namespace Server.Util;
  
public class SherlockPipelinesSecretData
{
    public static string PATH = "Sherlock/Pipelines/appsettings/keys";
    [JsonPropertyName("key")]
    public string Key { get; set; }
}
 