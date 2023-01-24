import { Component, OnInit } from '@angular/core';
import {
  AuthResponse,
  RegisterRequest,
  User,
} from 'src/app/AdminComponent/Admin/interfaces/AuthenticationRequest';
import { AuthService } from 'src/app/Auth/Services/AuthService';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css'],
})
export class ProfileComponent implements OnInit {
  user: User;
  userFound: boolean = false;
  constructor(private authservice: AuthService) {}

  ngOnInit(): void {
    this.getUser();
  }

  getUser() {
    if (this.authservice.getUser() == null) {
      console.log(this.authservice.getUser());
    } else {
      this.authservice.getUser()!.subscribe((data) => {
        this.user = data;
        if (data == null) {
          console.log('klnvv');
          this.userFound = false;
        } else {
          this.userFound = true;
          this.user = data;
        }
      });
    }
  }
}
