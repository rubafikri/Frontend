import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IAuthor } from 'src/app/AdminComponent/Admin/interfaces/IAuthor';
import { IBook } from 'src/app/AdminComponent/Admin/interfaces/IBook';
import { AuthorService } from 'src/app/AdminComponent/Admin/Services/Author.service';
import { BookService } from 'src/app/AdminComponent/Admin/Services/Book.service';
import { RatingService } from 'src/app/AdminComponent/Admin/Services/Rating.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-author-book-list',
  templateUrl: './author-book-list.component.html',
  styleUrls: ['./author-book-list.component.css'],
})
export class AuthorBookListComponent implements OnInit {
  loadedBook: IBook[] = [];
  authorBook: IBook[] = [];
  authorId: number;
  imgSrc = environment.baseURL + '/Images/Thumbs/Med/';

  constructor(
    private bookService: BookService,
    private route: ActivatedRoute,
    private rateService: RatingService
  ) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe((params) => {
      this.authorId = +params.get('id')!;
    });
    console.log(this.authorId);
    this.getBooks();
  }

  getBooks() {
    this.bookService.getBooks().subscribe({
      next: (books: IBook[]) => {
        this.loadedBook = books;
        this.loadedBook.forEach((element) => {
          if (element.authorId === this.authorId) {
            this.authorBook.push(element);
            console.log(this.authorBook.length);
          } else {
            console.log('jhjb');
          }
        });

        this.authorBook.forEach((book) =>
          this.rateService.getBookReview(book.id).subscribe({
            next: (rating) => {
              book.rating = +rating;
            },
          })
        );
      },
    });
  }
}
