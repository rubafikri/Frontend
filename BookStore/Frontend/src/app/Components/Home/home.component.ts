import { AfterContentInit, Component, OnInit } from '@angular/core';
import { ISale } from 'src/app/AdminComponent/Admin/interfaces/ISale';
import { SaleService } from 'src/app/AdminComponent/Admin/Services/Sale.service';
import { AuthService } from 'src/app/Auth/Services/AuthService';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit, AfterContentInit {
  get: boolean = false;
  loadedSale: ISale[] = [];

  userId: string;
  constructor(
    public saleService: SaleService,
    private authService: AuthService
  ) {}
  ngAfterContentInit(): void {
    console.log('ngAfterContentInit');
    this.get = true;
  }

  ngOnInit(): void {
    this.getSales();
  }

  getSales() {
    if (this.authService.getUser() == null) {
      console.log(this.authService.getUser());
    } else {
      this.authService.getUser().subscribe({
        next: (data) => {
          if (data) {
            this.userId = data.id;
            console.log(this.userId);
            this.saleService.getSaleByUserId(this.userId).subscribe({
              next: (data) => {
                data.forEach((element) => {
                  if (element.appUserId == this.userId) {
                    this.loadedSale.push(element);
                    console.log(this.loadedSale);
                  }
                });
                this.saleService.saleNumber = this.loadedSale.length;
                this.saleService.isBtn = true;
                console.log(this.saleService.saleNumber);
              },
            });
          } else {
            console.log('No user');
          }
        },
      });
    }
  }
}
