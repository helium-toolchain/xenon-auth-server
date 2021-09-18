namespace Xenon.Auth.Server;

using System.Text.Json;

public class XenonAuthServer
{
	public static String MsaApplicationId { get; private set; } = null!;

	public static void Main(String[] args)
	{
		WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

		// Add services to the container.

		_ = builder.Services.AddControllers();

		WebApplication? app = builder.Build();

		_ = app.UseHttpsRedirection();

		_ = app.UseAuthorization();

		_ = app.MapControllers();

		StreamReader reader = new("./authconfig.json");
		AuthConfig config = JsonSerializer.Deserialize<AuthConfig>(reader.ReadToEnd())!;
		reader.Close();

		MsaApplicationId = config.MsaApplicationId;

		app.Run();
	}
}
