import { Component, OnInit } from '@angular/core';
import { IBook } from 'src/app/AdminComponent/Admin/interfaces/IBook';
import { IUserFav } from 'src/app/AdminComponent/Admin/interfaces/IUserFav';
import { BookService } from 'src/app/AdminComponent/Admin/Services/Book.service';
import { UserFavService } from 'src/app/AdminComponent/Admin/Services/userFav.service';
import { AuthService } from 'src/app/Auth/Services/AuthService';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-user-favorite',
  templateUrl: './user-favorite.component.html',
  styleUrls: ['./user-favorite.component.css'],
})
export class UserFavoriteComponent implements OnInit {
  userFav: IUserFav[] = [];
  userFavList: IUserFav[] = [];
  loadderdBooks: IBook[] = [];
  imgSrc = environment.baseURL + '/Images/Thumbs/Med/';
  appUserId: string;

  constructor(
    private bookService: BookService,
    private authService: AuthService,
    private userFavService: UserFavService
  ) {}

  ngOnInit(): void {
    this.authService.getUser().subscribe({
      next: (data) => {
        if (data) {
          this.appUserId = data.id;
          this.userFavService.getUserFav().subscribe({
            next: (value) => {
              this.userFav = value;
              console.log(value);
              this.userFav.forEach((userFav) => {
                if (userFav.appUserId === this.appUserId) {
                  this.userFavList.push(userFav);
                  console.log(this.userFavList);
                }
              });
              this.userFavList.forEach((element) => {
                this.bookService.getBookById(element.bookId).subscribe({
                  next: (value) => {
                    this.loadderdBooks.push(value);
                    console.log(this.loadderdBooks);
                  },
                });
              });
            },
          });
          return this.appUserId;
        } else {
          console.log('No user');
          return false;
        }
      },
    });
  }

  getFavById() {}

  getUserId() {}
}
