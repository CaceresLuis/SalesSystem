using SalesSystem.Api;
using SalesSystem.Api.Extension;
using SalesSystem.Api.Middlerware;
using SalesSystem.Modules.Images.Domain;
using SalesSystem.Shared.Aplication;
using SalesSystem.Shared.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplication().AddPresentation(builder.Configuration).AddInfrastructure(builder.Configuration);

builder.Services.Configure<FireBaseConfiguration>(builder.Configuration.GetSection("FireBase"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

app.UseExceptionHandler("/error");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseMiddleware<GlobalExceptionHandlingMiddelware>();

app.MapControllers();

app.Run();
