using Microsoft.AspNetCore.Cors.Infrastructure;

namespace Day2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(corsOptions =>
            {
                corsOptions.AddPolicy("wpfApp", corsPolicyBuilder =>
                {
                    corsPolicyBuilder.AllowAnyOrigin()//Allow all ports
                    .AllowAnyHeader()// any request header
                    .AllowAnyMethod();// any request method

                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("wpfApp"); // To Allow consumers from diffrent port 

            app.UseStaticFiles(); // To Allow Consumer Page in the same port

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}