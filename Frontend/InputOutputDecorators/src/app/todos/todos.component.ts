import { Component, OnInit } from '@angular/core';
import { ITodo } from '../models/ITodo';

@Component({
  selector: 'app-todos',
  templateUrl: './todos.component.html',
  styleUrls: ['./todos.component.css'],
})
export class TodosComponent implements OnInit {
  showAddForm = true;
  showEditForm = false;

  isImportant = false;
  todos: ITodo[] = [
    {
      id: 1,
      title: 'Learn Angular',
      description:
        'I have to watch all videos about CRUD operations using Angular',
      isImportant: false,
    },
    {
      id: 2,
      title: 'Learn ASP.NET',
      description:
        'I have to watch all videos about CRUD operations using ASP.NET',
      isImportant: true,
    },
  ];
  count =this.todos.length;

  edittedTodo: ITodo = { title: ' ', description: '', isImportant: false };
  constructor() {}
  ngOnInit(): void {}

  onTodoAdded(todo: ITodo) {
    todo.id = this.todos.length + 1;
    this.todos.push(todo);
    this.count = this.todos.length;

  }

  importantOrNot(todo : ITodo) {
    this.isImportant  = todo.isImportant;
    return this.isImportant;
  }

  onTodoEditted(todo: ITodo) {
    this.edittedTodo = todo;
    this.showAddForm = false;
    this.showEditForm = true;
  }
  onUpdatedTodo(todo: ITodo) {
    this.todos = this.todos.map((to) => {
      if (todo.id == to.id) {
        this.showAddForm = true;
        this.showEditForm = false;
        return todo;
      }
      this.showAddForm = true;
      this.showEditForm = false;
      return to;
    });
  }
  removeItem(todo: ITodo) {
    this.todos = this.todos.filter((to) => to.id != todo.id);
  }
}
