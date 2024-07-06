export interface Data {
    current: CurrentWeather,
    dataList: OpenWeatherData
}

export interface OpenWeatherData {
    list: WeatherList[];
}

export interface CurrentWeather{
    name: string,
    weather: Weather[];
    sys: Sys;
    main: Main;
}

export interface WeatherList {
    main: Main;
    weather: Weather[];
    dt_txt: string;
}

export interface Main {
    temp: number;
    feels_like: number;
    temp_min: number;
    temp_max: number;
    pressure: number;
    sea_level: number;
    grnd_level: number;
    humidity: number;
    temp_kf: number;
}

export interface Weather {
    id: number;
    main: string;
    description: string;
    icon: string;
}

export interface Sys {
    country: string;
}