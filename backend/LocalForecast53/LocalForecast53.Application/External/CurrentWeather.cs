namespace LocalForecast53.Application.External
{
    public class CurrentWeather
    {
        public string Name { get; set; }
        public List<Weather> Weather { get; set; }
        public Sys Sys { get; set; }
        public Main Main { get; set; }
    }

    public class Sys
    {
        public string Country { get; set; }
    }
}
