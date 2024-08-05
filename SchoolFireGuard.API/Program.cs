using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SchoolFireGuard.API.DAL;

namespace SchoolFireGuard.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Get the IWebHostEnvironment instance
            var env = builder.Environment;

            // Get the connection string relative path from configuration
            var relativeDbPath = "Database/schoolFireGuard.accdb";
            var absoluteDbPath = Path.Combine(env.ContentRootPath, relativeDbPath);

            // Configure logging
            using var loggerFactory = LoggerFactory.Create(loggingBuilder =>
            {
                loggingBuilder.AddConsole();
            });

            var logger = loggerFactory.CreateLogger<Program>();
            logger.LogInformation($"ContentRootPath: {env.ContentRootPath}");
            logger.LogInformation($"Database Path: {absoluteDbPath}");

            var connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={absoluteDbPath}";

            // Store the connection string in configuration for access by DAL
            builder.Configuration["ConnectionStrings:cs"] = connectionString;

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyPolicy",
                    builder =>
                    {
                        builder.SetIsOriginAllowed(alow => true)
                               .AllowAnyMethod()
                               .AllowAnyHeader()
                               .AllowCredentials();
                    });
            });

            // Register ClassDAL as a service
            builder.Services.AddScoped<ClassDAL>(provider =>
            {
                var configuration = provider.GetRequiredService<IConfiguration>();
                var cs = configuration.GetConnectionString("cs");
                return new ClassDAL(cs);
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("MyPolicy");
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
