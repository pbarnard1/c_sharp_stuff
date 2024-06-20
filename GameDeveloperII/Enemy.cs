public class Enemy
{
    // PRIVATE attributes
    string _name;
    int _health; // CURRENT health
    int _maxHealth; // Maximum health
    List<Attack> _attackList;
    // Public versions of these fields
    public string Name {
        get {return _name;} // Getter ONLY
    }
    public int Health {
        get {return _health;}
        set {_health = value;}
    }
    public int MaxHealth {
        get {return _maxHealth;}
    }
    // public string Attribute {get; set;} // Auto-Implemented property (for future reference)
    public List<Attack> AttackList {
        get {return _attackList;}
    }
    // Constructor
    public Enemy(String name, int health = 100)
    {
        this._name = name;
        this._attackList = new List<Attack>(); // Empty list of Attacks to start
        this._health = health; // Set current and max health (implicitly 100)
        this._maxHealth = health;

    }
    // Methods
    public Attack RandomAttack()
    {
        Random myRNG = new Random(); // Make new instance of this class
        int randomIndex = myRNG.Next(_attackList.Count); // Pick random index
        Attack randomlySelectedAttack = _attackList[randomIndex]; // Grab attack accordingly
        Console.WriteLine($"You picked the attack {randomlySelectedAttack.Name} to inflict {randomlySelectedAttack.DamageAmount} damage!");
        return randomlySelectedAttack;
    }

    public void AddAttack(Attack newAttack)
    {
        _attackList.Add(newAttack); // Add this new Attack to the list of Attacks
    }
    public virtual void PerformAttack(Enemy target, Attack chosenAttack) { // Virtual so that inherited classes can override this default behavior
        if (this.Health <= 0)
        {
            Console.WriteLine($"{this.Name} cannot attack {target.Name} due to being out of health.");
        }
        else
        {
            if (target.Health > 0) // Only attack if the enemy has health
            {
                target.Health = Math.Max(0,target.Health - chosenAttack.DamageAmount); // Lower HP by damage amount, with a minimum of 0
                Console.WriteLine($"{this.Name} attacks {target.Name}, dealing {chosenAttack.DamageAmount} damage and reducing {target.Name}'s health to {target.Health}!");
                if (target.Health == 0)
                {
                    Console.WriteLine($"{target.Name} is knocked out and cannot attack any more!");
                }
            }
            else // Enemy has no health, so be merciful
            {
                Console.WriteLine($"{this.Name} does not need to attack {target.Name}, as that character is out of health.");
            }
        }
    }

    // Additional method to find an attack by name
    public Attack FindAttack(String atkName)
    {
        // try
        // {
        return AttackList.Find(atk => atk.Name.Equals(atkName));
        // }
        // catch (ArgumentNullException e)
        // {
        //     Console.WriteLine($"Cannot find attack named {atkName}");
        //     return null;
        // }
    }
}