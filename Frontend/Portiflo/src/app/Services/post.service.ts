import { Injectable } from '@angular/core';
import { IPost } from '../Models/IPost';

@Injectable({
  providedIn: 'root',
})
export class PostService {
  posts: IPost[] = [
    {
      id: 1,
      postTitle: 'About this template',
      postBody: `This is a very simple template for designers to showcase there work.
      All the CSS is done and organized for you so go and make something awesome with it. `,
      date: '11/9/2022',
    },
    {
      id: 2,
      postTitle: 'About this template 2',
      postBody: `This is a very simple template for designers to showcase there work.
      All the CSS is done and organized for you so go and make something awesome with it. `,
      date: '11/7/2022',
    },
    {
      id: 3,
      postTitle: 'About this template 3',
      postBody: `This is a very simple template for designers to showcase there work.
      All the CSS is done and organized for you so go and make something awesome with it. `,
      date: '11/8/2022',
    },
  ];
  constructor() {}

  getPosts() {
    return this.posts;
  }

  getPostById(id: number) {
    return this.posts.find((post) => post.id == id)!;
  }
}
