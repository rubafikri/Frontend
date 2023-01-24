import { Component, OnInit } from '@angular/core';
import { ISale } from 'src/app/AdminComponent/Admin/interfaces/ISale';
import { SaleService } from 'src/app/AdminComponent/Admin/Services/Sale.service';
import { AuthService } from 'src/app/Auth/Services/AuthService';

@Component({
  selector: 'app-cart-icon',
  templateUrl: './cart-icon.component.html',
  styleUrls: ['./cart-icon.component.css'],
})
export class CartIconComponent implements OnInit {
  loadedSale: ISale[] = [];
  saleNumber: number;
  appUserId: string = '';
  constructor(
    public saleServices: SaleService,
    private authService: AuthService
  ) {}

  ngOnInit(): void {
    this.getUserId();
    this.getSales();
  }
  getSales() {
    if (this.appUserId != null) {
      this.saleServices.getSaleByUserId(this.appUserId).subscribe({
        next: (data) => {
          data.forEach((element) => {
            if (element.appUserId == this.appUserId) {
              this.loadedSale.push(element);
              console.log(this.loadedSale);
              console.log(this.saleNumber);
            }
          });
          this.saleServices.saleNumber = this.loadedSale.length;
          console.log(this.saleServices.saleNumber);
        },
      });
    } else {
      console.log('jrwefkdl');
    }
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
}
