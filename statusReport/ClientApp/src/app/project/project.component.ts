import { Component, OnInit,Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-project',
  templateUrl: './project.component.html',
  styleUrls: ['./project.component.css']
})

export class ProjectComponent implements OnInit {

    public projects:Project[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    debugger;
    http.get<Project[]>(baseUrl + 'api/SampleData/GetProjects').subscribe(result => {
      debugger;
      this.projects = result;
    }, error => console.error(error));
  
 }

  ngOnInit() {
  }

}

interface Project {
  projectname: string;
  customername: string;
 
}
