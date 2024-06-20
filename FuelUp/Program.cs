// See https://aka.ms/new-console-template for more information
Car myCar = new Car("Corvette","black",4);
Horse pony = new Horse("Secretariat","brown",1);
Bicycle schwinn = new Bicycle("Schwinn","gray");
// Vehicle myVehicle = new Vehicle("Car1","blue",3); // Cannot create an instance of an abstract class (or interface)
List<Vehicle> allVehicles = new List<Vehicle>();
allVehicles.Add(myCar);
allVehicles.Add(pony);
allVehicles.Add(schwinn);
List<INeedFuel> vehiclesWithFuel = new List<INeedFuel>(); // Holds all items that utilize the fuel interface
foreach (Vehicle v in allVehicles)
{
    Console.WriteLine(v.Name);
    if (v is INeedFuel fuel) // Pattern matching used here: https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/pattern-matching
    {
        Console.WriteLine(v.Name);
        vehiclesWithFuel.Add(fuel);
    }
}
foreach (var k in vehiclesWithFuel) // Add fuel to each vehicle that has fuel
{
    k.GiveFuel(10);
}
foreach (var k in vehiclesWithFuel) // Display info
{
    Vehicle thisVehicle = (Vehicle) k; // So we can grab the name
    Console.WriteLine($"{thisVehicle.Name} with {k.FuelTotal} {k.FuelType}");
}