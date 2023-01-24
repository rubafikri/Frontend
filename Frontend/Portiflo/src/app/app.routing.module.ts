import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomePageComponent } from './Components/home-page/home-page.component';
import { PostsItemComponent } from './Components/posts-item/posts-item.component';
import { PostsListComponent } from './Components/posts-list/posts-list.component';
import { ProjectListComponent } from './Components/project-list/project-list.component';

const appRoutes: Routes = [
  { path: '', component: HomePageComponent },
  { path: 'projects', component: ProjectListComponent },
  { path: 'posts', component: PostsListComponent },
  { path: 'posts/:postId', component: PostsItemComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
