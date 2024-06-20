public class MeleeFighter : Enemy
{
    // constructor
    public MeleeFighter(String name) : base(name, 120) // Save name and create an empty attack list to start, with 120 health
    {
        // Set three attacks to get us going
        this.AddAttack(new Attack("Punch", 20));
        this.AddAttack(new Attack("Kick", 15));
        this.AddAttack(new Attack("Tackle", 25));
    }

    // New attack method, where we specify the enemy we want to attack
    public void Rage(Enemy foe)
    {
        // Select random attack
        Attack pickedAttack = this.RandomAttack();
        pickedAttack.DamageAmount += 10; // In rage mode, so add 10 attack
        this.PerformAttack(foe,pickedAttack);
        pickedAttack.DamageAmount -= 10; // No longer in rage mode
    }
}