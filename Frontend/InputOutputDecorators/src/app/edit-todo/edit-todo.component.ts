import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ITodo } from '../models/ITodo';

@Component({
  selector: 'app-edit-todo',
  templateUrl: './edit-todo.component.html',
  styleUrls: ['./edit-todo.component.css']
})
export class EditTodoComponent implements OnInit {

  @Input()  todo! : ITodo;
  title: string = "";
  description : string = "";
  isImportant : boolean = false;

  @Output() todoUpdated = new EventEmitter<ITodo>();

  constructor() { }

  ngOnInit(): void {
    this.title = this.todo.title;
    this.description = this.todo.description;
    this.isImportant = this.todo.isImportant;


  }
  onUpdateTodo(){
    let todo: ITodo={
      id: this.todo.id,
      title: this.title,
      description: this.description,
       isImportant: this.isImportant
    } 
    this.todoUpdated.emit(todo);
    

  }

}
