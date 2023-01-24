import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { SuccessAlertComponent } from './SuccessAlert/successalert.component';
import { SuccessCardComponent } from './SuccessCard/successcard.component';

@NgModule({
  declarations: [
    AppComponent,
    SuccessAlertComponent,
    SuccessCardComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
