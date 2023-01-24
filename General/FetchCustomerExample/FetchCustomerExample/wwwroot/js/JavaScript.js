const AddNewCustomer = document.querySelector("#AddNewCustomer");
const FirstName = document.querySelector("#FirstName");
const LastName = document.querySelector("#LastName");
const CustomerList = document.querySelector("#CustomerList");
const GetAllCustomers = document.querySelector("#GetAllCustomers");
const CustomerAddForm = document.querySelector("#CustomerAddForm");
const LoadingSpinner = document.querySelector("#LoadingSpinner");


GetAllCustomers.addEventListener("click", (event) => {
    alert("HELLO");
    GetAllCustomers.innerHTML = `<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span>  Loading...`;

    fetch("https://localhost:7229/Customer/GetCustomer").then((response) => {
        return response.json();
    }).then((data) => {
        CustomerList.innerHTML = data.map(element => `<li class="list-group-item">${element.firstName} ${element.firstName}</li>`).join("\n");
        console.log(data);
        GetAllCustomers.innerHTML = 'Get Customers Full Names';

    });

    event.preventDefault();
});

CustomerAddForm.addEventListener("submit", (event) => {
    LoadingSpinner.innerHTML = "<p>Loading ...</p>";

    fetch("https://localhost:7229/Customer/AddJsonCustomer", {
        method: "POST",
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ firstName: FirstName.value, lastName: LastName.value })
    }).then((response) => {
        return response.json();
    }).then((data) => {
        console.log(data);
        CustomerList.innerHTML += `<li class="list-group-item">${data.firstName} ${data.firstName}</li>`;
        FirstName.value = '';
        LastName.value = '';
        LoadingSpinner.innerHTML = "";


    });
    event.preventDefault();

});
console.log(GetAllCustomers);



