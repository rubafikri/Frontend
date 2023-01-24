import { Component, EventEmitter, Input, Output } from '@angular/core';
import { UserServices } from '../Services/users.service';

@Component({
  selector: 'app-active-users',
  templateUrl: './active-users.component.html',
  styleUrls: ['./active-users.component.css']
})
export class ActiveUsersComponent {
  constructor(public userServicse: UserServices){}

  onSetToInactive(id: number) {
    this.userServicse.setToInactive(id);
  }
}
