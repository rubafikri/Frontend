import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ICallUs } from '../interfaces/CallUs';
import { IBookSuggestion } from '../interfaces/IBookSuggestions';

@Injectable({
  providedIn: 'root',
})
export class CallUsService {
  baseURL = environment.baseURL + '/api/contantUs';
  constructor(private httpClient: HttpClient) {}
  callUsCreate(email: string, fullName: string, message: string) {
    let formData = new FormData();
    formData.append('email', email);
    formData.append('fullName', fullName);
    formData.append('message', message);
    return this.httpClient.post<ICallUs>(this.baseURL, formData);
  }
}
