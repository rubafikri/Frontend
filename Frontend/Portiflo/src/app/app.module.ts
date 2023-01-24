import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { ProjectListComponent } from './Components/project-list/project-list.component';
import { PostsListComponent } from './Components/posts-list/posts-list.component';
import { PostsItemComponent } from './Components/posts-item/posts-item.component';
import { AppRoutingModule } from './app.routing.module';
import { HomePageComponent } from './Components/home-page/home-page.component';

@NgModule({
  declarations: [
    AppComponent,
    ProjectListComponent,
    PostsListComponent,
    PostsItemComponent,
    HomePageComponent,
  ],
  imports: [BrowserModule, AppRoutingModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
