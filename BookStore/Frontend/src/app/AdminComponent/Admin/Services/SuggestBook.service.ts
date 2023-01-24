import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IBookSuggestion } from '../interfaces/IBookSuggestions';
import { IStaticPages } from '../interfaces/IstaticPages';

@Injectable({
  providedIn: 'root',
})
export class SuggestBookService {
  baseURL = environment.baseURL + '/api/bookSuggestions';
  constructor(private httpClient: HttpClient) {}
  addBookSuggestions(
    bookName: string,
    email: string,
    publisherName: string,
    authorName: string,
    notes: string
  ) {
    let formData = new FormData();
    formData.append('bookName', bookName);
    formData.append('email', email);
    formData.append('publisherName', publisherName);
    formData.append('authorName', authorName);
    formData.append('notes', notes);
    return this.httpClient.post<IBookSuggestion>(this.baseURL, formData);
  }

  getBookSuggestions(): Observable<IBookSuggestion[]> {
    return this.httpClient.get<IBookSuggestion[]>(this.baseURL);
  }

  onupdateReadStatus(Id: number) {
    return this.httpClient.put(
      `${environment.baseURL + '/api/bookSuggestions'}/${Id}/isRead`,
      {}
    );
  }
}
