// See https://aka.ms/new-console-template for more information

using GenericExamples;

// Covariance usage 
MyClass newInstanceA = new MyClass();
IMyInterface<string> newInstanceB = new MyClass(); // more derived to less derived
Console.WriteLine(newInstanceA.GetValue());
Console.WriteLine(newInstanceB.GetValue());

// Contravariance usage
var person = new Person();
var student = new Student();
Say.WhoAmI(person);
Say.WhoAmI(student); // less derived to more derived
SaySomething<Person> saySomething = Say.WhoAmI;
saySomething.Invoke(person);
saySomething.Invoke(student);