using Uppgift5;

namespace NTest;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test_AddTooManyVehicles()
    {
        var g = new Garage<Vehicle>(5);
        g.AddVehicle(new Boat("a", "", 0, 1));
        g.AddVehicle(new Boat("b", "", 0, 1));
        g.AddVehicle(new Boat("c", "", 0, 1));
        g.AddVehicle(new Boat("d", "", 0, 1));
        g.AddVehicle(new Boat("e", "", 0, 1));

        Assert.Throws<OverflowException>(() => g.AddVehicle(new Boat("f", "", 0, 1)));
    }
    [Test]
    public void Test_AddSameLicenseTwice()
    {
        var g = new Garage<Vehicle>(5);
        g.AddVehicle(new Boat("aBc", "", 0, 1));

        Assert.Throws<ArgumentException>(() => g.AddVehicle(new Boat("Abc", "", 0, 1)));
    }
    [Test]
    public void Test_FindExistingVehicle()
    {
        var g = new Garage<Vehicle>(5);
        var v1 = new Boat("aBc", "", 0, 1);
        g.AddVehicle(v1);

        var v2 = g.FindVehicle(v1.License.ToLower());

        Assert.That(v1, Is.EqualTo(v2));
    }
}
