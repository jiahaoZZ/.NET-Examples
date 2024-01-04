namespace GenericExamples;

public interface IMyInterface<out T>
{
    T GetValue();
}

public class MyClass : IMyInterface<string>
{
    public string GetValue() => "Covariance";
}