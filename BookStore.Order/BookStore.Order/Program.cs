using BookStore.Order.Repository;
using BookStore.Order.Repository.Interface;
using BookStore.Order.Repository.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace BookStore.Order
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddTransient<IOrderRepository, OrderRepository>();
            builder.Services.AddTransient<IBookService, BookService>();
            builder.Services.AddTransient<IUserService, UserService>();

            builder.Services.AddTransient<ICartService, CartService>();

            //Migration
            builder.Services.AddDbContext<ContextDB>(ops =>
            {
                ops.UseSqlServer(builder.Configuration["connectionString:BookStoreOrderDB"]);
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddHttpClient();

            //Swagger Authorization
            builder.Services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "Order", Version = "v1" });

                var securitySchema = new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Using Authorization",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer",

                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };

                option.AddSecurityDefinition("Bearer", securitySchema);
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                  {securitySchema , new[] { "Bearer" } }
                });
            });

            //JWt Token Service
            builder.Services.AddAuthentication(au =>
            {
                au.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                au.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(option =>
            {
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
                };
            });

            //IHttpClient Factory for Books
            var messagingBookUrl = builder.Configuration["BookBaseUrl"];

            builder.Services.AddHttpClient("BookApi", bookClient =>
            {
                bookClient.BaseAddress = new Uri(messagingBookUrl);
            });

            //IHttpClient Factory for User
            var messagingUserUrl = builder.Configuration["UserBaseUrl"];
            builder.Services.AddHttpClient("UserApi", userClient =>
            {
                userClient.BaseAddress = new Uri(messagingUserUrl);
            });

            //IHttpClient Factory for Cart
            var messagingCartUrl = builder.Configuration["CartBaseUrl"];
            builder.Services.AddHttpClient("CartApi", userClient =>
            {
                userClient.BaseAddress = new Uri(messagingCartUrl);
            });



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}