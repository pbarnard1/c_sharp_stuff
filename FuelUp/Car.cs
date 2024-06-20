class Car : Vehicle, INeedFuel
{
    public string FuelType {get; set;}
    public int FuelTotal {get; set;}
    public Car(String name, String color, int totalPassengers = 2, bool hasEngine = true) : base(name, color, totalPassengers, hasEngine)
    {
        this.FuelTotal = 10;
        this.FuelType = "gas";
    }

    public void GiveFuel(int amount)
    {
        Console.WriteLine($"Now adding {amount} gallon(s) of {this.FuelType}!");
        this.FuelTotal += amount;
    }
    public override void ShowInfo()
    {
        Console.Write($"This car is a(n) {Color} {Name}, which can hold {TotalPassengers} passengers ");
        Console.Write($"and {(HasEngine ? "does" : "does not")} have an engine.  It has traveled {MilesTraveled} miles total.\n");
    }
}