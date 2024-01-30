using AugustaGourmet.Api.Application;
using AugustaGourmet.Api.Infrastructure;
using AugustaGourmet.Api.Persistence;
using AugustaGourmet.Api.WebAPI.Extensions;

using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddApplicationServices();
    builder.Services.AddInfrastructureServices(builder.Configuration);
    builder.Services.AddPersistenceServices(builder.Configuration);

    builder.Services.AddCors(options =>
    {
        options.AddPolicy("all", builder => builder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
    });

    builder.Services.AddControllers();
    builder.Services.AddSingleton<ProblemDetailsFactory, CustomProblemDetailsFactory>();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddSwaggerGen(opt =>
    {
        opt.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Augusta Gourmet API",
            Version = "v1",
            Description = "An ASP.NET Core Web API for managing the restaurant applications.",
        });
    });

}

var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(opt =>
        {
            opt.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API v1");
            opt.RoutePrefix = string.Empty; // Set the Swagger UI at the root URL
            opt.EnableTryItOutByDefault();
            opt.EnableFilter();
            opt.DisplayRequestDuration();
            opt.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
        });
    }

    //app.UseMiddleware<CustomExceptionHandlerMiddleware>();
    app.UseExceptionHandler("/error");

    app.UseHttpsRedirection();

    app.UseCors("all");

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}