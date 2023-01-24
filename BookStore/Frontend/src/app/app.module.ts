import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './Components/Home/home.component';
import { HeaderComponent } from './Components/header/header.component';
import { NavigationBarComponent } from './Components/navigation-bar/navigation-bar.component';
import { HeroComponent } from './Components/hero/hero.component';
import { MostOrderBooksComponent } from './Components/most-order-books/most-order-books.component';
import { AdBookComponent } from './Components/ad-book/ad-book.component';
import { BookComponent } from './Components/Shared/book/book.component';
import { PublishersComponent } from './Components/Shared/publishers/publishers.component';
import { PublisherComponent } from './AdminComponent/Admin/publisher/publisher.component';
import { AdminHomeComponent } from './AdminComponent/Admin/admin-home/admin-home.component';
import { BooksComponent } from './AdminComponent/Admin/books/books.component';
import { AuthorComponent } from './AdminComponent/Admin/author/author.component';
import { CategoryComponent } from './AdminComponent/Admin/category/category.component';
import { StaticPagesComponent } from './AdminComponent/Admin/static-pages/static-pages.component';
import { SuggestipnBookComponent } from './AdminComponent/Admin/suggestipn-book/suggestipn-book.component';
import { BookListComponent } from './Components/book-list/book-list.component';
import { BooketailsComponent } from './Components/booketails/booketails.component';
import { PublisherListComponent } from './Components/publisher-list/publisher-list.component';
import { LoginComponent } from './Auth/login/login.component';
import { RegisterComponent } from './Auth/register/register.component';
import { NgxStarRatingModule } from 'ngx-star-rating';
import { ForbiddenComponent } from './Auth/forbidden/forbidden.component';
import { JwtInterceptor } from './Auth/Services/JwtInterceptor';
import { CartComponent } from './Components/cart/cart.component';
import { SalesComponent } from './AdminComponent/Admin/sales/sales.component';
import {
  NgbModal,
  NgbModule,
  NgbToastModule,
} from '@ng-bootstrap/ng-bootstrap';
import { ProfileComponent } from './Components/profile/profile.component';
import { AboutComponent } from './Components/about/about.component';
import { SuggestBookComponent } from './Components/suggest-book/suggest-book.component';
import { NgxSpinnerModule } from 'ngx-spinner';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { LoaderInterceptor } from './AdminComponent/Admin/Services/loader.interceptor';
import { ModalDialogModule } from 'ngx-modal-dialog';
import { CartIconComponent } from './Components/cart-icon/cart-icon.component';
import { SearchResultsComponent } from './Components/search-results/search-results.component';
import { CallUsComponent } from './Components/call-us/call-us.component';
import { AuthorsComponent } from './Components/authors/authors.component';
import { AuthorBookListComponent } from './Components/author-book-list/author-book-list.component';
import { UserFavoriteComponent } from './Components/user-favorite/user-favorite.component';
import { LoadingBarHttpClientModule } from '@ngx-loading-bar/http-client';
import { HotToastModule } from '@ngneat/hot-toast';
// import { AlertModule } from '@full-fledged/alerts';
@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    HeaderComponent,
    NavigationBarComponent,
    HeroComponent,
    MostOrderBooksComponent,
    AdBookComponent,
    BookComponent,
    BooksComponent,
    AdminHomeComponent,
    PublisherComponent,
    AuthorComponent,
    CategoryComponent,
    StaticPagesComponent,
    SuggestipnBookComponent,
    PublishersComponent,
    BookListComponent,
    BooketailsComponent,
    PublisherListComponent,
    LoginComponent,
    RegisterComponent,
    ForbiddenComponent,
    CartComponent,
    SalesComponent,
    ProfileComponent,
    AboutComponent,
    SuggestBookComponent,
    CartIconComponent,
    SearchResultsComponent,
    CallUsComponent,
    AuthorsComponent,
    AuthorBookListComponent,
    UserFavoriteComponent,
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: JwtInterceptor,
      multi: true,
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: LoaderInterceptor,
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    NgxStarRatingModule,
    NgbModule,
    NgxSpinnerModule,
    BrowserAnimationsModule,
    ModalDialogModule.forRoot(),
    LoadingBarHttpClientModule,
    HotToastModule.forRoot(),
    // AlertModule.forRoot({ maxMessages: 5, timeout: 5000 }),
  ],
})
export class AppModule {}
