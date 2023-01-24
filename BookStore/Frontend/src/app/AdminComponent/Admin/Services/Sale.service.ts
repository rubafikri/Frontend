import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';
import { ISale } from '../interfaces/ISale';

@Injectable({
  providedIn: 'root',
})
export class SaleService {
  baseURL = environment.baseURL + '/api/sales';
  saleNumber: number;
  isBtn: boolean;
  isSold: number;

  constructor(private httpClient: HttpClient) {}
  addSale(
    appUserId: string,
    bookId: number,
    amount: number,
    totalPrice: number
  ) {
    let formData = new FormData();
    formData.append('appUserId', appUserId);
    formData.append('bookId', bookId.toString());
    formData.append('amount', amount.toString());
    formData.append('totalPrice', totalPrice.toString());
    console.log(formData);
    return this.httpClient.post<ISale>(this.baseURL, formData);
  }
  getSaleByUserId(appUserId: string): Observable<ISale[]> {
    return this.httpClient.get<ISale[]>(`${this.baseURL}/${appUserId}`);
  }

  getSales(): Observable<ISale[]> {
    return this.httpClient.get<ISale[]>(`${this.baseURL}`);
  }

  onupdateSaleStatus(Id: number) {
    return this.httpClient.put(
      `${environment.baseURL + '/api/sales'}/${Id}/isSold`,
      {}
    );
  }
  ondeleteSale(Id: number) {
    return this.httpClient.delete(
      `${environment.baseURL + '/api/sales'}/${Id}`
    );
  }
}
