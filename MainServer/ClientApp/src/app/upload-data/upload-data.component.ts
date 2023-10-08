import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup, FormGroupDirective, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { UploadFilesService } from 'src/app/services/upload-files.service';
import { HttpEventType, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-upload-data',
  templateUrl: './upload-data.component.html',
  styleUrls: ['./upload-data.component.css']
})
export class UploadDataComponent
{
  selectedFiles: FileList;
  fileInfos: Observable<any>;
  public myForm: FormGroup;
  constructor(private uploadService: UploadFilesService, private formBuilder: FormBuilder)
  {
    this.myForm = this.formBuilder.group
      (
        {
          excelFiles: ['', Validators.required]
        }
      );
  }

  selectFiles(event) {
    this.selectedFiles = event.target.files;
  }

  uploadFiles() {
    for (let i = 0; i < this.selectedFiles.length; i++) {
      this.upload(i, this.selectedFiles[i]);
    }
    this.myForm.get('excelFiles')?.reset();
  }

  upload(idx, file) {
    this.uploadService.upload(file).subscribe();
    
  }
}
