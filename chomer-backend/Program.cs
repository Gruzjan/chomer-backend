using chomer_backend.Data;
using chomer_backend.Services.ChoreService;
using chomer_backend.Services.HouseService;
using chomer_backend.Services.HouseUserService;
using chomer_backend.Services.UserService;
using chomer_backend.Services.RewardService;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using chomer_backend.Models;

namespace chomer_backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //TODO: add auth; generic types

            // Add services to the container.
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

            //logger
            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .Enrich.FromLogContext()
                .CreateLogger();
            builder.Logging.ClearProviders();
            builder.Logging.AddSerilog(logger);

            //controllers
            builder.Services.AddControllers();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IHouseService, HouseService>();
            builder.Services.AddScoped<IChoreService, ChoreService>();
            builder.Services.AddScoped<IHouseUserService, HouseUserService>();
            builder.Services.AddScoped<IRewardService, RewardService>();
            //db
            builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            //automapper
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //identity
            builder.Services.AddIdentity<User, IdentityRole<int>>(options => { options.User.RequireUniqueEmail = true; options.Password.RequiredLength = 8; })
                .AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders();

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

            //app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}