import axios from "axios";

const BASEURL = "https://localhost:7253";

const todolist = document.querySelector(".todo-list"); 
const btnAddData = document.getElementById("btnAddData");
const TaskAdd = document.getElementById("TaskAdd");
const Description = document.getElementById("Description");
const CreatedAt = document.getElementById("CreatedAt");
const Category = document.getElementById("Category");
const btnEditData = document.getElementById("btnEditData");


// getting all data from api and show it in cards 
let table = '';
  axios.get(`${BASEURL}/Getall`).then((response) => {
    console.log(response.data[0].id);

for (var i = 0; i < response.data.length; i++) {
      table = `
  <div class="card" style="width: 18rem;">
  <div data-id = ${response.data[i].id} class="card-body">
    <h5 class="card-title">${response.data[i].task}</h5>
    <h5 class="card-title">${response.data[i].isCompleted}</h5>
    <h6 class="card-subtitle mb-2 text-muted">${response.data[i].dueDate}</h6>
    <p class="card-text">${response.data[i].description}</p>
    <a href="#" class="card-link"  id='edit'>Edit</a>
    <a href="#" class="card-link" id='delete'>Delete</a>
  </div>
</div>`;

todolist.innerHTML += table;
    }
  }).catch((error) => {
    console.log(error);
  });


// click event for adding new todo in our database by Api
  btnAddData.addEventListener("click", function (event) {
  event.preventDefault();
  axios.post(`https://localhost:7253/addpost`, {
    task: TaskAdd.value,
    isCompleted: true,
    dueDate: CreatedAt.value,
    description: Description.value,
    toDoCategoryId: Category.value
  })
    .then(function (response) {
      console.log(response);
    }).then(() => location.reload())
    .catch(function (error) {
      console.log(error);
    });

});


// new event for delete record from database using api methods
todolist.addEventListener("click", (e) => {
  e.preventDefault();
  let deletebutton = e.target.id == 'delete';
  let editbutton = e.target.id == 'edit';
  let id = e.target.parentElement.dataset.id;
  console.log(id);
if(deletebutton){
  axios.delete(`https://localhost:7253/api/todo?id=${id}`, {
    method: 'DELETE',
  })
  .then(()=> location.reload())
  .catch((e) => console.log(e));

  // new event for update record from database using api methods
}else if(editbutton){
  const parent = e.target.parentElement;
  let task1 = parent.querySelector(".card-title").textContent;
  let duedate1 = parent.querySelector(".card-subtitle").textContent;
  let description1 = parent.querySelector(".card-text").textContent;
  
  TaskAdd.value = task1;
  CreatedAt.value = duedate1;
  Description.value = description1;
  
  btnEditData.style.visibility = 'visible';


}
btnEditData.addEventListener("click" , (e)=>{
  e.preventDefault();
  axios.put(`https://localhost:7253/api/todo/${id}`,{
    
    
      id: id,
      task : TaskAdd.value , 
      dueDate: CreatedAt.value,
      description : Description.value,
      isCompleted : true,
      toDoCategoryId: Category.value
      

    
  }).then((res)=>{
    console.log(res.data);
  })
  .then(()=> location.reload())
  .catch((e) => console.log(e));
});

});





