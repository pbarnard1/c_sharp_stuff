Enemy blackMage = new Enemy("Black Mage");
Attack thundaga = new Attack("Thundaga", 23);
Attack firaga = new Attack("Firaga", 20);
Attack blizzaga = new Attack("Blizzaga", 25);
// Add attacks to black mage's repetoire (arsenal)
blackMage.AddAttack(thundaga);
blackMage.AddAttack(firaga);
blackMage.AddAttack(blizzaga);
// Attack randomly 10 times
for (int k = 1; k <= 10; k++)
{
    blackMage.RandomAttack();
}
Console.WriteLine($"The black mage has {blackMage.Health} health");
// blackMage.Health = 200; // ILLEGAL - read-only field, as we don't have a setter method specified