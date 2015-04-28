module Models {
  export module Users {
    export class Parent extends Models.Users.Human {
        protected salary: number;
        protected children:Array<Models.Users.Child> = [];

        constructor(salary: number,
          name: string = "Name",
          lastName: string = "LastName",
          gender: Enum.Gender = Enum.Gender.Male,
          age: number = 0) {
            super(name, lastName, gender, age);
            this.salary = salary;
        }

        /**
        Add Child to my collection
        */
        addChildren(child: Models.Users.Child) {
            this.children.push(child);
        }
    }
  }
}
