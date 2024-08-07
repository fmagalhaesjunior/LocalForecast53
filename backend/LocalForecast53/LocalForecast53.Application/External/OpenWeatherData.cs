﻿namespace LocalForecast53.Application.External
{
    public class OpenWeatherData
    {
        public List<WeatherList> List { get; set; }
    }

    public class WeatherList
    {
        public Main Main { get; set; }
        public List<Weather> Weather { get; set; }
        public string Dt_Txt { get; set; }
    }

    public class Main
    {
        public double Temp { get; set; }
        public double Feels_Like { get; set; }
        public double Temp_Min { get; set; }
        public double Temp_Max { get; set; }
        public int Pressure { get; set; }
        public int Sea_Level { get; set; }
        public int Grnd_Level { get; set; }
        public int Humidity { get; set; }
        public double Temp_Kf { get; set; }
    }

    public class Weather
    {
        public int Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
}
