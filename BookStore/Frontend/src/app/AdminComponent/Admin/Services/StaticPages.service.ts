import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IStaticPages } from '../interfaces/IstaticPages';

@Injectable({
  providedIn: 'root',
})
export class StaticPagesService {
  baseURL = environment.baseURL + '/api/staticPages';
  constructor(private httpClient: HttpClient) { }
  addStaticPage(pageName: string, details: string) {
    let formData = new FormData();
    formData.append('pageName', pageName);
    formData.append('details', details);
    return this.httpClient.post<IStaticPages>(this.baseURL, formData);
  }

  getStaticPage(): Observable<IStaticPages[]> {
    return this.httpClient.get<IStaticPages[]>(this.baseURL);
  }

  getStaticPages(pageName: string): Observable<IStaticPages[]> {
    return this.httpClient.get<IStaticPages[]>(
      `${this.baseURL}/?PageName=${pageName}`
    );
  }

  deleteStatic(id: number) {
    return this.httpClient.delete<IStaticPages>(this.baseURL + '/' + id);
  }

  updateStatic(staticPages: IStaticPages): Observable<IStaticPages> {
    return this.httpClient.put<IStaticPages>(this.baseURL, staticPages);
  }
}
