namespace GenericExamples;

public class Person
{
    public virtual string Name { get; set; } = "Person";
}

public class Student : Person
{
    public override string Name { get; set; } = "Student";
}

public static class Say
{
    public static void WhoAmI(Person person)
    {
        Console.WriteLine(person.Name);
    }
}

public delegate void SaySomething<in T>(T t);