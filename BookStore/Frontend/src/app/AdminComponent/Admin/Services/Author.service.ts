import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IAuthor } from '../interfaces/IAuthor';

@Injectable({
  providedIn: 'root',
})
export class AuthorService {
  baseURL = environment.baseURL + '/api/authors';
  constructor(private httpClient: HttpClient) {}
  addAuthor(Name: string) {
    let formData = new FormData();
    formData.append('Name', Name);
    return this.httpClient.post<IAuthor>(this.baseURL, formData);
  }

  getAuthor(): Observable<IAuthor[]> {
    return this.httpClient.get<IAuthor[]>(this.baseURL);
  }

  deleteAuthor(id: number) {
    return this.httpClient.delete<IAuthor>(this.baseURL + '/' + id);
  }

  updateAuthor(author: IAuthor): Observable<IAuthor> {
    return this.httpClient.put<IAuthor>(this.baseURL, author);
  }
}
