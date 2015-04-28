interface Person {
  firstname: string;
  lastname: string;
}

function greeter(person : Person) {
  console.log("Hello, "+ person.firstname + " " + person.lastname);
}

var person = {firstname: "Dimitar", lastname: "Danailov"};
greeter(person);
