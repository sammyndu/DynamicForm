using DynamicForm.Application.Common.Exceptions;
using DynamicForm.Application;
using Serilog;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using DynamicForm.Domain.Common.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddServices(builder.Configuration);
builder.Host.UseSerilog();
builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options => {

        //options.SuppressModelStateInvalidFilter = true;
        options.InvalidModelStateResponseFactory = actionContext =>
        {
            //var modelState = actionContext.ModelState.Values;
            var error = new ErrorResponse
            {
                ResponseCode = 400,
                ResponseMessage = actionContext.ModelState.Values.Select(x => x.Errors.FirstOrDefault().ErrorMessage).First()
            };
            return new BadRequestObjectResult(error);
        };

    }).AddNewtonsoftJson()
           .AddJsonOptions(options =>
           {
               options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
           }); ;
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
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
