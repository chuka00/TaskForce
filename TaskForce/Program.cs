using Microsoft.EntityFrameworkCore;
using TaskForce.DAL.Context;

namespace TaskForce
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<TFDbContext>(opts =>
            {
                // this will only work if there's a section called ConnectionStrings on the appSettings
                // var defaultConn = builder.Configuration.GetConnectionString("DefaultConn");

                var defaultConn = builder.Configuration.GetSection("ConnectionString")["DefaultConnection"];

                opts.UseSqlServer(defaultConn);

            });


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


            app.MapControllers();

            app.Run();
        }
    }
}