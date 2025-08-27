using BuberDinner.Application;
using BuberDinner.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using BuberDinner.Api.Common.Errors;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    builder.Services
            .AddApplication()
            .AddInfrastructure(builder.Configuration);

    // it overrides the default ProblemDetailsFactory with our custom implementation
    builder.Services.AddSingleton<ProblemDetailsFactory, BuberDinnerProblemDetailsFactory>();
    builder.Services.AddControllers();
}

var app = builder.Build();
{
    // Error Handling - Approach 2 & 3
    app.UseExceptionHandler("/Error");

    // Configure the HTTP request pipeline.
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
