import { Component } from '@angular/core';
import { IUser } from './Models/IUser';
import { UserService } from './Services/user.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'Portiflo';
  user!: IUser;

  constructor(private userService: UserService) {}

  ngOnInit(): void {
    this.user = this.userService.getUser();
  }
}
