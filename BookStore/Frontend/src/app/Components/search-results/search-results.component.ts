import {
  AfterContentChecked,
  AfterContentInit,
  AfterViewInit,
  Component,
  DoCheck,
  OnChanges,
  OnDestroy,
  OnInit,
} from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { IBook } from 'src/app/AdminComponent/Admin/interfaces/IBook';
import { IBookReview } from 'src/app/AdminComponent/Admin/interfaces/IBookReview';
import { BookService } from 'src/app/AdminComponent/Admin/Services/Book.service';
import { RatingService } from 'src/app/AdminComponent/Admin/Services/Rating.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-search-results',
  templateUrl: './search-results.component.html',
  styleUrls: ['./search-results.component.css'],
})
export class SearchResultsComponent implements OnInit {
  loadedBooks: IBook[];
  imgSrc = environment.baseURL + '/Images/Thumbs/Med/';
  searchKey: string;
  SearchForBooks: FormGroup;
  currentRate: number;
  bookReview: IBookReview;
  bookFound: boolean = true;
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
    this.searchKey = this.route.snapshot.queryParamMap.get('searchKey')!;
    console.log(this.searchKey);
    this.bookServices.onSearchBook(this.searchKey).subscribe({
      next: (data) => {
        if (data.length == 0) {
          this.bookFound = false;
          this.SearchForBooks.reset();
          console.log(data);
        } else {
          this.loadedBooks = data;
          this.searchKey = ' ';
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
            },
          })
        );
      },
    });
  }
  // ngOnDestroy() {
  //   if (this.mySubscription) {
  //     this.mySubscription.unsubscribe();
  //   }
  // }
}
