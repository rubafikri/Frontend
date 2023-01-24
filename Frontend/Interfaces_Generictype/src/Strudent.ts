class studentClass{
firstName: string;
lastName: string;
age : number;
private courses : string[];

constructor(fName:string , lName: string , Age: number , listCourses: string []){
  this.firstName = fName;
  this.lastName = lName;
  this.age = Age;
  this.courses = listCourses;
}
  enroll(courseName: string)  : void {
   this.courses.push(courseName); 
}
listOfCourses(){
  return this.courses;
}

removeInde(index: string) : void{
  this.courses = this.courses.filter(i => i != index );
}
}
var student1 = new  studentClass("Ruba" , "Fikri" , 23 , []);
student1.enroll("Programming");
student1.enroll("Proming");
student1.enroll("Progr");
console.log(student1.listOfCourses());
console.log(student1);
student1.removeInde("Programming");
console.log(student1.listOfCourses());
