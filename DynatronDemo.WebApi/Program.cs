using DynatronDemo.WebApi.Application.Commands;
using DynatronDemo.WebApi.Application.Interfaces;
using DynatronDemo.WebApi.Infrastructure.Data;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace DynatronDemo.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddInstructure(builder.Configuration);

			//builder.Services.AddValidatorsFromAssembly(Assembly.GetAssembly(typeof(IApplicationDbContext)));

			builder.Services.AddControllers()
			   .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<IApplicationDbContext>()).ConfigureApiBehaviorOptions(options =>
			   {
				   options.InvalidModelStateResponseFactory = context =>
				   {
					   var problemDetails = new CommandResult
					   {
						   TraceId = Guid.NewGuid().ToString(),
					   };

					   problemDetails.Errors.Add("Bad Request");

					   return new BadRequestObjectResult(problemDetails)
					   {
						   ContentTypes = { "application/problem+json" }
					   };
				   };
			   }).AddJsonOptions(options =>
			   {
				   options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
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

				using var scope = app.Services.CreateScope();
				var services = scope.ServiceProvider;
				try
				{
					SeedData.SeedCustomersAsync(services).Wait();
				}
				catch (Exception ex)
				{
					Console.WriteLine($"Error seeding data: {ex.Message}");
				}
			}

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
