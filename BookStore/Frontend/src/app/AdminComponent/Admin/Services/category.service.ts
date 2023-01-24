import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';
import { ICategory } from '../interfaces/ICategory';

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  baseURL = environment.baseURL + '/api/categories';
  constructor(private httpClient: HttpClient) {}
  addCategory(Name: string) {
    let formData = new FormData();
    formData.append('Name', Name);
    return this.httpClient.post<ICategory>(this.baseURL, formData);
  }
  getCategory(): Observable<ICategory[]> {
    return this.httpClient.get<ICategory[]>(this.baseURL);
  }

  deleteCategory(id: number) {
    return this.httpClient.delete<ICategory>(this.baseURL + '/' + id);
  }

  updateCategory(cat: ICategory): Observable<ICategory> {
    return this.httpClient.put<ICategory>(this.baseURL, cat);
  }
}
