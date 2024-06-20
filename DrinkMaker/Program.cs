Soda coke = new Soda("Coca-Cola", "brown", 50, 125, false); // Instance of our Soda class
Coffee folgers = new Coffee("Folgers", "brown", 50, false, 125, "light","kona"); // Instance of our Coffee class
Wine wine1 = new Wine("Simi Valley", "red", 40, false, 50, "Simi Valley", 2000); // Instance of our Wine class
Console.WriteLine(coke.Calories); // 125 calories
Console.WriteLine(coke.IsDiet); // false
Console.WriteLine(coke.IsCarbonated); // true
// List of Drinks - and we CAN add subclasses, as they are Drinks too, such as Sodas, Coffees, etc.!
List<Drink> allBeverages = new List<Drink>();
allBeverages.Add(coke);
allBeverages.Add(folgers);
allBeverages.Add(wine1);
foreach (Drink thisDrink in allBeverages)
{
    thisDrink.ShowDrink(); // Display info about this drink (works for subclasses too)
}

// Coffee myDrink = new Soda("Coca-Cola", "brown", 50, 125, false); // Either with no arguments or these arguments, it won't work!
/*
This doesn't work, as you can't create an instance of a class that is from a different class, even though they share
the same parent superclass.  These two classes have unique fields, so that is something to consider!!
*/