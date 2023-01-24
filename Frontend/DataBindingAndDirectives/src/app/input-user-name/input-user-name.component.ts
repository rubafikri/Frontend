import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-input-user-name',
  templateUrl: './input-user-name.component.html',
  styleUrls: ['./input-user-name.component.css']
})
export class InputUserNameComponent implements OnInit {
 userNameText: string = '';

  constructor() { }

  ngOnInit(): void {
  }

  disabeld(){
    if (this.userNameText == '') {
      return true ; 
     }else{
       return false;
     }
  
  }
  rest(){
    this.userNameText = '';
  }
  
 

}
