using System.Runtime.CompilerServices;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

public interface IDatabase
{
    int GetPopulation(string name);
}


public class SingletonDatabase : IDatabase
{
    private static Lazy<SingletonDatabase> instance = new Lazy<SingletonDatabase>(() => new SingletonDatabase());
    public static SingletonDatabase Instance = instance.Value;
    private static int instanceCount;
    public static int Count => instanceCount;

    private Dictionary<string, int> capitals = new Dictionary<string, int>();

    private SingletonDatabase()
    {
        instanceCount++;
        Console.WriteLine("Initializing database");

        StreamReader sr = new StreamReader("C:\\Users\\danie\\Downloads\\C# Design Patterns\\Singleton\\C#Singleton\\SingletonImplementation\\Capitals.txt");
        var line = sr.ReadLine();
        string lastCapital = "";

        while (line != null)
        {
            if (!string.IsNullOrEmpty(lastCapital) && line.All(char.IsNumber))
            {
                capitals.Add(lastCapital, int.Parse(line));
                lastCapital = "";
            }
            else
            {
                lastCapital = line;
            }
            line = sr.ReadLine();
        }
    }

    public int GetPopulation(string name)
    {
        return capitals[name];
    }
}

public class SingletonRecordFinder
{
    public int GetTotalPopulation(IEnumerable<string> names)
    {
        int result = 0;
        foreach (string name in names)
        {
            result += SingletonDatabase.Instance.GetPopulation(name);
        }

        return result;
    }
}

static class Program
{
    static void Main(string[] args)
    {
        var db = SingletonDatabase.Instance;
        int population = db.GetPopulation("New York");
        Console.WriteLine(population);
    }
}