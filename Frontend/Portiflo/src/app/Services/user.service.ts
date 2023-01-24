import { Injectable } from '@angular/core';
import { IUser } from '../Models/IUser';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  user: IUser = {
    profileImage: './assets/Rectangle 2.png',
    userName: 'Jhon Smith',
    jobName: 'Jhon Smith',
    userEmail: 'jhon@example.com',
    socialMediaIcons: [
      './assets/Icon awesome-behance.png',
      './assets/Icon awesome-twitter.png',
      './assets/Icon simple-dribbble.png',
    ],
  };
  constructor() {}

  getUser() {
    return this.user;
  }
}
