namespace SingletonTest;

public class SingletonTests
{
    [Test]
    public void IsSingletonTest()
    {
        var db = SingletonDatabase.Instance;
        var db2 = SingletonDatabase.Instance;
        Assert.That(db, Is.SameAs(db2));
        Assert.That(SingletonDatabase.Count, Is.EqualTo(1));
    }

    [Test]
    public void SingletonTotalPopulationTest()
    {
        var rf = new SingletonRecordFinder();
        var names = new string[] { "Tokyo", "Mexico City" };
        int tp = rf.GetTotalPopulation(names);
        Assert.That(tp, Is.EqualTo(33200000 + 17400000));
    }
}