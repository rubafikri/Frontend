import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { HotToastService } from '@ngneat/hot-toast';
import { CallUsService } from 'src/app/AdminComponent/Admin/Services/CallUs.service';

@Component({
  selector: 'app-call-us',
  templateUrl: './call-us.component.html',
  styleUrls: ['./call-us.component.css'],
})
export class CallUsComponent implements OnInit {
  CallUsForm: FormGroup;
  constructor(
    private callUsService: CallUsService,
    private route: Router,
    private toastService: HotToastService
  ) {}

  ngOnInit(): void {
    this.CallUsForm = new FormGroup({
      email: new FormControl('', Validators.required),
      message: new FormControl('', Validators.required),
      fullName: new FormControl('', Validators.required),
    });
  }
  addCal() {
    const { email, message, fullName } = this.CallUsForm.value;
    this.callUsService.callUsCreate(email, message, fullName).subscribe({
      next: (res) => {
        console.log(res);
        this.CallUsForm.reset();
        this.route.navigate(['']);
        this.showToast(
          'شكرا لك على التواصل معنا ! سيتم الرد على طلبك بأقرب وقت'
        );
      },
    });
  }

  showToast(message: string) {
    this.toastService.success(message, {
      duration: 3000,
      position: 'top-left',
      icon: '👌',
    });
  }
}
