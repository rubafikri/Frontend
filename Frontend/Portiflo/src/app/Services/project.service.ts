import { Injectable } from '@angular/core';
import { IProject } from '../Models/IProject';

@Injectable({
  providedIn: 'root',
})
export class ProjectService {
  project: IProject[] = [
    {
      projectName: 'New Project',
      projectImage: './assets/image0.jpg',
    },
    {
      projectName: 'New Project',
      projectImage: './assets/image1.jpg',
    },
    {
      projectName: 'New Project',
      projectImage: './assets/image3.jpg',
    },
    {
      projectName: 'New Project',
      projectImage: './assets/image4.png',
    },
    {
      projectName: 'New Project',
      projectImage: './assets/image5.jpg',
    },
  ];
  constructor() {}
  getProject() {
    return this.project;
  }
}
