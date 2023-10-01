using Microsoft.EntityFrameworkCore;
using ProductManegementUsingCQRS.Repository.Context;
using ProductManegementUsingCQRS.Repository.Interface;
using ProductManegementUsingCQRS.Repository.Services;

namespace ProductManegementUsingCQRS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddTransient<IProductRepo, ProductRepo>();
            //Migration
            builder.Services.AddDbContext<ContextDB>(ops =>
            {
                ops.UseSqlServer(builder.Configuration["connectionString:ProductDB"]);
            });



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


            app.MapControllers();

            app.Run();
        }
    }
}