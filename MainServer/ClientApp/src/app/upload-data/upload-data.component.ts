import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-upload-data',
  templateUrl: './upload-data.component.html',
  styleUrls: ['./upload-data.component.css']
})
export class UploadDataComponent {

  public chosenFiles: File[] | null = null;

  sendFiles() {
    this.http.post("https://localhost:7145/WeatherApi", { body: this.chosenFiles }).subscribe();
  }
  constructor(public http: HttpClient) { }
}
