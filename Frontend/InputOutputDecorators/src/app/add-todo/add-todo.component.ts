import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { ITodo } from '../models/ITodo';

@Component({
  selector: 'app-add-todo',
  templateUrl: './add-todo.component.html',
  styleUrls: ['./add-todo.component.css']
})
export class AddTodoComponent implements OnInit {
title: string = '';
description: string = '';

isImportant: boolean = false;

@Output() todoAdded = new EventEmitter<ITodo>();

 constructor() { }

  ngOnInit(): void {
  }

  OnAddTodo(){
    let todo : ITodo = {
      title: this.title,
      description: this.description,
      isImportant: this.isImportant
    };
    this.todoAdded.emit(todo);
    this.title = '';
    this.description = '';
    this.isImportant = false;


  }

}
