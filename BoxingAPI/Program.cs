
using BoxingAPI.Data;
using BoxingAPI.Extensions;
using Microsoft.EntityFrameworkCore;
using System;

namespace BoxingAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<BoxingDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("BoxingDbConnectionString"));
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyCors", builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });

            builder.Services.RegisterDependancies();

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

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("MyCors");

            app.MapControllers();

            app.Run();
        }
    }
}
