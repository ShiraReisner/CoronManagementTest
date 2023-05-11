//using CoronaManagement.DAL;
//using CoronaManagement.DAL.Interfaces;
using CoronaManagement.BL;
using CoronaManagement.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CoronaManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<IPatientDAL, PatientDAL>();
            builder.Services.AddScoped<IPatientBL, PatientBL>();
            builder.Services.AddDbContext<CoronaPatientContext>();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("_myAllowSpecificOrigins",
                    builder =>
                    {
                        builder.WithOrigins("http://example.com", "http://localhost:4200");
                    });
            });
            //builder.Services.AddCors(options => { options.AddPolicy("_myAllowSpecificOrigins")}, policy => { policy.With });
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors(builder =>
       builder.WithOrigins("http://localhost:4200")
           .AllowAnyMethod()
           .AllowAnyHeader()
           .AllowCredentials()
   );
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
