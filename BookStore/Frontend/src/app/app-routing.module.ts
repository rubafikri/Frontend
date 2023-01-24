import { CommonModule } from '@angular/common';
import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminHomeComponent } from './AdminComponent/Admin/admin-home/admin-home.component';
import { AuthorComponent } from './AdminComponent/Admin/author/author.component';
import { BooksComponent } from './AdminComponent/Admin/books/books.component';
import { CategoryComponent } from './AdminComponent/Admin/category/category.component';
import { PublisherComponent } from './AdminComponent/Admin/publisher/publisher.component';
import { SalesComponent } from './AdminComponent/Admin/sales/sales.component';
import { StaticPagesComponent } from './AdminComponent/Admin/static-pages/static-pages.component';
import { SuggestipnBookComponent } from './AdminComponent/Admin/suggestipn-book/suggestipn-book.component';
import { ForbiddenComponent } from './Auth/forbidden/forbidden.component';
import { AdminGuard } from './Auth/gurds/admin.guard';
import { AuthGuard } from './Auth/gurds/auth.guard';
import { LoginComponent } from './Auth/login/login.component';
import { RegisterComponent } from './Auth/register/register.component';
import { AboutComponent } from './Components/about/about.component';
import { AuthorBookListComponent } from './Components/author-book-list/author-book-list.component';
import { AuthorsComponent } from './Components/authors/authors.component';
import { BookListComponent } from './Components/book-list/book-list.component';
import { BooketailsComponent } from './Components/booketails/booketails.component';
import { CallUsComponent } from './Components/call-us/call-us.component';
import { CartComponent } from './Components/cart/cart.component';

import { HomeComponent } from './Components/Home/home.component';
import { ProfileComponent } from './Components/profile/profile.component';
import { PublisherListComponent } from './Components/publisher-list/publisher-list.component';
import { SearchResultsComponent } from './Components/search-results/search-results.component';
import { SuggestBookComponent } from './Components/suggest-book/suggest-book.component';
import { UserFavoriteComponent } from './Components/user-favorite/user-favorite.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
    pathMatch: 'full',
  },
  {
    path: 'BookList',
    component: BookListComponent,
  },
  {
    path: 'Authors',
    component: AuthorsComponent,
  },
  {
    path: 'UserFav',
    component: UserFavoriteComponent,
  },
  {
    path: 'PublisherList',
    component: PublisherListComponent,
  },
  {
    path: 'BookList/:id',
    component: BooketailsComponent,
  },
  {
    path: 'SearchResult',
    component: SearchResultsComponent,
  },
  {
    path: 'SearchResult/?searchKey',
    component: SearchResultsComponent,
  },
  {
    path: 'AuthorsBookList/:id',
    component: AuthorBookListComponent,
  },
  {
    path: 'CallUs',
    component: CallUsComponent,
  },
  {
    path: 'auth/login',
    component: LoginComponent,
  },
  {
    path: 'auth/register',
    component: RegisterComponent,
  },
  {
    path: 'forbidden',
    component: ForbiddenComponent,
  },
  {
    path: 'cart',
    component: CartComponent,
  },
  {
    path: 'profile',
    component: ProfileComponent,
    children: [
      {
        path: 'favorite',
        component: UserFavoriteComponent,
      },
    ],
  },
  {
    path: 'aboutUs',
    component: AboutComponent,
  },
  {
    path: 'suggest',
    component: SuggestBookComponent,
  },
  {
    path: 'manage',
    canActivateChild: [AuthGuard, AdminGuard],
    component: AdminHomeComponent,
    children: [
      {
        path: 'Books',
        component: BooksComponent,
      },
      {
        path: 'Category',
        component: CategoryComponent,
      },
      {
        path: 'Publisher',
        component: PublisherComponent,
      },
      {
        path: 'Authors',
        component: AuthorComponent,
      },

      {
        path: 'StaticPages',
        component: StaticPagesComponent,
      },
      {
        path: 'BookSuggestion',
        component: SuggestipnBookComponent,
      },
      {
        path: 'Sale',
        component: SalesComponent,
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes), CommonModule],
  exports: [RouterModule],
})
export class AppRoutingModule {}
