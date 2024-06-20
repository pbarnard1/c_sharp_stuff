// Create four cars
Vehicle carOne = new Vehicle("Studebaker Golden Hawk","white");
Vehicle carTwo = new Vehicle("Ford Pinto","blue",4,false);
Vehicle carThree = new Vehicle("Chevrolet Corvette","black",2);
Vehicle carFour = new Vehicle("Tesla Roadster","yellow",4,true);
List<Vehicle> allCars = new List<Vehicle> {carOne, carTwo, carThree, carFour}; // Create FIXED list of Vehicles
// Loop through the list of cars
foreach (Vehicle thisCar in allCars)
{
    thisCar.ShowInfo(); // Display info about this current car
}
// Test traveling with one of the cars
carThree.Travel(100);
carThree.Travel(10);
carThree.MilesTraveled = 350; // WARNING - this is PUBLIC!!
carThree.Travel(100);
/*
It's a bad idea to have public fields, because you don't any random person, user, etc. to change properties on a whim.
In this case, it's equivalent to rolling back the odometer illegally.  As another example, we don't want another person
changing a user's name or changing the amount of money in one's account!
*/