/// <reference path="Models/Users/Parent.ts"/>
/// <reference path="Models/Users/Child.ts"/>

var maria = new Models.Users.Child();
maria.addShoolSubject(new Models.ShoolSubjects.Music());
var georgi = new Models.Users.Child();
georgi.addShoolSubject(new Models.ShoolSubjects.Mathematics());

var petar = new Models.Users.Parent(100);
petar.addChildren(maria);
petar.addChildren(georgi);
