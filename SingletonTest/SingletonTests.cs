using System.Data.Common;

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

    [Test]
    public void ConfigurablePopulationTest()
    {
        var rf = new ConfigurableRecordFinder(new DummyDatabase());
        var names = new string[] { "alpha", "gama" };
        int tp = rf.GetTotalPopulation(names);
        Assert.That(tp, Is.EqualTo(4));
    }

    [Test]
    public void DIPopulationTest()
    {
        var cb = new ContainerBuilder();
        cb.RegisterType<OrdinaryDatabase>().As<IDatabase>().SingleInstance();
        cb.RegisterType<ConfigurableRecordFinder>();

        using (var c = cb.Build())
        {
            var rf = c.Resolve<ConfigurableRecordFinder>();
        }
    }
}