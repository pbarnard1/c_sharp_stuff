public class Coffee : Drink // We're inheriting from our Drink class
{
    string _roastType;
    string _beanType;
    public string RoastType
    {
        get { return _roastType; }
    }
    public string BeanType
    {
        get { return _beanType; }
    }
    // Constructor
    public Coffee(string name, string color, double temperature, bool isCarbonated,
        int calories, string roastType, string beanType) : base(name, color, temperature, isCarbonated, calories)
    {
        _roastType = roastType; // Add these additional fields
        _beanType = beanType;
    }
    // Methods
    // We are overriding the default behavior of this method with the keyword "override"!
    public override void ShowDrink()
    {
        base.ShowDrink(); // If you want to run the parent class's version of this method
        Console.WriteLine($"The {_name} coffee has a(n) {_roastType} roast type, and uses {_beanType} beans.");
        // NOTE: If we did _name, and that attribute is private, we can't access it!  So we either use a public version,
        // as done here, OR we make the "_name" attribute protected instead so that child classes can use it!
    }
}