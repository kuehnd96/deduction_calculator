using DK.DeductionCalculator.Core;
using DK.DeductionCalculator.Core.Interfaces;

const string AllowAngularAppOriginPolicy = "AllowAngularApp";

var builder = WebApplication.CreateBuilder(args);
var angularBaseUrl = builder.Configuration["FrontEndBaseUrl"];

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowAngularAppOriginPolicy,
                      builder =>
                      {
                          // TODO: Put this value in the app settings
                          builder.WithOrigins(angularBaseUrl)
                              .AllowAnyMethod()
                              .AllowAnyHeader();
                      });
});

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IBenefitDeductionCalculator, ContrivedBenefitDeductionCalculator>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors(AllowAngularAppOriginPolicy);

app.UseAuthorization();

app.MapControllers();

app.Run();
