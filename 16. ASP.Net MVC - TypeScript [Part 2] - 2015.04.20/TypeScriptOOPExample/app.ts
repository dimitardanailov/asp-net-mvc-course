// Enum
enum Gender { Male, Female };

// Base Class
class Human {
    protected firstName: string;
    protected lastName: string;
    protected gender: Gender;
    protected age: number;

    // Example: Default Arguments
    constructor(name: string = "Name", lastName: string = "LastName", gender: Gender = Gender.Male, age: number = 0) {
        this.firstName = name;
        this.lastName = lastName;
        this.gender = gender;
        this.age = age;
    }

    getAge(): number {
        return this.age;
    }
}

class Parent extends Human {
    protected salary: number;
    protected children:Array<Child> = [];

    constructor(salary: number, name: string = "Name", lastName: string = "LastName", gender: Gender = Gender.Male, age: number = 0) {
        super(name, lastName, gender, age);
        this.salary = salary;
    }

    /**
    Add Child to my collection
    */
    addChildren(child: Child) {
        this.children.push(child);
    }
}

class Child extends Human {

    private shoolSubjects: Array<ShoolSubject> = [];
    
    addShoolSubject<T extends ShoolSubject>(shoolSubject: T) {
        shoolSubject.getScore();
    }
}

class ShoolSubject {
    private name: string;
    private score: number;

    getScore(): number {
        return this.score;
    }
}

class Mathematics extends ShoolSubject {

}

class Music extends ShoolSubject {
}

var maria = new Child();
maria.addShoolSubject(new Music());
var georgi = new Child();
georgi.addShoolSubject(new Mathematics());

var petar = new Parent(100);
petar.addChildren(maria);
petar.addChildren(georgi);
