public class Wine : Drink
{
    string _region;
    int _year;
    // Public versions of these private attributes
    public string Region
    {
        get { return _region; }
    }
    public int Year
    {
        get { return _year; }
    }
    // Constructor
    public Wine(string name, string color, double temperature, bool isCarbonated,
        int calories, string region, int year) : base(name, color, temperature, isCarbonated, calories)
    {
        _region = region; // Add these additional fields
        _year = year;
    }
    // We are overriding the default behavior of this method with the keyword "override"!
    public override void ShowDrink()
    {
        base.ShowDrink(); // If you want to run the parent class's version of this method
        Console.WriteLine($"The {_name} wine comes from {_region}, and was produced in {_year}.");
        // NOTE: If we did _name, and that attribute is private, we can't access it!  So we either use a public version,
        // as done here, OR we make the "_name" attribute protected instead so that child classes can use it!
    }
}