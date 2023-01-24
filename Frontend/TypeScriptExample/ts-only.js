var FirstName = document.getElementById("firstName");
var LastName = document.getElementById("lastName");
var btn = document.getElementById("button");
function EvenOrOdd(n1) {
    if (n1 % 2 == 0) {
        return "The Number is even";
    }
    else {
        return "The Number is odd";
    }
}
console.log(EvenOrOdd(11));
function getPerson(person) {
    return person.firstName + " " + person.lastName;
}
btn.addEventListener("click", function () {
    console.log(getPerson({ firstName: FirstName.value, lastName: LastName.value }));
});
