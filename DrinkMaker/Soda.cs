public class Soda : Drink // We're inheriting from our Drink class
{
    bool _isDiet;
    public bool IsDiet
    {
        get { return _isDiet; }
    }
    // Constructor - notice we're NOT passing in a value for isCarbonated, but in the base() function, which calls on the
    // constructor in the Drink class, we're using a default value of "true" for isCarbonated.  All other fields - EXCEPT
    // new ones that we defined in this method - use the base() function to generate those fields.
    public Soda(string name, string color, double temperature, int calories, bool isDiet) : base(name, color, temperature, true, calories)
    {
        _isDiet = isDiet; // Add this additional field
    }
    // We are overriding the default behavior of this method with the keyword "override"!
    public override void ShowDrink()
    {
        base.ShowDrink(); // If you want to run the parent class's version of this method
        Console.WriteLine($"The {_name} soda is {(_isDiet ? "not a diet soda" : "a diet soda")}.");
        // NOTE: If we did _name, and that attribute is private, we can't access it!  So we either use a public version,
        // as done here, OR we make the "_name" attribute protected instead so that child classes can use it!
    }
}