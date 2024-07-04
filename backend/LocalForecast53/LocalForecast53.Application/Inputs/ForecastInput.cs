namespace LocalForecast53.Application.Inputs
{
    public enum Units
    {
        Celsius,
        Fahrenheit
    }

    public class ForecastInput
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public Units Unit { get; set; }
    }
}
