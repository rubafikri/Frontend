import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { HotToastService } from '@ngneat/hot-toast';
import { IBook } from 'src/app/AdminComponent/Admin/interfaces/IBook';
import { IBookReview } from 'src/app/AdminComponent/Admin/interfaces/IBookReview';
import { ISale } from 'src/app/AdminComponent/Admin/interfaces/ISale';
import { SaleService } from 'src/app/AdminComponent/Admin/Services/Sale.service';
import { AuthService } from 'src/app/Auth/Services/AuthService';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent implements OnInit {
  loadedSale: ISale[] = [];
  saleNumber: number = 0;
  userId: string;
  loadedBooks: IBook[];
  imgSrc = environment.baseURL + '/Images/Thumbs/Med/';
  SearchForBooks: FormGroup;
  currentRate: number;
  bookReview: IBookReview;
  bookFound: boolean = false;
  searchKey: string;
  public isButtonVisible = true;
  constructor(
    private authService: AuthService,
    public saleService: SaleService,
    private toastService: HotToastService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.getUserId();
    this.SearchForBooks = new FormGroup({
      searchKey: new FormControl('', [Validators.required]),
    });

    this.getUserId();
    this.getSales();
    console.log(this.searchKey);
  }

  search() {
    console.log(this.searchKey);
    this.router.navigate(['/SearchResult'], {
      queryParams: { 'searchKey': this.searchKey },
    });
    console.log(this.searchKey);

    this.SearchForBooks.reset();
  }
  getUserId() {
    if (this.authService.getUser() == null) {
      console.log(this.authService.getUser());
    } else {
      this.authService.getUser().subscribe({
        next: (data) => {
          if (data) {
            this.userId = data.id;
            console.log(this.userId);
            return this.userId;
          } else {
            console.log('No user');
            return false;
          }
        },
      });
    }
  }

  logOut() {
    this.authService.logout();
    this.saleService.isBtn = false;
    this.showToast('تم تسجيل الخروج! عد إلينا قريبا ');
  }

  getSales() {
    if (this.userId != null) {
      this.saleService.getSaleByUserId(this.userId).subscribe({
        next: (data) => {
          data.forEach((element) => {
            if (element.appUserId == this.userId) {
              this.loadedSale.push(element);
              console.log(this.loadedSale);
              this.saleService.saleNumber = this.loadedSale.length;
            }
          });
        },
      });
    } else {
      console.log('jrwefkdl');
    }
  }

  showToast(message: string) {
    this.toastService.success(message, {
      duration: 3000,
      position: 'top-left',
      icon: '😭',
    });
  }
}
