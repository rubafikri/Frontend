import { HttpClient } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';
import { IPublisher } from '../interfaces/IPublisher';
import { IUserFav } from '../interfaces/IUserFav';

@Injectable({
  providedIn: 'root',
})
export class UserIdService {
   userId: string;
  constructor() {}
}
