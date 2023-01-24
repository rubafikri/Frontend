import { Component, OnInit } from '@angular/core';
import { UserServices } from './Services/users.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  ngOnInit(): void {}
  constructor(public usersServices: UserServices){}
  title = 'Practice Services and Depenedancy Injection';
  
}
