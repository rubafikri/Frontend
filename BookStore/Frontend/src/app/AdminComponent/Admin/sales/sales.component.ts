import { Component, OnInit } from '@angular/core';
import { AuthResponse } from 'src/app/AdminComponent/Admin/interfaces/AuthenticationRequest';
import { ISale } from 'src/app/AdminComponent/Admin/interfaces/ISale';
import { SaleService } from 'src/app/AdminComponent/Admin/Services/Sale.service';
import { AuthService } from 'src/app/Auth/Services/AuthService';

@Component({
  selector: 'app-sales',
  templateUrl: './sales.component.html',
  styleUrls: ['./sales.component.css'],
})
export class SalesComponent implements OnInit {
  loadedSale: ISale[];
  auth: AuthResponse;
  userId: string;
  constructor(private saleService: SaleService) {}

  ngOnInit(): void {
    this.getSales();
  }

  getSales() {
    this.saleService.getSales().subscribe({
      next: (data) => {
        this.loadedSale = data;
        console.log(this.loadedSale);
      },
    });
  }

  onUpdate(id: number) {
    return this.saleService.onupdateSaleStatus(id).subscribe({
      next: (data) => {
        console.log(data);
        this.getSales();
      },
    });
  }
}
