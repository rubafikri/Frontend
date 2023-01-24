import axios from "axios";
import { itodo } from "./itodo";

const todolist = document.querySelector(".todo-list")!;
const btnAddData = document.getElementById("btnAddData")! as HTMLButtonElement;
const formEdit = document.getElementById("formEdit")!;
const formAdd = document.getElementById("formAdd")!;

const BASEURL = "https://localhost:7253";

let itodo1: itodo;
btnAddData.addEventListener("click", (event) => {
  event.preventDefault();
  CreateAddForm();
});

//create table that contains all items with Edit and Delete buttons.
function addItem(todoItem: itodo) {
  const elementLI = document.createElement("tbody");
  const elementTR = document.createElement("tr");
  const elementTD = document.createElement("td");
  elementTD.innerText = todoItem.task;
  const elementTD1 = document.createElement("td");
  elementTD1.innerText = todoItem.dueDate;
  const elementTD2 = document.createElement("td");
  elementTD2.innerText = todoItem.description;
  elementLI.appendChild(elementTR);
  elementTR.appendChild(elementTD);
  elementTR.appendChild(elementTD1);
  elementTR.appendChild(elementTD2);
  const elementTD3 = document.createElement("td");
  const deleteButton = document.createElement("button");
  deleteButton.className = "btn btn-primary";
  deleteButton.innerText = "Delete";
  elementTD3.appendChild(deleteButton);
  deleteButton.addEventListener("click", (event) => {
    axios
      .delete(`https://localhost:7253/api/todo?id=${todoItem.id}`, {
        method: "DELETE",
      })
      .then(() => location.reload())
      .catch((e) => console.log(e));
    console.log(todoItem.task);
    elementLI.remove();
  });
  elementTR.appendChild(elementTD3);
  const elementTD4 = document.createElement("td");
  const editButton = document.createElement("button");
  editButton.innerText = "Edit";
  editButton.className = "btn btn-primary";
  elementTD4.appendChild(editButton);
  editButton.addEventListener("click", (e) => {
    e.preventDefault();
    CreateEditForm(todoItem);
  });

  elementTR.appendChild(elementTD4);
  todolist.appendChild(elementLI);
}
// get All todos from Database Using Api
axios.get(`${BASEURL}/Getall`).then((response) => {
  console.log(response.data.task);
  for (var i = 0; i < response.data.length; i++) {
    itodo1 = response.data[i];
    addItem(itodo1);
  }
});

//Create Edit Form for Edit Any Todo you want
function CreateEditForm(todoItem: itodo) {
  const form = document.createElement("form");
  form.setAttribute("method", "POST");
  const input = document.createElement("input");
  input.setAttribute("type", "text");
  input.setAttribute("name", "task");
  input.value = todoItem.task;
  const input1 = document.createElement("input");
  input1.setAttribute("type", "text");
  input1.setAttribute("name", "description");
  input1.value = todoItem.description;
  const input2 = document.createElement("input");
  input2.setAttribute("type", "text");
  input2.setAttribute("name", "dueDate");
  input2.value = todoItem.dueDate;
  const input3 = document.createElement("input");
  input3.setAttribute("type", "checkbox");
  input3.setAttribute("name", "isCompleted");
  input3.checked = todoItem.isCompleted;

  const button = document.createElement("button");
  button.setAttribute("type", "submit");
  button.innerText = "Edit";
  form.appendChild(input);
  form.appendChild(input1);
  form.appendChild(input2);
  form.appendChild(input3);
  form.appendChild(button);
  formEdit.appendChild(form);
  button.addEventListener("click", (e) => {
    e.preventDefault();
    axios
      .put(`https://localhost:7253/api/todo/${todoItem.id}`, {
        task: input.value,
        description: input1.value,
        isCompleted: input2.checked,
      })
      .then((res) => {
        console.log(res.data);
      })
      .then(() => location.reload())
      .catch((e) => console.log(e));
    form.remove();
  });
}
//Create Add Form for add Todo
function CreateAddForm() {
  const form = document.createElement("form");
  form.setAttribute("method", "POST");
  const input = document.createElement("input");
  input.setAttribute("type", "text");
  input.setAttribute("name", "task");
  input.setAttribute("placeholder", "Task");
  input.className = "form-control";
  const input1 = document.createElement("input");
  input1.setAttribute("type", "text");
  input1.setAttribute("name", "description");
  input1.setAttribute("placeholder", "Description");
  input1.className = "form-control";
  const input2 = document.createElement("input");
  input2.setAttribute("type", "date");
  input2.setAttribute("name", "dueDate");
  input2.className = "form-control";
  const label = document.createElement("label");
  label.innerText = "Is completed";
  const input3 = document.createElement("input");
  input3.setAttribute("type", "checkbox");
  input3.setAttribute("name", "isCompleted");
  input3.className = "form-check-input";
  const button = document.createElement("button");
  button.setAttribute("type", "submit");
  button.innerText = "Add";
  button.className = "btn btn-primary";
  button.addEventListener("click", function (event) {
    event.preventDefault();
    axios
      .post(`https://localhost:7253/addpost`, {
        task: input.value,
        isCompleted: input3.checked,
        dueDate: input2.value,
        description: input1.value,
        toDoCategoryId: 1,
      })
      .then(function (response) {
        console.log(response);
      })
      .then(() => location.reload())
      .catch(function (error) {
        console.log(error);
      });
    form.remove();
  });
  form.appendChild(input);
  form.appendChild(input1);
  form.appendChild(input2);
  form.appendChild(input3);
  form.appendChild(label);
  form.appendChild(button);
  formAdd.appendChild(form);
}
