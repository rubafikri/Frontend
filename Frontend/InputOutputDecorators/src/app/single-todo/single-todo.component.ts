import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ITodo } from '../models/ITodo';

@Component({
  selector: 'app-single-todo',
  templateUrl: './single-todo.component.html',
  styleUrls: ['./single-todo.component.css']
})
export class SingleTodoComponent implements OnInit {

  @Input() todo :ITodo  = {title: " " , description: "" , isImportant: false};
  @Output() todoEditted  = new EventEmitter<ITodo>() ;
  @Output() todoDeleted = new EventEmitter<ITodo>();

  constructor() { }

  ngOnInit(): void {
  }

  onEditTodo(){
    this.todoEditted.emit(this.todo);
  }

  OnDeleteTodo(){
    this.todoDeleted.emit(this.todo) ;
  }
}
