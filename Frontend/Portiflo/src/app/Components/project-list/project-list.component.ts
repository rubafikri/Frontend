import { Component, OnInit } from '@angular/core';
import { IProject } from 'src/app/Models/IProject';
import { ProjectService } from 'src/app/Services/project.service';

@Component({
  selector: 'app-project-list',
  templateUrl: './project-list.component.html',
  styleUrls: ['./project-list.component.css'],
})
export class ProjectListComponent implements OnInit {
  project!: IProject[];
  constructor(private projectService: ProjectService) {}

  ngOnInit(): void {
    this.project = this.projectService.getProject();
  }
}
