import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CategoryService } from '../Services/category.service';
import { ICategory } from '../interfaces/ICategory';
import { ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css'],
})
export class CategoryComponent implements OnInit {
  CategoryForm!: FormGroup;
  loadedCategory: ICategory[];
  cat: ICategory;
  updateded: boolean = true;
  constructor(
    private categoryService: CategoryService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.CategoryForm = new FormGroup({
      name: new FormControl('', [Validators.required]),
    });

    this.getCategory();
  }
  get name() {
    return this.CategoryForm.get('name') as FormControl;
  }

  onSubmit() {
    const { name } = this.CategoryForm.value;
    this.categoryService.addCategory(name).subscribe({
      next: (data) => {
        console.log(data);
        this.cat = data;
        this.getCategory();
        this.CategoryForm.reset();
      },
    });
  }

  getCategory() {
    this.categoryService.getCategory().subscribe({
      next: (data) => {
        this.loadedCategory = data;
        console.log(this.loadedCategory);
      },
    });
  }
  onDeleteCategory(id: number) {
    this.categoryService.deleteCategory(id).subscribe({
      next: (data) => {
        console.log(data);
        this.getCategory();
      },
    });
  }

  onUpdate() {
    this.cat = this.CategoryForm.value;
    console.log(this.cat);
    this.categoryService.updateCategory(this.cat).subscribe({
      next: (data) => {
        this.cat = data;
        console.log(this.cat);
        this.getCategory();
      },
    });
    this.CategoryForm.reset();
    this.updateded = true;
  }
  populateForm(cat: ICategory) {
    this.updateded = false;
    this.CategoryForm = new FormGroup({
      name: new FormControl(cat.name, [Validators.required]),
      id: new FormControl(cat.id, [Validators.required]),
    });
    this.cat = cat;
    console.log(cat);
  }
}
