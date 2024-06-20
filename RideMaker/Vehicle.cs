class Vehicle
{
    // Fields for this class (note the "_" as the convention to make these private -
    // by default, these are private)
    string _name;
    string _color;
    int _totalPassengers;
    bool _hasEngine;
    int _milesTraveled = 0;
    // Public versions of these fields
    public string Name {
        get {return _name;}
        set { _name = value;}
    }
    public string Color {
        get {return _color;}
        set { _color = value;}
    }
    public int TotalPassengers {
        get {return _totalPassengers;}
        set { _totalPassengers = value;}
    }
    public bool HasEngine {
        get {return _hasEngine;}
        set { _hasEngine = value;}
    }
    public int MilesTraveled {
        get {return _milesTraveled;}
        set { _milesTraveled = value;}
    }

    // Constructor (notice the default fields at the end)
    public Vehicle(String name, String color, int totalPassengers = 2, bool hasEngine = true)
    {
        this._name = name;
        this._color = color;
        this._totalPassengers = totalPassengers;
        this._hasEngine = hasEngine;
        // Miles traveled auto-set when defining attributes above
    }
    /* 
    Methods for this class
    */
    // Display the car's info
    public void ShowInfo()
    {
        Console.Write($"This car is a(n) {_color} {_name}, which can hold {_totalPassengers} passengers ");
        Console.Write($"and {(_hasEngine ? "does" : "does not")} have an engine.  It has traveled {_milesTraveled} miles total.\n");
    }
    public void Travel(int distance)
    {
        this._milesTraveled += distance; // Add this to miles traveled
        Console.WriteLine($"You have traveled {distance} miles and have now gone a total of {this._milesTraveled} miles.");
    }
}