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

### Format 

The default is to override the Object.ToString() method to define a custom representation of an object's value.

### Work with Strings

nothing special, google it.

### Regular Expression

System.Text.RegularExpression.Regex

nothing special, google it.

### Serialization

JsonSerializer.Serialize() and JsonSerializer.Deserialize()

nothing special, google it.



### System.CommandLine

Currently in PREVIEW. 

Do it later if needed. [TODO]



### File and Stream I/O

[docs](https://learn.microsoft.com/en-us/dotnet/standard/io/)



### Dependency Injection (DI)

This is pretty important in software development. 

DI always appears with Inversion of Control (IoC). You can google it what they are. I'll write my own understanding here. 

Consider the following senario.

> We eat something when we were hungry. For example, we want to eat pizza, burger and drink cola. 
>
> The essential thing is that, we need to cook and get the food (went to supermarket to buy ingredients, went to kitchen ... finally, wash the dishes, and put rubbish into bins )
>
> so if we want to eat them, we have the dependencies, that the steps we need to do before get the food and after eat. 
>
> However, we had an optimized solution. We can say "Mom!!!!!!" and she will do it for us. What we we need to do is eat (focus on what we want) 

It's similar in the software development.

> We write our own entities and operate the business logic in our own domain/module. 
>
> The essential thing is that, our domain/module are not isolated and may have the relationship or communication with the others. (For example, we (we are the developers) need to log the details on somewhere if throw an exception. We want it stored locally as a text file, and also stored remotely which benefit on Testers/Operators (as they might have no access to the host deploying the application)).
>
> so if we want to log the detail, we have the dependencies, that the steps we need to do before and after logging, such as how to create a logger, how to guarantee the details are logged successfully, how to release the memory when it was not used anymore(otherwise might cause memory leak)
>
> However, we had an optimize solution. We can say "system" and it will do everything for us. What we need to do is that log the error (focus on the error message)

Before the implementation of DI, we depends on something. The IoC is a concept and DI is the implementation of IoC. We add services into the "container" and then system will prepare what we need. If we want to use certain services, we just inject those required services (Dependencies) into constructors and use it in our methods. 



There are 3 types of lifetime we can register services with

- Transient, create an new instance for you every time
- Scoped, create a new instance for each request/connection
- Singleton, create a single and unique instance at first time. Use the same instance at all time.



### Configuration

Read configuration from different sources. So we can dynamically change the configuration without updating code or program.

Configurations types can be simply divided into 2 parts, host app config.

Host config contains server related configs, such as content root path, environment name. They are for the entire application regardless any individual components.

App config are for the rest. 

### Logging

When application/system is running, it can produces some logs that help people understand the running details, are they started, any errors, something like that. 

Build in is console log, which write logs into console. Can be logged on Seq, ES. 

It can also be logged with the third party tools, such as NLog, SeriLog.



### Host

The .NET Generic Host is responsible for app startup and lifetime management. 

use IHostApplciationLifetime to register the delegate that you want to do when app start, stopping and stopped.



### **Networking** [TODO]

#### Http



#### Socket



#### WebSocket



#### Security



#### QUIC



#### Telemetry



### Worker Service

A Worker Service in .NET is a type of background service that runs continuously as a background process.

You can create it via template.

Just implement BackgroundService class, and so something. 



### Cache

Caching is the act of storing data in an intermediate-layer, making subsequent data retrievals faster. Conceptually, caching is a performance optimization strategy and design consideration. Caching can significantly improve app performance by making infrequently changing (or expensive to retrieve) data more readily available.

In-memory cache - store cache in memory (on the host the application running at)

Distributed cache - store cache in another endpoint.  

Both use DI to integrate. 



### Channel (MassTransit seems better)

n .NET, channels are a part of the System.Threading.Channels namespace and provide a way to communicate and synchronize between different parts of a program, especially in a multithreaded or asynchronous environment. Channels offer a convenient way to pass messages and data between producers and consumers.

I personally think [MassTransit](https://masstransit.io/) is better.

Use the message queue to async information with AMQP protocol, RabbitMQ implementation.

### Assembly [TODO]





