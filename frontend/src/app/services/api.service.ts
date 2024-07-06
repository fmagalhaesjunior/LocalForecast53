import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Data } from '../models/data';
import { Observable } from 'rxjs';
import { InputData } from '../models/input-data';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  baseUrl: string = 'http://localhost:5037/api/';
  
  constructor(private http: HttpClient) { }

  getWeatherForecast(input: InputData): Observable<Data> {
    return this.http.post<Data>(this.baseUrl.concat('WeatherForecast'), input);
  }
}
