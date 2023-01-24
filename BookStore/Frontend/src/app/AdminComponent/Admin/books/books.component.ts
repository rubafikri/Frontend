import { HttpEventType } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { environment } from 'src/environments/environment';
import { IAuthor } from '../interfaces/IAuthor';
import { IBook } from '../interfaces/IBook';
import { ICategory } from '../interfaces/ICategory';
import { IPublisher } from '../interfaces/IPublisher';
import { AuthorService } from '../Services/Author.service';
import { BookService } from '../Services/Book.service';
import { CategoryService } from '../Services/category.service';
import { PublishernewService } from '../Services/publishernew.service';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css'],
})
export class BooksComponent implements OnInit {
  BooksForm!: FormGroup;
  progressValue: string;
  imageSrc: string;

  publishers: IPublisher[];
  authors: IAuthor[];
  categories: ICategory[];
  bookFound: IBook;
  books: IBook[];
  imgSrc = environment.baseURL + '/Images/Thumbs/Med/';

  constructor(
    private publisherService: PublishernewService,
    private authorsService: AuthorService,
    private categoriesService: CategoryService,
    private bookService: BookService
  ) {}

  ngOnInit(): void {
    this.BooksForm = new FormGroup({
      name: new FormControl('', [Validators.required]),
      price: new FormControl('', [Validators.required]),
      discount: new FormControl(''),
      about: new FormControl('', [Validators.required]),
      file: new FormControl('', [Validators.required]),
      fileSource: new FormControl('', [Validators.required]),
      publishYear: new FormControl('', [Validators.required]),
      pageCount: new FormControl('', [Validators.required]),
      publisherId: new FormControl('', [Validators.required]),
      authorId: new FormControl('', [Validators.required]),
      CategoryId: new FormControl('', [Validators.required]),
    });
    this.getPublishers();
    this.getAuthors();
    this.getCategories();
    this.getBook();
  }
  get name() {
    return this.BooksForm.get('name') as FormControl;
  }
  get authorId() {
    return this.BooksForm.get('authorId') as FormControl;
  }
  get CategoryId() {
    return this.BooksForm.get('CategoryId') as FormControl;
  }
  get price() {
    return this.BooksForm.get('price') as FormControl;
  }
  get about() {
    return this.BooksForm.get('about') as FormControl;
  }
  get publishYear() {
    return this.BooksForm.get('publishYear') as FormControl;
  }
  get pageCount() {
    return this.BooksForm.get('pageCount') as FormControl;
  }
  get publisherId() {
    return this.BooksForm.get('publisherId') as FormControl;
  }
  onSubmit() {
    const {
      price,
      name,
      discount,
      about,
      publisherId,
      authorId,
      CategoryId,
      pageCount,
      publishYear,
      fileSource,
    } = this.BooksForm.value;
    console.log({ price, name, fileSource });
    this.bookService
      .addBook(
        price,
        name,
        discount,
        about,
        publisherId,
        authorId,
        CategoryId,
        pageCount,
        publishYear,
        fileSource
      )
      .subscribe({
        next: (data) => {
          if (data.type == HttpEventType.UploadProgress) {
            if (data.total)
              this.progressValue =
                Math.round(100 * (data.loaded / data.total)) + '%';
            console.log(price);
          }
          if (data.type == HttpEventType.Response) {
            console.log(data.body);
            this.imageSrc =
              environment.baseURL + '/Images/Thumbs/Med/' + data.body!.image;
          }
        },
      });
  }

  onFileChange(event: Event) {
    const target = event.target as HTMLInputElement;
    const files = target.files!;

    if (files.length > 0) {
      const file = files[0];
      console.log(file);
      this.BooksForm.patchValue({
        fileSource: file,
      });
    }
  }
  getPublishers() {
    this.publisherService.getPublishers().subscribe({
      next: (data) => {
        console.log(data);
        this.publishers = data;
      },
    });
  }
  getAuthors() {
    this.authorsService.getAuthor().subscribe({
      next: (data) => {
        console.log(data);
        this.authors = data;
      },
    });
  }
  getCategories() {
    this.categoriesService.getCategory().subscribe({
      next: (data) => {
        console.log(data);
        this.categories = data;
      },
    });
  }
  getBook() {
    this.bookService.getBooks().subscribe({
      next: (data) => {
        this.books = data;
        console.log(this.books);
      },
    });
  }
  onDeleteBook(id: number) {
    this.bookService.deleteBook(id).subscribe({
      next: (data) => {
        console.log(data);
        this.getBook();
      },
    });
  }
}
