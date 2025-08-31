using BuberDinner.Application;
using BuberDinner.Infrastructure;
using BuberDinner.Api;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    builder.Services
            .AddPresentation()
            .AddApplication()
            .AddInfrastructure(builder.Configuration);
}

var app = builder.Build();
{
    // Error Handling - Approach 2 & 3
    app.UseExceptionHandler("/Error");

    // Configure the HTTP request pipeline.
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}
