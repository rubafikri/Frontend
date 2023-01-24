import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject, tap } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IBook } from '../interfaces/IBook';

@Injectable({
  providedIn: 'root',
})
export class BookService {
  baseURL = environment.baseURL + '/api/books';
  private refresh = new Subject<void>();
  constructor(private httpClient: HttpClient) {}

  get REfresh() {
    return this.refresh;
  }
  addBook(
    price: number,
    name: string,
    discount: number,
    about: string,
    publisherId: number,
    authorId: number,
    CategoryId: number,
    pageCount: number,
    publishYear: number,
    Image: File
  ) {
    let formData = new FormData();
    formData.append('price', price.toString());
    formData.append('name', name.toString());
    formData.append('discount', discount.toString());
    formData.append('about', about.toString());
    formData.append('publisherId', publisherId.toString());
    formData.append('authorId', authorId.toString());
    formData.append('CategoryId', CategoryId.toString());
    formData.append('pageCount', pageCount.toString());
    formData.append('publishYear', publishYear.toString());
    formData.append('Image', Image);
    return this.httpClient.post<IBook>(this.baseURL, formData, {
      reportProgress: true,
      observe: 'events',
    });
  }

  getBooks(): Observable<IBook[]> {
    return this.httpClient.get<IBook[]>(this.baseURL);
  }
  getBookById(id: number): Observable<IBook> {
    return this.httpClient.get<IBook>(`${this.baseURL}/${id}`);
  }

  deleteBook(id: number) {
    return this.httpClient.delete<IBook>(this.baseURL + '/' + id);
  }
  onSearchBook(searchKey: string) {
    return this.httpClient
      .get<IBook[]>(`${this.baseURL}/?searchKey=${searchKey}`)
      .pipe(
        tap(() => {
          this.refresh.next();
        })
      );
  }
}
