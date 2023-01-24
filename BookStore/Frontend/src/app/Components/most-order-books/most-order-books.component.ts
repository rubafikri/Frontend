import { Component, OnInit } from '@angular/core';
import { IBook } from 'src/app/AdminComponent/Admin/interfaces/IBook';
import { BookService } from 'src/app/AdminComponent/Admin/Services/Book.service';
import { RatingService } from 'src/app/AdminComponent/Admin/Services/Rating.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-most-order-books',
  templateUrl: './most-order-books.component.html',
  styleUrls: ['./most-order-books.component.css'],
})
export class MostOrderBooksComponent implements OnInit {
  loadedBooks: IBook[];
  newBook: IBook;
  imgSrc = environment.baseURL + '/Images/Thumbs/Med/';
  new2Book: IBook;
  new3Book: IBook;
  get: boolean = true;
  constructor(
    private bookServices: BookService,
    private rateService: RatingService
  ) {}

  ngOnInit(): void {
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
              this.get = false;
            },
          })
        );
        this.newBook = this.loadedBooks[0];
        this.new2Book = this.loadedBooks[1];
        this.new3Book = this.loadedBooks[3];
      },
    });
  }
}
