import { Component, Inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public weathers: Weather[] = [];

  public pageNum: number = 1;

  public chosenYear: number | null = 2010;
  public chosenMonth: number | null = 1;

  getData()
  {
    let param = new HttpParams().
      set("PageNum", this.pageNum).
      set("Year", Number(this.chosenYear)).
      set("Month", Number(this.chosenMonth));

    if (this.chosenYear != null) {
      if (this.chosenMonth != null)
        this.http.get<Weather[]>('https://localhost:7145/GetYearAndMonth', { params: param }).subscribe(result => {
          this.weathers = result;
        }, error => console.error(error));
      else
        this.http.get<Weather[]>('https://localhost:7145/GetYear', { params: param }).subscribe(result => {
          this.weathers = result;
        }, error => console.error(error));
    }
    else
    {
      if (this.chosenMonth != null)
        this.http.get<Weather[]>('https://localhost:7145/GetMonth', { params: param }).subscribe(result => {
          this.weathers = result;
        }, error => console.error(error));
      else
        this.http.get<Weather[]>('https://localhost:7145/WeatherAPI', { params: param }).subscribe(result => {
          this.weathers = result;
      }, error => console.error(error));
    }
  }

  constructor(public http: HttpClient)
  {
    this.getData();
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
