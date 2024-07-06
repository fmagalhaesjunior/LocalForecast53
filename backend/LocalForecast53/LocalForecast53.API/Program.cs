using LocalForecast53.Application.Mapping;
using LocalForecast53.Shared.Configuration;
using LocalForecast53.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<DatabaseConfiguration>(builder.Configuration.GetSection("DatabaseConfiguration"));
DatabaseConfiguration? databaseConfiguration = builder.Configuration.GetSection("DatabaseConfiguration").Get<DatabaseConfiguration>();
builder.Services.AddSingleton(databaseConfiguration);

builder.Services.AddCustomServices();

//Mapper
builder.Services.AddAutoMapper(typeof(ForecastMapper));

builder.Services.AddCors();
builder.Services.AddControllers();
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
app.UseCors(x =>
x.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader()
.WithOrigins("http://localhost:4200"));

app.UseAuthorization();

app.MapControllers();

app.Run();
