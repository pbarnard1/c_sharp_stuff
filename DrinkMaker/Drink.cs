public class Drink
{
    // Fields (private by default), so we're making these protected so child classes can access these.
    protected string _name;
    protected string _color;
    protected double _temperature;
    protected bool _isCarbonated;
    protected int _calories;
    // Public versions of these fields
    public string Name
    {
        get { return _name; }
    }
    public string Color
    {
        get { return _color; }
    }
    public double Temperature
    {
        get { return _temperature; }
    }
    public bool IsCarbonated
    {
        get {return _isCarbonated; }
    }
    public int Calories
    {
        get {return _calories;}
    }
    // Constructor
    public Drink(string name, string color, double temperature, bool isCarbonated, int calories)
    {
        _name = name;
        _color = color;
        _temperature = temperature;
        _isCarbonated = isCarbonated;
        _calories = calories;
    }

    // Methods
    // Notice the word "virtual" so that child classes CAN override the default behavior of the method named ShowDrink
    public virtual void ShowDrink()
    {
        Console.Write($"Drink called {_name} with a(n) {_color} color, stored at {_temperature} degrees Fahrenheit, ");
        Console.WriteLine($"with {_calories} calories, and it is {(_isCarbonated ? "carbonated" : "not carbonated")}.");
    }
}