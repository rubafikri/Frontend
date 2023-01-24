import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Route, Router } from '@angular/router';
import { Observable } from 'rxjs';
import {
  AuthResponse,
  LoginRequest,
  RegisterRequest,
  User,
} from 'src/app/AdminComponent/Admin/interfaces/AuthenticationRequest';
import { ISale } from 'src/app/AdminComponent/Admin/interfaces/ISale';
import { SaleService } from 'src/app/AdminComponent/Admin/Services/Sale.service';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  baseURL = environment.baseURL + '/api/auth';
  userId: string;
  loadedSale: ISale[] = [];
  user: Observable<User>;
  constructor(
    private httpClient: HttpClient,
    private route: Router,
    public saleservice: SaleService
  ) {}

  registerUser(userForRegister: RegisterRequest) {
    this.saleservice.saleNumber = 0;
    return this.httpClient.post<AuthResponse>(
      this.baseURL + '/register',
      userForRegister
    );
  }

  isAuthenticated() {
    const token = localStorage.getItem('token');
    if (!token) return false;

    const expiration = localStorage.getItem('token-expiration')!;
    const expirationDate = new Date(expiration);

    if (expirationDate <= new Date()) {
      this.logout();
      return false;
    }

    return true;
  }

  getFieldFromJWT(field: string) {
    const token = localStorage.getItem('token');
    if (!token) return '';
    const dataToken = JSON.parse(atob(token.split('.')[1]));
    return dataToken[field];
  }

  isUserAdmin() {
    const role = this.getFieldFromJWT(
      'http://schemas.microsoft.com/ws/2008/06/identity/claims/role'
    );

    return role === 'Admin';
  }

  logout() {
    localStorage.removeItem('token');
    localStorage.removeItem('token-expiration');
    localStorage.removeItem('userId');
    this.saleservice.saleNumber = 0;
  }

  loginUser(userForAuth: LoginRequest) {
    return this.httpClient.post<AuthResponse>(
      this.baseURL + '/login',
      userForAuth
    );
  }

  saveToken(authResponse: AuthResponse) {
    localStorage.setItem('token', authResponse.token.token);
    localStorage.setItem(
      'token-expiration',
      authResponse.token.expiration.toString()
    );
  }

  getToken() {
    return localStorage.getItem('token');
  }

  getUser(): Observable<User> {
    if (this.isAuthenticated()) {
      console.log('getUser');
      return this.httpClient.get<User>(`${this.baseURL}`);
    }
    return this.user;
  }

  getSales() {
    if (this.userId != null) {
      this.saleservice.getSaleByUserId(this.userId).subscribe({
        next: (data) => {
          data.forEach((element) => {
            if (element.appUserId == this.userId) {
              this.loadedSale.push(element);
              console.log(this.loadedSale);
              this.saleservice.saleNumber = this.loadedSale.length;
            }
          });
        },
      });
    } else {
      console.log('jrwefkdl');
    }
  }

  getUserId() {
    if (this.getUser() == null) {
      console.log(this.getUser());
    } else {
      this.getUser().subscribe({
        next: (data) => {
          if (data) {
            this.userId = data.id;
            console.log(this.userId);
            return this.userId;
          } else {
            console.log('No user');
            return false;
          }
        },
      });
    }
  }
}
