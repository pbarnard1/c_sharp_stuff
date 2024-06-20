public class Attack
{
    // Private versions of these fields
    private string _name;
    private int _damageAmount;
    // Public versions
    public string Name
    {
        get {return _name;}
    }
    public int DamageAmount
    {
        get {return _damageAmount;}
        set {_damageAmount = value;} // Setter added
    }
    // Constructor
    public Attack(String name, int damageAmount)
    {
        this._name = name;
        this._damageAmount = damageAmount;
    }
}