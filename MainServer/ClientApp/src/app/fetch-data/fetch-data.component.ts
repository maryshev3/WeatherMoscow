import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public weathers: Weather[] = [];

  constructor(http: HttpClient) {
    http.get<Weather[]>('https://localhost:7145/WeatherForecast?PageNum=2').subscribe(result => {
      this.weathers = result;
    }, error => console.error(error));
  }
}

interface Weather {
  date: string;
  time: string;
  temperature: number;
  humidity: number;
  dewPoint : number;
  presure: number;
  windDirection: string;
  windSpeed: number;
  cloudy: number;
  highBorderCloudy: number;
  horizontalVisibility: number;
}
