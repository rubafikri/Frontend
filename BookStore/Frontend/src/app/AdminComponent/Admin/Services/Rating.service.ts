import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IAuthor } from '../interfaces/IAuthor';
import { IBookReview } from '../interfaces/IBookReview';

@Injectable({
  providedIn: 'root',
})
export class RatingService {
  baseURL = environment.baseURL + '/api/bookReviews';
  constructor(private httpClient: HttpClient) {}
  addBookReview(
    appUserId: string,
    bookId: number,
    comment: string,
    rate: number
  ) {
    let formData = new FormData();
    formData.append('appUserId', appUserId);
    formData.append('bookId', bookId.toString());
    formData.append('comment', comment);
    formData.append('rate', rate.toString());
    return this.httpClient.post(this.baseURL, formData);
  }

  getBookReview(bookId: number) {
    return this.httpClient.get(`${this.baseURL}/${bookId}`);
  }
  getAllReview(): Observable<IBookReview[]> {
    return this.httpClient.get<IBookReview[]>(this.baseURL);
  }
}
