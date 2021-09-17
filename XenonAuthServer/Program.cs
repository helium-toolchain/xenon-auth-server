namespace Xenon.Auth.Server;

using Microsoft.OpenApi.Models;

public class XenonAuthServer {
	public static void Main(String[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		// Add services to the container.

		builder.Services.AddControllers();
		builder.Services.AddSwaggerGen(c =>
		{
			c.SwaggerDoc("v1", new() { Title = "xenon_auth_server", Version = "v1" });
		});

		var app = builder.Build();

		// Configure the HTTP request pipeline.
		if (app.Environment.IsDevelopment())
		{
			app.UseSwagger();
			app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "xenon_auth_server v1"));
		}

		app.UseHttpsRedirection();

		app.UseAuthorization();

		app.MapControllers();

		app.Run();
	}
}
