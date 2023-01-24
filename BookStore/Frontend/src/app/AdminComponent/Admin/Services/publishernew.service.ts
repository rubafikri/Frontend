import { HttpClient } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';
import { IPublisher } from '../interfaces/IPublisher';

@Injectable({
  providedIn: 'root',
})
export class PublishernewService {
  baseURL = environment.baseURL + '/api/publishers';

  constructor(private httpClient: HttpClient) { }

  addPublisher(name: string, Image: File) {
    let formData = new FormData();
    formData.append('Name', name);
    formData.append('Image', Image);
    return this.httpClient.post<IPublisher>(this.baseURL, formData, {
      reportProgress: true,
      observe: 'events',
    });
  }
  getPublishers(): Observable<IPublisher[]> {
    return this.httpClient.get<IPublisher[]>(this.baseURL);
  }

  onSearchPublisher(searchKey: string) {
    return this.httpClient.get<IPublisher[]>(
      `${this.baseURL}/?serachKey=${searchKey}`
    );
  }
  UpdatePublishers(pub: IPublisher): Observable<IPublisher> {
    return this.httpClient.put<IPublisher>(this.baseURL, pub);
  }

  deletePublisher(id: number) {
    return this.httpClient.delete<IPublisher>(this.baseURL + '/' + id);
  }

  upPublisher(name: string, Logo: File) {
    let formData = new FormData();
    formData.append('Name', name);
    formData.append('Logo', Logo);
    return this.httpClient.put<IPublisher>(this.baseURL, formData, {
      reportProgress: true,
      observe: 'events',
    });
  }
}
