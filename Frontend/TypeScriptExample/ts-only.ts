const FirstName = document.getElementById("firstName") ! as HTMLInputElement;
const LastName = document.getElementById("lastName") ! as HTMLInputElement;
const btn = document.getElementById("button") ! as HTMLButtonElement;

function EvenOrOdd(n1 : number) {
    if(n1 % 2 == 0){
        return "The Number is even";
    }else{
         return "The Number is odd";
    }
}


console.log(EvenOrOdd(11));

function getPerson(person : 
    {firstName: string , 
        lastName: string
    }){
    return person.firstName + " " + person.lastName;
}

btn.addEventListener("click" , ()=>{
    console.log(getPerson({ firstName: FirstName.value , lastName: LastName.value}));
});


