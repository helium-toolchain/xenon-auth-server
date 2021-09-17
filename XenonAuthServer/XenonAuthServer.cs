namespace Xenon.Auth.Server;

using System.Text.Json;

public class XenonAuthServer
{
	public static String MsaApplicationId { get; private set; } = null!;
	public static String? TokenSalt { get; private set; }

	public static void Main(String[] args)
	{
		WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

		// Add services to the container.

		_ = builder.Services.AddControllers();
		_ = builder.Services.AddSwaggerGen(c
			=> c.SwaggerDoc("v1", new() { Title = "xenon_auth_server", Version = "v1" }));

		WebApplication? app = builder.Build();

		// Configure the HTTP request pipeline.
		if (app.Environment.IsDevelopment())
		{
			_ = app.UseSwagger();
			_ = app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "xenon_auth_server v1"));
		}

		_ = app.UseHttpsRedirection();

		_ = app.UseAuthorization();

		_ = app.MapControllers();

		StreamReader reader = new("./authconfig.json");
		AuthConfig config = JsonSerializer.Deserialize<AuthConfig>(reader.ReadToEnd())!;
		reader.Close();

		MsaApplicationId = config.MsaApplicationId;
		TokenSalt = config.TokenSalt;

		app.Run();
	}
}
