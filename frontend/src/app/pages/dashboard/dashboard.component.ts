import { Component, ViewEncapsulation, ViewChild, OnInit } from '@angular/core';
import { InputData } from 'src/app/models/input-data';
import { ApiService } from 'src/app/services/api.service';
import { GeolocationService } from 'src/app/services/geolocation.service';


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  encapsulation: ViewEncapsulation.None,
})
export class AppDashboardComponent implements OnInit {
  latitude: number = 0;
  longitude: number = 0;
  dataCurrent: any;
  dataList: any;
  displayedColumns: string[] = ['datetime', 'temp', 'tempMin', 'tempMax'];


  constructor(private apiService: ApiService, private geolocationService: GeolocationService) { }

  ngOnInit(): void {
    this.getCurrentLocation();
  }

  getCurrentLocation(): void {
    this.geolocationService.getCurrentPosition()
      .then(position => {
        this.latitude = position.coords.latitude;
        this.longitude = position.coords.longitude;
        console.log(`Latitude: ${this.latitude}, Longitude: ${this.longitude}`);
        const input: InputData = {
          latitude: this.latitude,
          longitude: this.longitude,
          unit: 0
        };
        this.apiService.getWeatherForecast(input).subscribe({
          next: (apiData: any) => {
            this.dataCurrent = apiData.result.current;
            this.dataList = apiData.result.dataList;
          }
        });
      })
      .catch(error => {
        console.error('Erro ao obter localização atual.', error);
      });
  }
}
