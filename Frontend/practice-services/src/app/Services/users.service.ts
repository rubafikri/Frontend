import { Injectable } from "@angular/core";
import { CounterService } from "./counter.service";

@Injectable()
export class UserServices{
activeUsers = ['Mohammed', 'Reem'];
  inactiveUsers = ['Omran', 'Abdallah'];
  constructor(private counterservise : CounterService){

  }
  
  counterActive : number = 0;
  counterAInctive : number = 0;

  setToInactive(id: number){
    this.inactiveUsers.push(this.activeUsers[id]);
    this.activeUsers.splice(id, 1);
    this.counterservise.pressinactivebtn();
   
  }
  setToActice(id: number){
    this.activeUsers.push(this.inactiveUsers[id]);
    this.inactiveUsers.splice(id, 1);
    this.counterservise.pressactivebtn();
   



  }
}