import { Component, OnInit } from '@angular/core';
import { IBook } from 'src/app/AdminComponent/Admin/interfaces/IBook';
import { BookService } from 'src/app/AdminComponent/Admin/Services/Book.service';
import { RatingService } from 'src/app/AdminComponent/Admin/Services/Rating.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css'],
})
export class BookComponent implements OnInit {
  loadedBooks: IBook[];
  getLastBook: IBook[];
  imgSrc = environment.baseURL + '/Images/Thumbs/Med/';
  get: boolean = false;
  constructor(
    private bookServices: BookService,
    private bookReviewService: RatingService
  ) {}

  ngOnInit(): void {
    this.getBooks();
    console.log(this.get);
  }

  getBooks() {
    this.bookServices.getBooks().subscribe({
      next: (data) => {
        this.loadedBooks = data;

        this.getLastBook = this.loadedBooks.slice(0, 6);
        console.log(this.loadedBooks);

        this.getLastBook.forEach((book) =>
          this.bookReviewService.getBookReview(book.id).subscribe({
            next: (rating) => {
              book.rating = +rating;
              this.get = true;
            },
          })
        );
       
      },
    });
  }

  getBookReview(id: number) {
    let book = this.getLastBook.find((x) => x.id == id);
    console.log(book?.id);
    return this.bookReviewService.getBookReview(book!.id).subscribe({
      next: (data) => {
        console.log(data);
        this.get = true;
        console.log(this.get);
      },
    });
  }
}
