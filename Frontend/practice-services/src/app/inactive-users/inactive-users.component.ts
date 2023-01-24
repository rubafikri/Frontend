import { Component } from '@angular/core';
import { UserServices } from '../Services/users.service';

@Component({
  selector: 'app-inactive-users',
  templateUrl: './inactive-users.component.html',
  styleUrls: ['./inactive-users.component.css']
})
export class InactiveUsersComponent {
  
constructor(public userServicse: UserServices){}

  onSetToActive(id: number) {
    this.userServicse.setToActice(id);
  }
}
