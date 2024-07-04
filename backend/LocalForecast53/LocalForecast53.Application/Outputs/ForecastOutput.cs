namespace LocalForecast53.Application.Outputs
{
    public class ForecastOutput
    {
        public string City { get; set; }
        public string Country { get; set; }
        public List<WeatherForecast> List { get; set; } = new List<WeatherForecast>();
    }

    public class WeatherForecast
    {
        public string Temperature { get; set; }
        public string MinimumTemperature { get; set; }
        public string MaximumTemperature { get; set; }
        public string Humidity { get; set; }
        public string? Weather { get; set; }
        public string? WeatherDescription { get; set; }
    }
}
