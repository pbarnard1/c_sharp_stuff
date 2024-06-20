class Bicycle : Vehicle
{
    public Bicycle(String name, String color, int totalPassengers = 1, bool hasEngine = false) : base(name, color, totalPassengers, hasEngine)
    {

    }
    public override void ShowInfo()
    {
        Console.Write($"This bicycle is a(n) {Color} {Name}, which can hold {TotalPassengers} passengers(s) ");
        Console.Write($"and {(HasEngine ? "does" : "does not")} have an engine.  It has traveled {MilesTraveled} miles total.\n");
    }
}