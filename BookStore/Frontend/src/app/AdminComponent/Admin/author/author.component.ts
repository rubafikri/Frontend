import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { IAuthor } from '../interfaces/IAuthor';
import { AuthorService } from '../Services/Author.service';

@Component({
  selector: 'app-author',
  templateUrl: './author.component.html',
  styleUrls: ['./author.component.css'],
})
export class AuthorComponent implements OnInit {
  loadedAuthor: IAuthor[];
  AuthorForm!: FormGroup;
  updateded: boolean = true;
  author: IAuthor;
  constructor(private authorservice: AuthorService) {}

  ngOnInit(): void {
    this.AuthorForm = new FormGroup({
      name: new FormControl('', [Validators.required]),
    });
    this.getAuthor();
  }
  get name() {
    return this.AuthorForm.get('name') as FormControl;
  }
  onSubmit() {
    const { name } = this.AuthorForm.value;
    this.authorservice.addAuthor(name).subscribe({
      next: (data) => {
        console.log(data);
      },
    });
  }
  getAuthor() {
    this.authorservice.getAuthor().subscribe({
      next: (data) => {
        this.loadedAuthor = data;
        console.log(this.loadedAuthor);
      },
    });
  }
  onDeleteAuthors(id: number) {
    this.authorservice.deleteAuthor(id).subscribe({
      next: (data) => {
        console.log(data);
        this.getAuthor();
      },
    });
  }

  onUpdate() {
    this.author = this.AuthorForm.value;
    this.authorservice.updateAuthor(this.author).subscribe({
      next: (data) => {
        this.author = data;
        console.log(this.author);
        this.getAuthor();
      },
    });
    this.AuthorForm.reset();
    this.updateded = true;
  }
  populateForm(author: IAuthor) {
    this.updateded = false;
    this.AuthorForm = new FormGroup({
      name: new FormControl(author.name, [Validators.required]),
      id: new FormControl(author.id, [Validators.required]),
    });
    this.author = author;
  }
}
