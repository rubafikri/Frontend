import { Component, OnInit } from '@angular/core';
import { ModalDismissReasons, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { HotToastService } from '@ngneat/hot-toast';
import { AuthResponse } from 'src/app/AdminComponent/Admin/interfaces/AuthenticationRequest';
import { ISale } from 'src/app/AdminComponent/Admin/interfaces/ISale';
import { SaleService } from 'src/app/AdminComponent/Admin/Services/Sale.service';
import { ToastService } from 'src/app/AdminComponent/Admin/Services/toast.service';
import { AuthService } from 'src/app/Auth/Services/AuthService';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css'],
})
export class CartComponent implements OnInit {
  loadedSale: ISale[] = [];
  auth: AuthResponse;
  userId: string;
  closeResult: string;
  saleFound: boolean = false;
  userFound: boolean = false;
  constructor(
    public saleService: SaleService,
    private authService: AuthService,
    private modalService: NgbModal,
    private toastService: HotToastService
  ) {}

  ngOnInit(): void {
    this.getSales();
    console.log(this.userFound);
  }

  getSales() {
    if (this.authService.getUser() == null) {
      console.log(this.authService.getUser());
    } else {
      this.authService.getUser().subscribe((data) => {
        this.userId = data.id;
        if (this.userId == null) {
          console.log('klnvv');
          this.userFound = false;
        } else {
          this.userFound = true;
          this.userId = data.id;
        }
        if (this.userId != null) {
          this.saleService.getSaleByUserId(this.userId).subscribe({
            next: (data) => {
              this.loadedSale = data;
              console.log(this.loadedSale);
              this.saleFound = true;
              this.userFound = true;
            },
          });
        } else {
          console.log('jrwefkdl');
          this.saleFound = false;
          this.userFound = false;
        }
      });
    }
  }
  deleteSale(id: number) {
    this.saleService.ondeleteSale(id).subscribe({
      next: (data) => {
        this.saleService.saleNumber -= 1;
        this.getSales();
        this.saleFound = false;
      },
      error: (error) => {
        console.log(error);
      },
    });
  }
  open(content: any) {
    this.modalService
      .open(content, { ariaLabelledBy: 'modal-basic-title' })
      .result.then(
        (result) => {
          this.closeResult = `Closed with: ${result}`;
          this.showToast();
        },
        (reason) => {
          this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
        }
      );
  }
  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return `with: ${reason}`;
    }
  }

  showToast() {
    this.toastService.success('تمت إزالة الكتاب من السلة بنجاح', {
      duration: 3000,
      position: 'top-left',
    });
  }
}
