namespace LocalForecast53.Application.Inputs
{
    public enum Units
    {
        Celsius,
        Fahrenheit
    }

    public class ForecastInput
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public Units Unit { get; set; }
    }
}
