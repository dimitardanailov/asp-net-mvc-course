/// <reference path="../ShoolSubject/Base.ts"/>

module Models {
  export module Users {
    export class Child extends Models.Users.Human {

        private shoolSubjects: Array<Models.ShoolSubjects.Base> = [];

        addShoolSubject<T extends Models.ShoolSubjects.Base>(shoolSubject: T) {
            shoolSubject.getScore();
        }
    }
  }
}
