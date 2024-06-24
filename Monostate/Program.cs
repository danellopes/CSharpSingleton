public class CEO
{
    private static string name;
    private static int age;

    public string Name
    {
        get => name;
        set => name = value;
    }

    public int Age
    {
        get => age;
        set => age = value;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Age: {Age}";
    }
}

static class Program
{
    static void Main(string[] args)
    {
        var ceo = new CEO();
        ceo.Name = "Adam Smith";
        ceo.Age = 65;

        var ceo2 = new CEO();
        ceo2.Name = "Trinity";
        ceo2.Age = 45;

        Console.WriteLine(ceo);
        Console.WriteLine(ceo2);
    }
}