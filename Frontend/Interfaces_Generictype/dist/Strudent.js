"use strict";
class studentClass {
    constructor(fName, lName, Age, listCourses) {
        this.firstName = fName;
        this.lastName = lName;
        this.age = Age;
        this.courses = listCourses;
    }
    enroll(courseName) {
        this.courses.push(courseName);
    }
    listOfCourses() {
        return this.courses;
    }
    removeInde(index) {
        this.courses = this.courses.filter(i => i != index);
    }
}
var student1 = new studentClass("Ruba", "Fikri", 23, []);
student1.enroll("Programming");
student1.enroll("Proming");
student1.enroll("Progr");
console.log(student1.listOfCourses());
console.log(student1);
student1.removeInde("Programming");
console.log(student1.listOfCourses());
