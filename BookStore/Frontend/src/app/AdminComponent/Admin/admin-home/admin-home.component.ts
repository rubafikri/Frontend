import { Component, OnInit } from '@angular/core';
import { ISale } from '../interfaces/ISale';
import { SaleService } from '../Services/Sale.service';

@Component({
  selector: 'app-admin-home',
  templateUrl: './admin-home.component.html',
  styleUrls: ['./admin-home.component.css'],
})
export class AdminHomeComponent implements OnInit {
  loadedSale: ISale[];

  constructor(private saleService: SaleService) {}

  ngOnInit(): void {
    
  }
}
