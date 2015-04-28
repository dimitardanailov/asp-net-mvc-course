/// <reference path="../../Enums/Gender.ts"/>

module Models {
  export module Users {
    export class Human {
        protected firstName: string;
        protected lastName: string;
        protected gender: Enum.Gender; // Enum
        protected age: number;

        // Example: Default Arguments
        constructor(name: string = "Name",
          lastName: string = "LastName",
          gender: Enum.Gender = Enum.Gender.Male,
          age: number = 0) {

            this.firstName = name;
            this.lastName = lastName;
            this.gender = gender;
            this.age = age;
        }

        getAge(): number {
            return this.age;
        }
    }
  }
}
