function greeter(person) {
    console.log("Hello, " + person.firstname + " " + person.lastname);
}
var person = { firstname: "Dimitar", lastname: "Danailov" };
greeter(person);
