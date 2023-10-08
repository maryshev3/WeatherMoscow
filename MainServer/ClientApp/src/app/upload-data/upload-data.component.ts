import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { UploadFilesService } from 'src/app/services/upload-files.service';
import { HttpEventType, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-upload-data',
  templateUrl: './upload-data.component.html',
  styleUrls: ['./upload-data.component.css']
})
export class UploadDataComponent implements OnInit
{
  selectedFiles: FileList;
  fileInfos: Observable<any>;
  constructor(private uploadService: UploadFilesService) { }

  selectFiles(event) {
    this.selectedFiles = event.target.files;
    console.log(this.selectedFiles.length);
  }

  uploadFiles() {
    console.log(this.selectedFiles.length);
    for (let i = 0; i < this.selectedFiles.length; i++) {
      this.upload(i, this.selectedFiles[i]);
    }
  }

  upload(idx, file) {
    this.uploadService.upload(file).subscribe();
  }

  ngOnInit() {
  }
}
