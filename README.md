### Example of the Singleton Design Pattern

This example of the Singleton Design Pattern pattern was develop using C# language.

For some components, it makes sense to have only one in the system, for example a database access object. We want to prevent multiple calls to the constructor and we want everyone to have the same instance. This can be solved using the Singleton Design Pattern, which makes the constructor private and forces users to use a static instance instead.

### Problems

The Singleton pattern's testability can be compromised due to its dependency on external systems like databases or files. This dependency means tests could fail inconsistently due to changes in these external systems, which are outside of the test's control. For instance, if a test expects specific data from a database, but the data changes during the test's execution, the test may fail. Similarly, if a test reads from or writes to a file and the file's content changes, the test could also fail. This inconsistency in testing results poses challenges in ensuring reliable and repeatable test outcomes.

### Singleton With Dependency Injection

The Singleton with Dependency Injection technique is a solution designed to address the constant connection to a live database when working with singleton patterns. Singleton patterns typically involve creating one instance of a class that is shared and used throughout an application, such as a connection to a database. However, this can lead to issues, such as when you want to run tests without affecting the live database.

By implementing Dependency Injection, we can inject a "dummy" or "mock" database class instead of connecting to the actual database. This allows for testing isolated from the real database, which can be beneficial for the integrity of the live data and the speed of testing, as it avoids the overhead of establishing a real database connection.

However, this approach may not make much sense when used with platforms like Salesforce. Salesforce tests do write to the database, but the platform always performs a rollback at the end of each test. This means that any changes made during the test are reversed, ensuring that the database remains in its original state after testing. This rollback feature reduces the necessity of using a dummy database class for testing in Salesforce.

### Monostate

The Monostate pattern is a unique approach to addressing the Singleton design pattern's limitations. Unlike the Singleton pattern, which restricts object instantiation by making the constructor private and providing a single global access point, the Monostate pattern allows developers to create as many instances of a class as they like. However, the catch is that all these instances share the same state.

This is achieved by making all the class properties static. In programming, a static property belongs to the class itself, not any specific object instance. Therefore, even though multiple objects may be created, they all share the same static properties. If you modify a static property in one instance, it affects all other instances.

Therefore, with the Monostate pattern, even though multiple object instances can be created, they all behave as if there is only one instance, because they share the same state. This allows the developers to maintain the illusion of a single instance, while avoiding some of the drawbacks associated with Singleton.

### Per-Thread Singleton

In multi-threaded projects, the use of a singleton can cause a bottleneck as it only allows a single instance to run across all threads. This results in threads stalling as they wait for access to the singleton instance, reducing the benefits of multi-threading and resulting in less efficient code execution.

To alleviate this issue, one approach is to create a singleton instance for each thread, a technique known as Per-Thread Singleton. This is achieved using the ThreadLocal construct in C#. ThreadLocal is a type of local data storage that provides a unique value for each thread that accesses it. When applied to the Singleton pattern, it allows each thread to have its own instance of the singleton, thus avoiding the bottleneck caused by multiple threads trying to access a single instance.

However, this technique may not be applicable in all environments. For example, in Salesforce, developers do not have control over the threads that the platform runs on. As a result, it's not possible to implement a Per-Thread Singleton in this context. This is a limitation to consider when choosing the appropriate design pattern for a given application.

### Ambient Context

The Ambient Context is a design pattern that allows global access to a specific piece of information in the system. It is a method where you segregate the execution context of the code, providing a distinct value of a property for that particular context. For instance, in a house-building project, the wall height on the ground floor might be 3000 units, while on the first floor it might be 3500 units. The Ambient Context pattern allows the software to respond appropriately to the context it is operating within.

This pattern is extremely useful because it allows for the creation of context layers. These layers can dynamically change the software's behavior based on the current context. This is particularly beneficial when used in a Singleton pattern, as it prevents developers from creating multiple instances of context properties that should be unique within the system.

Despite its usefulness, the Ambient Context technique is not suitable for all environments. For example, in Salesforce, developers don't have the ability to control or separate the execution context at runtime. This limitation highlights the importance of selecting the correct design pattern based on the specific requirements and constraints of the software environment.

If you're interested in the [udemy course](https://www.udemy.com/course/design-patterns-csharp-dotnet) by [Dmitri Nesteruk](https://www.udemy.com/user/dmitrinesteruk/).
