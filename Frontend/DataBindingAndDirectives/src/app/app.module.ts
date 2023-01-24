import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { InputUserNameComponent } from './input-user-name/input-user-name.component';
import { DisplayButtonComponent } from './display-button/display-button.component';
import { DisplayDateComponent } from './display-date/display-date.component';

@NgModule({
  declarations: [
    AppComponent,
    InputUserNameComponent,
    DisplayButtonComponent,
    DisplayDateComponent
  ],
  imports: [
    BrowserModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
