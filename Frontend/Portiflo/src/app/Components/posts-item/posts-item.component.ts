import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IPost } from 'src/app/Models/IPost';
import { PostService } from 'src/app/Services/post.service';

@Component({
  selector: 'app-posts-item',
  templateUrl: './posts-item.component.html',
  styleUrls: ['./posts-item.component.css'],
})
export class PostsItemComponent implements OnInit {
  post!: IPost;
  constructor(
    private postService: PostService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe((params) => {
      let postId = +params.get('postId')!;
      this.post = this.postService.getPostById(postId);
    });
  }
}
