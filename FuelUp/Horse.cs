class Horse : Vehicle, INeedFuel
{
    public string FuelType {get; set;} // From INeedFuel interface
    public int FuelTotal {get; set;} // From INeedFuel interface
    public Horse(String name, String color, int totalPassengers = 2) : base(name, color, totalPassengers, false)
    {
        this.FuelTotal = 10;
        this.FuelType = "hay";
    }
    public void GiveFuel(int amount) // From INeedFuel interface - must implement here
    {
        Console.WriteLine($"Now adding {amount} piece(s) of {this.FuelType}!");
        this.FuelTotal += amount;
    }
    public override void ShowInfo() // From abstract Vehicle class - must implement
    {
        Console.Write($"This horse is a(n) {Color} {Name}, which can hold {TotalPassengers} passengers ");
        Console.Write($"and eats {this.FuelType}.  It has traveled {MilesTraveled} miles total.\n");
    }
}