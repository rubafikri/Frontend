import { Component, OnDestroy, OnInit } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { IAuthor } from 'src/app/AdminComponent/Admin/interfaces/IAuthor';
import { AuthorService } from 'src/app/AdminComponent/Admin/Services/Author.service';

@Component({
  selector: 'app-authors',
  templateUrl: './authors.component.html',
  styleUrls: ['./authors.component.css'],
})
export class AuthorsComponent implements OnInit {
  loaddedAuthors: IAuthor[];
  constructor(private authorService: AuthorService, private router: Router) {}

  ngOnInit(): void {
    this.getAuthor();
  }

  getAuthor() {
    this.authorService.getAuthor().subscribe((data) => {
      console.log(data);
      this.loaddedAuthors = data;
    });
  }
}
