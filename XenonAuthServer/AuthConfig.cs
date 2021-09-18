namespace Xenon.Auth.Server;

using System.Text.Json.Serialization;

public class AuthConfig
{
	[JsonPropertyName("msaApplicationId")]
	public String MsaApplicationId { get; set; } = null!;
}
