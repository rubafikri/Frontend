import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  title = 'HttpClientExample';
  AddTodoForm: FormGroup;

  isFetching = false;
  loadedTodos: {
    id: number;
    title: string;
    completed: string;
    userId: number;
  }[] = [];

  baseUrl = environment.baseUrl + '/add';
  constructor(private httpClient: HttpClient) {}
  ngOnInit(): void {
    this.AddTodoForm = new FormGroup({
      title: new FormControl('', [Validators.required]),
      completed: new FormControl('', Validators.required),
      userId: new FormControl(''),
    });
  }
  onSubmit() {
    console.log(this.AddTodoForm.value);
    this.httpClient
      .post(this.baseUrl, this.AddTodoForm.value)
      .subscribe((responseData) => {
        console.log(responseData);
      });
  }
  onGetTodos() {
    this.isFetching = true;
    this.httpClient
      .get<
        {
          id: number;
          title: string;
          completed: string;
          userId: number;
        }[]
      >('https://jsonplaceholder.typicode.com/todos')
      .subscribe({
        next: (data) => {
          this.loadedTodos = data;
          this.isFetching = false;
          console.log();
        },
        error: (error) => {
          this.isFetching = false;
        },
      });
  }
  onDeleteTodo(todoId: number) {
    this.httpClient
      .delete(`https://jsonplaceholder.typicode.com/todos/${todoId}`)
      .subscribe((response) => {
        console.log(response);
        this.onGetTodos();
      });
  }
}
