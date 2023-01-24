import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { IStaticPages } from '../interfaces/IstaticPages';
import { StaticPagesService } from '../Services/StaticPages.service';

@Component({
  selector: 'app-static-pages',
  templateUrl: './static-pages.component.html',
  styleUrls: ['./static-pages.component.css'],
})
export class StaticPagesComponent implements OnInit {
  StaticPageForm!: FormGroup;
  loadedStaticPages: IStaticPages[];
  staticPage: IStaticPages;
  updateded: boolean = true;

  constructor(private staticPagesService: StaticPagesService) { }

  ngOnInit(): void {
    this.StaticPageForm = new FormGroup({
      pageName: new FormControl('', [Validators.required]),
      details: new FormControl('', [Validators.required]),
    });
    this.getStaticPages();
  }

  get pageName() {
    return this.StaticPageForm.get('pageName') as FormControl;
  }
  get details() {
    return this.StaticPageForm.get('details') as FormControl;
  }
  onSubmit() {
    const { pageName, details } = this.StaticPageForm.value;
    this.staticPagesService.addStaticPage(pageName, details).subscribe({
      next: (data) => {
        console.log(data);
        this.getStaticPages();
        this.StaticPageForm.reset();
      },
    });
  }
  getStaticPages() {
    this.staticPagesService.getStaticPage().subscribe({
      next: (data) => {
        this.loadedStaticPages = data;
        console.log(this.loadedStaticPages);
      },
    });
  }
  onDeleteAuthors(id: number) {
    this.staticPagesService.deleteStatic(id).subscribe({
      next: (data) => {
        console.log(data);
        this.getStaticPages();
      },
    });
  }

  onUpdate() {
    this.staticPage = this.StaticPageForm.value;
    this.staticPagesService.updateStatic(this.staticPage).subscribe({
      next: (data) => {
        this.staticPage = data;
        console.log(this.staticPage);
        this.getStaticPages();
      },
    });
    this.StaticPageForm.reset();
    this.updateded = true;
  }
  populateForm(staticPage: IStaticPages) {
    this.updateded = false;
    this.StaticPageForm = new FormGroup({
      pageName: new FormControl(staticPage.pageName, [Validators.required]),
      details: new FormControl(staticPage.details, [Validators.required]),
      id: new FormControl(staticPage.id, [Validators.required]),

    });
    this.staticPage = staticPage;
  }
}
