# This repository is for self-learning and it stands on the office docs of [.NET](https://learn.microsoft.com/en-us/dotnet/fundamentals/)



## Fundamental Coding Components 

### Base Type Overview

#### Common Type System

All Types in .NET are either value type or reference type. 

- Value Type: contain the actual values.
- Reference Type:  like a pointer in C, that hold the memory address where the actual value is at.



The main difference between reference type and value type is at below code.

```c#
class Program
{
    static void Main()
    {
        int a = 5; // value type
        int b = a; // a copy of the value is assigned to b

        b = 10; // modifying b does not affect the value of a

        Console.WriteLine($"a: {a}"); // Output: a: 5
        Console.WriteLine($"b: {b}"); // Output: b: 10
    }
}


class Program
{
    class MyClass
    {
        public int Value { get; set; }
    }

    static void Main()
    {
        MyClass x = new MyClass(); // reference type
        x.Value = 5;

        MyClass y = x; // y now refers to the same object as x

        y.Value = 10; // modifying y also affects the value of x

        Console.WriteLine($"x.Value: {x.Value}"); // Output: x.Value: 10
        Console.WriteLine($"y.Value: {y.Value}"); // Output: y.Value: 10
    }
}

```



|       Object        | Type           |
| :-----------------: | -------------- |
| All primitive types | Value Type     |
|        Class        | Reference Type |
|       Struct        | Value Type     |
|        Enum         | Value Type     |
|      Interface      | Reference Type |
|      Delegate       | Reference Type |
|      Attribute      | Reference Type |

|  Keyword  |                           Meaning                            |
| :-------: | :----------------------------------------------------------: |
| abstract  | has not been implemented. <br /> All derived types need the implementation |
|  private  | Members with private access modifier are only accessible within the same class or struct. |
|  public   | Members with public access modifier are accessible from any other class or assembly. |
| protected | Members with protected access modifier are accessible within the same class or by derived classes. |
| internal  | Members with internal access modifier are accessible within the same assembly |
|   final   |  The virtual method cannot be overridden in a derived type.  |
|   init    | The value can only be initialized, and cannot be written after initialization. |
|  static   | The member belongs to the type it is defined on, not to a particular instance of the type; the member exists even if an instance of the type is not created, and it is shared among all instances of the type. |
|  virtual  | The method can be implemented by a derived type and can be invoked either statically or dynamically. |
|           |                                                              |



#### Generic types

Generic type is the type being defined in advanced and being replaced when utilization. It supports for class, struct and interface. 



``` c#
public class MyClass<T>{
    T MyField;
}
```

it supports Covariance and Contravariance. 

Covariance enables you to use a more derived type than originally specified.

```c#
// Covariance Examples

// out keyword to enable covariance
public interface IMyInterface<out T>{
    T GetValue();
}

public class MyClass : IMyInterface<string>{
    public string GetValue() => "Covariance"; 
}

MyClass newInstanceA = new MyClass(); // what we do usually
// My class implements the interface, 
// so class is more derived than interface
// then we can assign this more derived class to original interface
IMyInterface<string> newInstanceB = new MyClass(); 

```

Contravariance enables you to use a more generic (less derived) type than originally specified.

```c#
// contravariance example

// in keyword to enable contravariance
public class Person{
    public string Name {get;set;}
}

public class Student : Person{
    
}

public static class 
```



Invariance means that you can use only the type originally specified. An invariant generic type parameter is neither covariant nor contravariant.

