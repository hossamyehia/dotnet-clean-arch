using BuberDinner.Application;
using BuberDinner.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using BuberDinner.Api.Common.Errors;
// using BuberDinner.Api.Filters;
// using BuberDinner.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    builder.Services
            .AddApplication()
            .AddInfrastructure(builder.Configuration);

    // Error Handling - Approach 2 "ProblemDetails"
    // it overrides the default ProblemDetailsFactory with our custom implementation
    builder.Services.AddSingleton<ProblemDetailsFactory, BuberDinnerProblemDetailsFactory>();

    // Error Handling - Approach 3 "Filter"
    // builder.Services.AddControllers(options =>
    // {
    //     options.Filters.Add<ErrorHandlingFilterAttribute>();
    // });
    builder.Services.AddControllers();
}

var app = builder.Build();
{
    // Error Handling - Approach 1 "Middleware"
    // app.UseMiddleware<ErrorHandlingMiddleware>();
    
    // Error Handling - Approach 2 & 3
    app.UseExceptionHandler("/Error");

    // Configure the HTTP request pipeline.
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
