// Creating characters
Console.WriteLine("Test");

MeleeFighter vaike = new MeleeFighter("Vaike");
MagicCaster miriel = new MagicCaster("Miriel");
RangedFighter virion = new RangedFighter("Virion");
// Performing attacks and healing abilities
vaike.PerformAttack(virion,vaike.FindAttack("Kick"));
vaike.Rage(miriel);
virion.PerformAttack(vaike,virion.FindAttack("Arrow")); // Won't work
virion.Dash();
virion.PerformAttack(vaike,virion.FindAttack("Arrow")); // Now will work
miriel.PerformAttack(vaike,miriel.FindAttack("Fireball"));
miriel.PerformAttack(vaike,miriel.FindAttack("Fireball"));
miriel.PerformAttack(vaike,miriel.FindAttack("Fireball"));
miriel.PerformAttack(vaike,miriel.FindAttack("Fireball"));
miriel.PerformAttack(vaike,miriel.FindAttack("Fireball")); // Now can't attack
vaike.Rage(miriel); // Can't attack
vaike.PerformAttack(virion,vaike.FindAttack("Punch")); // Can't attack
miriel.Heal(virion);
miriel.Heal(miriel);
miriel.Heal(vaike);
vaike.PerformAttack(virion,vaike.FindAttack("Punch"));
// Console.WriteLine(vaike.FindAttack("Punch") == null); // Attack exists
// Console.WriteLine(vaike.FindAttack("Swing") == null); // No attack exists
// Type thisType = typeof(Attack);
// Console.WriteLine(thisType.Namespace);