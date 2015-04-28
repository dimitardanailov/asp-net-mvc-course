module Models {
  export module ShoolSubjects {
    export class Base {
        private name: string;
        private score: number;

        getScore(): number {
            return this.score;
        }
    }
  }
}
