
using DependencyInjectionAndServiceLifetimes.Interfaces;
using DependencyInjectionAndServiceLifetimes.Services;

namespace HandsOnDependencyInjection_Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddTransient<IExampleTransientService, ExampleTransientService>();
            builder.Services.AddScoped<IExampleScopedService, ExampleScopedService>();
            builder.Services.AddSingleton<IExampleSingletonService, ExampleSingletonService>();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
