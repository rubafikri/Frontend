import { HttpClient } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';
import { IPublisher } from '../interfaces/IPublisher';
import { IUserFav } from '../interfaces/IUserFav';

@Injectable({
  providedIn: 'root',
})
export class UserFavService {
  baseURL = environment.baseURL + '/api/userFav';

  constructor(private httpClient: HttpClient) {}

  AddToFavorite(bookFav: IUserFav) {
    return this.httpClient.post<IUserFav>(this.baseURL, bookFav);
  }
  getUserFav(): Observable<IUserFav[]> {
    return this.httpClient.get<IUserFav[]>(this.baseURL);
  }

  deleteFromFav(bookId: number) {
    return this.httpClient.delete<IUserFav>(`${this.baseURL}/${bookId}`);
  }
}
