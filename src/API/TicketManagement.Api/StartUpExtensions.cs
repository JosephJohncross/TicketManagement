using Microsoft.OpenApi.Models;
using TicketManagement.Api.Middleware;
using TicketManagement.Api.Services;
using TicketManagement.Api.Utility;
using TicketManagement.Application.Contracts;
using TicketManagement.Identity;

namespace TicketManagement.Api
{
    public static class StartUpExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {

            // swagger support
            AddSwagger(builder.Services);

            builder.Services.AddApplicationServices();
            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddPersistenceServices(builder.Configuration);
            builder.Services.AddIdentityServices(builder.Configuration);

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<ILoggedInUserService, LoggedInUserService>();
            builder.Services.AddControllers();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ticket Management API");
                });
            }

            app.UseHttpsRedirection();

            // app.UseRouting();

            app.UseAuthentication();

            app.UseCustomExceptionHandler();

            app.UseCors("Open");

            app.UseAuthorization();

            app.MapControllers();

            return app;
        }

        public static void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Ticket Management API",
                    Description = "This Api provides enpoints for a complete online ticket management, providing functionalities such as ticket sales, event export to csv and other functionalities"
                });

                c.OperationFilter<FileResultContentTypeOperationFilter>();
            });
        }

        public static async Task ResetDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            try
            {
                var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
                if (context != null)
                {
                    await context.Database.EnsureDeletedAsync();
                    await context.Database.MigrateAsync();
                }
            }
            catch (System.Exception)
            {
                // Add logging here later
            }
        }
    }
}