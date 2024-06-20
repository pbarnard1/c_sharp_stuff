public class RangedFighter : Enemy
{
    private int _distance = 5;

    public int Distance
    {
        get {return _distance;}
        set {_distance = value;}
    }
    public RangedFighter(String name) : base(name) // Save name and create an empty attack list to start
    {
        // Set two attacks to get us going
        this.AddAttack(new Attack("Arrow", 20));
        this.AddAttack(new Attack("Knife", 15));
    }

    public override void PerformAttack(Enemy target, Attack chosenAttack)
    {
        if (_distance >= 10)
        {

            base.PerformAttack(target, chosenAttack);
        }
        else
        {
            Console.WriteLine($"{this.Name} cannot attack {target.Name} due to insufficient distance.");
        }
    }
    public void Dash()
    {
        _distance = 20;
    }
}