"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class Itodo {
    constructor(id, task, isCompleted, dueDate, description, toDoCategoryId) {
        this.id = id;
        this.task = task;
        this.isCompleted = isCompleted;
        this.dueDate = dueDate;
        this.description = description;
        this.toDoCategoryId = toDoCategoryId;
    }
}
exports.default = Itodo;
