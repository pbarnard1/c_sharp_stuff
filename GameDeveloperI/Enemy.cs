public class Enemy
{
    // PRIVATE attributes
    string _name;
    int _health = 100;
    List<Attack> _attackList;
    // Public versions of these fields - we will ONLY use getters
    public string Name {
        get {return _name;}
    }
    public int Health {
        get {return _health;}
    }
    public List<Attack> AttackList {
        get {return _attackList;}
    }
    // Constructor
    public Enemy(String name)
    {
        this._name = name;
        this._attackList = new List<Attack>(); // Empty list of Attacks to start
        // Implicit: health will be set to 100 to start
    }
    // Methods
    public void RandomAttack()
    {
        Random myRNG = new Random(); // Make new instance of this class
        int randomIndex = myRNG.Next(_attackList.Count); // Pick random index
        Attack randomlySelectedAttack = _attackList[randomIndex]; // Grab attack accordingly
        Console.WriteLine($"You picked the attack {randomlySelectedAttack.Name} to inflict {randomlySelectedAttack.DamageAmount} damage!");
    }
    public void AddAttack(Attack newAttack)
    {
        _attackList.Add(newAttack); // Add this new Attack to the list of Attacks
    }
}