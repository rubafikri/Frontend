import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { HotToastService } from '@ngneat/hot-toast';
import { SuggestBookService } from 'src/app/AdminComponent/Admin/Services/SuggestBook.service';

@Component({
  selector: 'app-suggest-book',
  templateUrl: './suggest-book.component.html',
  styleUrls: ['./suggest-book.component.css'],
})
export class SuggestBookComponent implements OnInit {
  suggestBookForm: FormGroup;
  constructor(
    private suggestBookService: SuggestBookService,
    private toastService: HotToastService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.suggestBookForm = new FormGroup({
      bookName: new FormControl('', [Validators.required]),
      authorName: new FormControl('', [Validators.required]),
      email: new FormControl('', [Validators.required]),
      publisherName: new FormControl('', [Validators.required]),
      notes: new FormControl('', [Validators.required]),
    });
  }

  addBookSuggest() {
    const { bookName, email, publisherName, authorName, notes } =
      this.suggestBookForm.value;
    this.suggestBookService
      .addBookSuggestions(bookName, email, publisherName, authorName, notes)
      .subscribe({
        next: (res) => {
          console.log(res);
          this.suggestBookForm.reset();
          this.router.navigate(['/']);
        },
      });

    this.showToast('شكر على اهتمامك سيتم اضافة الكتاب قريبا');
  }
  showToast(message: string) {
    this.toastService.success(message, {
      duration: 3000,
      position: 'top-left',
      icon: '👍',
    });
  }
}
