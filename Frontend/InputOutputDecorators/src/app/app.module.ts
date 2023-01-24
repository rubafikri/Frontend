import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { TodosComponent } from './todos/todos.component';
import { SingleTodoComponent } from './single-todo/single-todo.component';
import { AddTodoComponent } from './add-todo/add-todo.component';
import { FormsModule } from '@angular/forms';
import { EditTodoComponent } from './edit-todo/edit-todo.component';

@NgModule({
  declarations: [
    AppComponent,
    TodosComponent,
    SingleTodoComponent,
    AddTodoComponent,
    EditTodoComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
