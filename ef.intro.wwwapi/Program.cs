using ef.intro.wwwapi.Context;
using ef.intro.wwwapi.Data;
using ef.intro.wwwapi.EndPoint;
using ef.intro.wwwapi.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ILibraryRepository, LibraryRepository>();
builder.Services.AddDbContext<LibraryContext>();

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

app.ConfigureAuthorApi();

app.ConfigureBooksApi();

app.ConfigurePublisherApi();

app.Seed();

app.Run();
