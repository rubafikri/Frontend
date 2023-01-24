"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const axios_1 = __importDefault(require("axios"));
const itodo_1 = require("./itodo");
const todolist = document.querySelector(".todo-list");
const btnAddData = document.getElementById("btnAddData");
const TaskAdd = document.getElementById("TaskAdd");
const Description = document.getElementById("Description");
;
const CreatedAt = document.getElementById("CreatedAt");
const Category = document.getElementById("Category");
const btnEditData = document.getElementById("btnEditData");
btnAddData.addEventListener("click", function (event) {
    event.preventDefault();
    var itodo1;
    itodo1 = new itodo_1.itodo();
    itodo1.id = 1;
    itodo1.task = TaskAdd.value;
    itodo1.isCompleted = true;
    itodo1.dueDate = CreatedAt.value;
    itodo1.description = Description.value;
    itodo1.toDoCategoryId = +Category.value;
    axios_1.default.post(`https://localhost:7253/addpost`, itodo1)
        .then(function (response) {
        console.log(response);
    }).then(() => location.reload())
        .catch(function (error) {
        console.log(error);
    });
});
