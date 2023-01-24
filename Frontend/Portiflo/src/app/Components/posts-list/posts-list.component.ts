import { Component, OnInit } from '@angular/core';
import { IPost } from 'src/app/Models/IPost';
import { PostService } from 'src/app/Services/post.service';

@Component({
  selector: 'app-posts-list',
  templateUrl: './posts-list.component.html',
  styleUrls: ['./posts-list.component.css'],
})
export class PostsListComponent implements OnInit {
  posts: IPost[] = [];
  constructor(private postService: PostService) {}

  ngOnInit(): void {
    this.posts = this.postService.getPosts();
  }
}
