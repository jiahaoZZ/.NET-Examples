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

### Generic types

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

### Collections

There are 2 main types of collections; generic collection and non-generic collection.

Generic collection

- type safe at compile time
- better performance
- no needs to transform from and to objects when add or remove items from collections

Non-generic collection

- store items as objects
- require casting

| I want to…                                                                                                                                                                                                                                                                                                                                     | Generic collection options                                                                                                                                                                     | Non-generic collection options                                                                                                                                                  | Thread-safe or immutable collection options                                                                                                                                                                                                                                                                                                                               |
|:-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|:-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|:--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|:--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Store items as key/value pairs for quick look-up by key                                                                                                                                                                                                                                                                                        | [Dictionary](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2)                                                                                             | [Hashtable](https://learn.microsoft.com/en-us/dotnet/api/system.collections.hashtable)  (A collection of key/value pairs that are organized based on the hash code of the key.) | [ConcurrentDictionary](https://learn.microsoft.com/en-us/dotnet/api/system.collections.concurrent.concurrentdictionary-2)  [ReadOnlyDictionary](https://learn.microsoft.com/en-us/dotnet/api/system.collections.objectmodel.readonlydictionary-2)  [ImmutableDictionary](https://learn.microsoft.com/en-us/dotnet/api/system.collections.immutable.immutabledictionary-2) |
| Access items by index                                                                                                                                                                                                                                                                                                                          | [List](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)                                                                                                         | [Array](https://learn.microsoft.com/en-us/dotnet/api/system.array)  [ArrayList](https://learn.microsoft.com/en-us/dotnet/api/system.collections.arraylist)                      | [ImmutableList](https://learn.microsoft.com/en-us/dotnet/api/system.collections.immutable.immutablelist-1)  [ImmutableArray](https://learn.microsoft.com/en-us/dotnet/api/system.collections.immutable.immutablearray)                                                                                                                                                    |
| Use items first-in-first-out (FIFO)                                                                                                                                                                                                                                                                                                            | [Queue](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.queue-1)                                                                                                       | [Queue](https://learn.microsoft.com/en-us/dotnet/api/system.collections.queue)                                                                                                  | [ConcurrentQueue](https://learn.microsoft.com/en-us/dotnet/api/system.collections.concurrent.concurrentqueue-1)  [ImmutableQueue](https://learn.microsoft.com/en-us/dotnet/api/system.collections.immutable.immutablequeue-1)                                                                                                                                             |
| Use data Last-In-First-Out (LIFO)                                                                                                                                                                                                                                                                                                              | [Stack](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.stack-1)                                                                                                       | [Stack](https://learn.microsoft.com/en-us/dotnet/api/system.collections.stack)                                                                                                  | [ConcurrentStack](https://learn.microsoft.com/en-us/dotnet/api/system.collections.concurrent.concurrentstack-1)  [ImmutableStack](https://learn.microsoft.com/en-us/dotnet/api/system.collections.immutable.immutablestack-1)                                                                                                                                             |
| Access items sequentially                                                                                                                                                                                                                                                                                                                      | [LinkedList](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.linkedlist-1)                                                                                             | No recommendation                                                                                                                                                               | No recommendation                                                                                                                                                                                                                                                                                                                                                         |
| Receive notifications when items are removed or added to the collection. (implements [INotifyPropertyChanged](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.inotifypropertychanged) and [INotifyCollectionChanged](https://learn.microsoft.com/en-us/dotnet/api/system.collections.specialized.inotifycollectionchanged)) | [ObservableCollection](https://learn.microsoft.com/en-us/dotnet/api/system.collections.objectmodel.observablecollection-1)                                                                     | No recommendation                                                                                                                                                               | No recommendation                                                                                                                                                                                                                                                                                                                                                         |
| A sorted collection                                                                                                                                                                                                                                                                                                                            | [SortedList](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.sortedlist-2)                                                                                             | [SortedList](https://learn.microsoft.com/en-us/dotnet/api/system.collections.sortedlist)                                                                                        | [ImmutableSortedDictionary](https://learn.microsoft.com/en-us/dotnet/api/system.collections.immutable.immutablesorteddictionary-2)  [ImmutableSortedSet](https://learn.microsoft.com/en-us/dotnet/api/system.collections.immutable.immutablesortedset-1)                                                                                                                  |
| A set for mathematical functions                                                                                                                                                                                                                                                                                                               | [HashSet](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.hashset-1)  [SortedSet](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.sortedset-1) | No recommendation                                                                                                                                                               | [ImmutableHashSet](https://learn.microsoft.com/en-us/dotnet/api/system.collections.immutable.immutablehashset-1)  [ImmutableSortedSet](https://learn.microsoft.com/en-us/dotnet/api/system.collections.immutable.immutablesortedset-1)                                                                                                                                    |

### Delegate and lambda

Delegate represents the reference to a method and it has predefined the parameters and return types.

There are 3 build-in delegates which are Action, Func and Predicate...

Action

- return void
- can have 16 parameters as maximum

Func

- can define the return type as the last parameter
- can have 15 parameters as maximum

Predicate

- could be rewritten as Func<T, bool>

### Events

Event is based on delegate and set a invocation. Once the invocation is occurred, the actual methods (delegate points
to) will be performed.

### Exceptions

When program got errors, we can throw the exception.

The most frequently used is try/catch.

We can also actively throw a exception with "throw" keyword.

We can define our own exception by inheriting exception class.

### Numeric types

Hmmm...not too clear about this one

### Date, time, time zone

The default time is local time. we can setting it as global time by utc.

format it by

```c#
DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
```

### Attribute

a way to add metadata to code elements such as assemblies, types, methods, properties, classes.

we can write our own attribute by inheriting Attribute class.

To summarize, add metadata for reflection.

## Runtime Libraries

[TODO]

## Execution Model

[TODO]





