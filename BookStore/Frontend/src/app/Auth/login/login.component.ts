import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { HotToastService } from '@ngneat/hot-toast';
import { NgbToastService } from 'ngb-toast';
import { LoginRequest } from 'src/app/AdminComponent/Admin/interfaces/AuthenticationRequest';
import { SaleService } from 'src/app/AdminComponent/Admin/Services/Sale.service';
import { UserIdService } from 'src/app/AdminComponent/Admin/Services/UserId.service';
import { RegisterComponent } from '../register/register.component';
import { AuthService } from '../Services/AuthService';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  constructor(
    public authService: AuthService,
    private router: Router,
    private route: ActivatedRoute,
    private toastService: HotToastService
  ) {}

  showError: boolean;
  errorMessage: string;
  loginForm: FormGroup;

  ngOnInit(): void {
    this.loginForm = new FormGroup({
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required]),
    });
  }

  validateControl(controlName: string) {
    return (
      this.loginForm.get(controlName)?.invalid &&
      this.loginForm.get(controlName)?.touched
    );
  }

  hasError(controlName: string, errorName: string) {
    return this.loginForm.get(controlName)?.hasError(errorName);
  }

  loginUser() {
    this.showError = false;
    const login = { ...this.loginForm.value };
    const userForAuth: LoginRequest = {
      email: login.email,
      password: login.password,
    };

    this.authService.loginUser(userForAuth).subscribe({
      next: (data) => {
        console.log(data);

        var returnUrl = this.route.snapshot.queryParams['returnUrl'];
        if (returnUrl) this.router.navigate([returnUrl]);
        else this.router.navigate(['/']);
        this.authService.saveToken(data);
        this.showToast('أهلا بك مجددا');
      },
      error: (error) => {
        console.log(error);
      },
    });
  }

  showToast(message: string) {
    this.toastService.success(message, {
      duration: 3000,
      position: 'top-left',
      icon: '😊',
    });
  }
}
