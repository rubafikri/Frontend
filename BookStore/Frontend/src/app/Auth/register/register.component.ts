import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { HotToastService } from '@ngneat/hot-toast';
import {
  AuthResponse,
  RegisterRequest,
} from 'src/app/AdminComponent/Admin/interfaces/AuthenticationRequest';
import { UserIdService } from 'src/app/AdminComponent/Admin/Services/UserId.service';
import { AuthService } from '../Services/AuthService';
import Validation from '../utils/Validation';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  constructor(
    private router: Router,
    public authService: AuthService,
    private userIdService: UserIdService,
    private toastService: HotToastService
  ) {}
  static user: string;

  showError: boolean;
  errorMessage: string;
  registerForm: FormGroup;

  ngOnInit(): void {
    this.registerForm = new FormGroup(
      {
        firstName: new FormControl('', [Validators.required]),
        lastName: new FormControl('', [Validators.required]),
        email: new FormControl('', [Validators.email, Validators.required]),
        password: new FormControl('', [Validators.required]),
        confirm: new FormControl('', [Validators.required]),
      },
      {
        validators: [Validation.match('password', 'confirm')],
      }
    );
  }

  validateControl(controlName: string) {
    return (
      this.registerForm.get(controlName)?.invalid &&
      this.registerForm.get(controlName)?.touched
    );
  }

  hasError(controlName: string, errorName: string) {
    return this.registerForm.get(controlName)?.hasError(errorName);
  }

  registerUser() {
    this.showError = false;
    const formValues = { ...this.registerForm.value };

    const users: RegisterRequest = {
      firstName: formValues.firstName,
      lastName: formValues.lastName,
      email: formValues.email,
      password: formValues.password,
    };

    this.authService.registerUser(users).subscribe({
      next: (data) => {
        console.log(data);
        // this.userIdService.userId = data.userId;
        this.router.navigate(['/auth/login']);
        this.showToast('أرجو أن تستمتع بالموقع ! امضي وقت سعيد ');
      },
      error: (error: HttpErrorResponse) => {
        this.errorMessage = error.error.errors;
        this.showError = true;
      },
    });
  }
  showToast(message: string) {
    this.toastService.success(message, {
      duration: 3000,
      position: 'top-left',
      icon: '🤩',
    });
  }
}
