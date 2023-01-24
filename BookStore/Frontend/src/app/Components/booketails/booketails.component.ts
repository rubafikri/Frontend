import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { HotToastService } from '@ngneat/hot-toast';
import { IBook } from 'src/app/AdminComponent/Admin/interfaces/IBook';
import { IBookReview } from 'src/app/AdminComponent/Admin/interfaces/IBookReview';
import { IUserFav } from 'src/app/AdminComponent/Admin/interfaces/IUserFav';
import { BookService } from 'src/app/AdminComponent/Admin/Services/Book.service';
import { RatingService } from 'src/app/AdminComponent/Admin/Services/Rating.service';
import { SaleService } from 'src/app/AdminComponent/Admin/Services/Sale.service';
import { UserFavService } from 'src/app/AdminComponent/Admin/Services/userFav.service';
import { AuthService } from 'src/app/Auth/Services/AuthService';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-booketails',
  templateUrl: './booketails.component.html',
  styleUrls: ['./booketails.component.css'],
})
export class BooketailsComponent implements OnInit {
  book: IBook;
  books: IBook[];
  bookReview: IBookReview[];
  id: number;
  rate = 1;
  imgSrc = environment.baseURL + '/Images/Thumbs/Med/';
  RatingForm!: FormGroup;
  SaleForm!: FormGroup;
  currentRate: number;
  initialRate: number = 1;
  bookFav: IBook[] = [];
  appUserId: string;
  adedd: boolean = false;
  BookFavorit: IUserFav[] = [];
  userFav: IUserFav[] = [];
  isSold: boolean = false;
  finallyUserFavorite: IUserFav[] = [];

  constructor(
    private bookService: BookService,
    private route: ActivatedRoute,
    private authService: AuthService,
    public saleService: SaleService,
    private ratingService: RatingService,
    private router: Router,
    private uerFavr: UserFavService,
    private toastService: HotToastService
  ) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe((params) => {
      this.id = +params.get('id')!;
    });
    this.bookService.getBookById(this.id).subscribe({
      next: (data) => {
        this.book = data;
        this.initialRate = 1;
      },
    });

    this.RatingForm = new FormGroup({
      id: new FormControl('', [Validators.required]),
      rating: new FormControl('', [Validators.required]),
      comment: new FormControl('', [Validators.required]),
      bookId: new FormControl('', [Validators.required]),
    });
    this.SaleForm = new FormGroup({
      amount: new FormControl('', [Validators.required]),
    });
    this.uerFavr.getUserFav().subscribe({
      next: (data) => {
        console.log(data);
        this.BookFavorit = data;
        console.log(this.BookFavorit);

        this.BookFavorit.forEach((el) => {
          this.finallyUserFavorite.push(el);
          this.finallyUserFavorite.forEach((el) => {
            if (el.bookId == this.id) {
              console.log(el.bookId);
              this.adedd = true;
            } else {
              this.adedd = false;
            }
          });
          console.log(el);
        });

        // this.adedd = false;
        console.log(this.adedd);
      },
    });
    this.getUserId();
    this.getBooks();
    this.getAllReviews();

    if (this.appUserId != null && this.saleService.isSold == 1) {
      this.isSold = true;
    } else {
      this.isSold = false;
    }
  }
  getBooks() {
    this.bookService.getBooks().subscribe({
      next: (data) => {
        this.books = data;
        this.ratingService.getBookReview(this.id).subscribe({
          next: (data) => {
            this.currentRate = +data;
            console.log(this.currentRate);
          },
        });
      },
    });
  }
  onSubmit() {
    const { comment, rating } = this.RatingForm.value;
    console.log(rating);
    const bookId = this.id;
    console.log(bookId);
    if (this.authService.getUser() == null) {
      console.log(this.authService.getUser());
    } else {
      this.authService.getUser().subscribe({
        next: (data) => {
          console.log(data);
          this.appUserId = data.id;
          if (this.appUserId != null) {
            this.ratingService
              .addBookReview(this.appUserId!, bookId, comment, rating)
              .subscribe({
                next: (data) => {
                  console.log(data);
                  this.getAllReviews();
                  this.isSold = true;
                },
              });
            this.showToast('شكرا لك على التقييم ');
          } else {
            this.isSold = false;
          }
        },
      });

      this.RatingForm.reset();
    }
  }

  makeSale() {
    let amount: number = this.SaleForm.value.amount;
    console.log(amount);
    console.log(this.appUserId);
    if (this.appUserId != null) {
      this.saleService
        .addSale(this.appUserId, this.book.id, amount, this.book.price * amount)
        .subscribe({
          next: (data) => {
            console.log(data);
            this.saleService.saleNumber += 1;
            console.log(this.saleService.saleNumber);
          },
        });
      this.SaleForm.reset();
      this.showToast('تمت إضافة عنصر جديد  إلى  سلة الشراء ');
    } else {
      this.router.navigate(['/auth/login']);
    }
  }
  getAllReviews() {
    this.ratingService.getAllReview().subscribe({
      next: (data) => {
        this.bookReview = [];
        data.forEach((element) => {
          if (element.bookId == this.id) {
            this.bookReview.push(element);
          }
        });
      },
    });
  }
  addToFavorite(bookId: number) {
    var appUserId = this.appUserId;
    const booFav = { bookId, appUserId };
    if (appUserId != null) {
      this.uerFavr.AddToFavorite(booFav).subscribe({
        next: (data) => {
          this.BookFavorit.push(data);
          console.log(this.BookFavorit);
          this.showToast('تمت إضافة عنصر جديد  إلى المفضلة ');

          this.adedd = true;
        },
      });
    } else {
      this.router.navigate(['/auth/login']);
    }
  }

  remove(bookId: number) {
    this.uerFavr.deleteFromFav(bookId).subscribe({
      next: (data) => {
        this.BookFavorit.pop();
        this.showToast('تمت إزالة العنصر من المفضلة ');
        this.adedd = false;
      },
    });
  }
  getUserId() {
    if (this.authService.getUser() == null) {
      console.log(this.authService.getUser());
    } else {
      this.authService.getUser().subscribe({
        next: (data) => {
          if (data) {
            this.appUserId = data.id;
            console.log(this.appUserId);
            return this.appUserId;
          } else {
            console.log('No user');
            return false;
          }
        },
      });
    }
  }

  showToast(message: string) {
    this.toastService.success(message, {
      duration: 3000,
      position: 'top-left',
    });
  }
}
