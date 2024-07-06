using LocalForecast53.Application;
using LocalForecast53.Application.Mapping;
using LocalForecast53.Shared.Configuration;

var builder = WebApplication.CreateBuilder(args);

//Add Environment Variables
builder.Configuration.AddEnvironmentVariables();

builder.Services.Configure<ExternalApiSettings>(options =>
{
    options.ApiKey = Environment.GetEnvironmentVariable("EXTERNAL_API_KEY");
    options.Url = Environment.GetEnvironmentVariable("EXTERNAL_API_URL");
});

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
.WithOrigins("http://localhost"));

app.UseAuthorization();

app.MapControllers();

app.Run();
