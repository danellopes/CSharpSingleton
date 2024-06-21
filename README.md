### Example of the Singleton Design Pattern

This example of the Singleton Design Pattern pattern was develop using C# language.

For some components, it makes sense to have only one in the system, for example a database access object. We want to prevent multiple calls to the constructor and we want everyone to have the same instance. This can be solved using the Singleton Design Pattern, which makes the constructor private and forces users to use a static instance instead.

### Singleton With Dependency Injection

This technique fixes the constante connection to a true database when working with singletons, since you can inject a dummy database class and not have to connect to the actual database.

If you're interested in the [udemy course](https://www.udemy.com/course/design-patterns-csharp-dotnet) by [Dmitri Nesteruk](https://www.udemy.com/user/dmitrinesteruk/).
