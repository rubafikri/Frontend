import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ActiveUsersComponent } from './active-users/active-users.component';

import { AppComponent } from './app.component';
import { InactiveUsersComponent } from './inactive-users/inactive-users.component';
import { CounterService } from './Services/counter.service';
import { UserServices } from './Services/users.service';

@NgModule({
  declarations: [AppComponent, ActiveUsersComponent, InactiveUsersComponent],
  imports: [BrowserModule],
  providers: [UserServices , CounterService],
  bootstrap: [AppComponent],
})
export class AppModule {}
