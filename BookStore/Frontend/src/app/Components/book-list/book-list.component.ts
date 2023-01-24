import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { IBook } from 'src/app/AdminComponent/Admin/interfaces/IBook';
import { IBookReview } from 'src/app/AdminComponent/Admin/interfaces/IBookReview';
import { BookService } from 'src/app/AdminComponent/Admin/Services/Book.service';
import { RatingService } from 'src/app/AdminComponent/Admin/Services/Rating.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.css'],
})
export class BookListComponent implements OnInit {
  loadedBooks: IBook[];
  imgSrc = environment.baseURL + '/Images/Thumbs/Med/';
  searchKey: string;
  SearchForBooks: FormGroup;
  currentRate: number;
  bookReview: IBookReview;
  bookFound: boolean = false;
  get: boolean = false;
  id: number;
  constructor(
    private bookServices: BookService,
    private route: ActivatedRoute,
    private rateService: RatingService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe((params) => {
      this.id = +params.get('id')!;
    });
    this.SearchForBooks = new FormGroup({
      searchKey: new FormControl('', [Validators.required]),
    });

    this.route.paramMap.subscribe((params) => {
      this.searchKey = params.get('searchKey')!;
    });

    this.bookServices.onSearchBook(this.searchKey).subscribe({
      next: (data) => {
        if (data.length == 0) {
          this.bookFound = false;
          this.SearchForBooks.reset();
        } else {
          this.loadedBooks = data;
          this.searchKey = '';
          this.loadedBooks.forEach((book) =>
            this.rateService.getBookReview(book.id).subscribe({
              next: (rating) => {
                book.rating = +rating;
              },
            })
          );
          this.bookFound = true;
        }
      },
    });

    this.getBooks();
  }
  getBooks() {
    this.bookServices.getBooks().subscribe({
      next: (data) => {
        this.loadedBooks = data;
        this.loadedBooks.forEach((book) =>
          this.rateService.getBookReview(book.id).subscribe({
            next: (rating) => {
              book.rating = +rating;
              this.get = true;
            },
          })
        );
      },
    });
  }

  search() {
    const { searchKey } = this.SearchForBooks.value;
    this.route.paramMap.subscribe((params) => {
      this.searchKey = params.get('searchKey')!;
    });
    this.bookServices.onSearchBook(searchKey).subscribe({
      next: (data) => {
        if (data.length == 0) {
          this.bookFound = true;
          this.SearchForBooks.reset();
        } else {
          this.loadedBooks = data;
          this.loadedBooks.forEach((book) =>
            this.rateService.getBookReview(book.id).subscribe({
              next: (rating) => {
                book.rating = +rating;
              },
            })
          );
          this.bookFound = false;
        }
      },
    });
  }
}
