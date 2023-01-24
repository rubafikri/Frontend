import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  projectform!: FormGroup;

  ngOnInit(): void {
    this.projectform = new FormGroup({
      projectName: new FormControl('', [
        Validators.required,
        this.forbiddenProjectName,
      ]),
      mail: new FormControl('', [Validators.email, Validators.required]),
      statues: new FormControl('Stable'),
    });
  }

  get projectName() {
    return this.projectform.get('projectName') as FormControl;
  }

  get mail() {
    return this.projectform.get('mail') as FormControl;
  }
  onSubmit() {
    console.log(this.projectform.value);
  }

  forbiddenProjectName(
    control: FormControl
  ): { [error: string]: boolean } | null {
    if (control.value.toLowerCase() == 'test') {
      return { nameIsForbidden: true };
    }
    return null;
  }
}
