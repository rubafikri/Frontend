import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/Auth/Services/AuthService';

@Component({
  selector: 'app-navigation-bar',
  templateUrl: './navigation-bar.component.html',
  styleUrls: ['./navigation-bar.component.css'],
})
export class NavigationBarComponent implements OnInit {
  userFound: boolean = true;
  constructor(private authservice: AuthService) {}

  ngOnInit(): void {}
  getUser() {
    if (this.authservice.getUser() == null) {
      console.log(this.authservice.getUser());
    } else {
      this.authservice.getUser()!.subscribe((data) => {
        if (data == null) {
          this.userFound = false;
        } else {
          this.userFound = true;
        }
      });
    }
  }
}
