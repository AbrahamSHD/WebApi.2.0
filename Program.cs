using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SchoolsWebApi.Data;
using SchoolsWebApi.Repositories;
using SchoolsWebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddSingleton(new ExcelDataReader("Data/Schools.xlsx"));
builder.Services.AddSingleton<SchoolRepository>();
builder.Services.AddScoped<SchoolService>();
builder.Services.AddControllers();

var app = builder.Build();

app.UseRouting();
app.MapControllers();
app.Run();
