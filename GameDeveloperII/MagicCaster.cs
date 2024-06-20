using System;

public class MagicCaster : Enemy
{
    // constructor
    public MagicCaster(String name) : base(name, 80) // Save name and create an empty attack list to start, with 80 HP
    {
        // Set three attacks to get us going
        this.AddAttack(new Attack("Fireball", 25));
        this.AddAttack(new Attack("Lightning Bolt", 20));
        this.AddAttack(new Attack("Staff Strike", 10));
    }

    public void Heal(Enemy unitToHeal)
    {
        unitToHeal.Health = Math.Min(unitToHeal.Health + 40, unitToHeal.MaxHealth); // Put cap on max
        Console.WriteLine($"The unit named {unitToHeal.Name} now has {unitToHeal.Health} health.");
    }
}