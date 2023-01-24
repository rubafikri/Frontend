import { Component, NgModule, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  dropdowninit = 'Advanced';
  isValid = true;
  submitted = false;
  title = 'AngularTemplaterivenForm';
  user = {
    username: '',
    email: '',
    drop: '',
    password: '',
  };
  @ViewChild('signinForm') signInform: NgForm;

  onSubmit() {
    if (!this.signInform.valid) {
      this.isValid = false;
    } else {
      this.submitted = true;
      this.user.email = this.signInform.value.email;
      this.user.drop = this.signInform.value.drop;
      this.user.password = this.signInform.value.password;
      console.log(this.signInform);
      this.isValid = true;
      this.signInform.reset({
        drop: this.dropdowninit,
      });
    }
  }
}
