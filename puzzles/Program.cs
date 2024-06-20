// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
static string FlipCoin()
{
    Random myRNG = new Random();
    int pickedVal = myRNG.Next(2);
    return pickedVal == 0 ? "Heads" : "Tails"; // Ternary operator used here
}
static int RollDie(int numberOfSides = 6) // Roll a die, with a default of 6 sides (faces)
{
    Random myRNG = new Random();
    int pickedVal = myRNG.Next(1,numberOfSides+1); // Minimum of 1; note the "+1" so that a 6-sided die, for instance, can return 6
    return pickedVal; // Ternary operator used here
}
static List<int> RollManyTimes(int numberOfTrials = 4)
{
    List<int> allTrials = new List<int>();
    // Now roll die many times
    for (int k = 1; k <= numberOfTrials; k++)
    {
        allTrials.Add(RollDie()); // Roll 6-sided die
    }
    Console.WriteLine($"Biggest value rolled = {allTrials.Max()}"); // Display biggest result
    return allTrials;
}
static string RollUntilValue(int val, int numberOfSides = 6)
{
    if (val <= 0 || val > numberOfSides)
    {
        return $"It's impossible to roll the value {val} in a(n) {numberOfSides}-sided die.";
    }
    int totalRolls = 0; // Number of rolls we'll need until val is rolled
    int numberRolled = 0; // Pick a value outside the range (0 is one such value)
    while (numberRolled != val)
    {
        totalRolls++; // Add 1 to total rolls needed
        numberRolled = RollDie(numberOfSides); // Roll the die
    }
    return $"It took {totalRolls} roll(s) to get a(n) {val}.";
}
static void PlayWithDice()
{
    bool wantsToPlay = true;
    while (wantsToPlay)
    {
        Console.WriteLine("Would you like to roll a die?  Type \"y\" or \"n\":");
        string willPlayInput = Console.ReadLine(); // Ask user to enter a number
        if (willPlayInput.Length == 0 || (!willPlayInput.ToLower().Equals("y") && !willPlayInput.ToLower().Equals("n")))
        {
            Console.WriteLine("You did not enter 'y' or 'n'!  Asking again....");
            continue; // Go to next iteration of loop - so ask again
        }
        if (willPlayInput.ToLower().Equals("n"))
        {
            Console.WriteLine("Thanks for playing!");
            wantsToPlay = false; // We're done
            continue; // Go to next iteration of loop - so ask again
        }
        // If we reach this point, the user typed "y"
        Console.WriteLine("How many sides are in the die you wish to roll?");
        string sidesInput = Console.ReadLine(); // Ask user to enter a number
        if (!Int32.TryParse(sidesInput, out int totalSides)) // Try to parse into an int (which will be saved into totalSides, if successful)
        {
            Console.WriteLine("Invalid input!");
            continue; // Go to next iteration of loop - so ask again
        }
        if (totalSides <= 0) // Invalid integer
        {
            Console.WriteLine("You cannot enter a negative number or 0.");
            continue; // Go to next iteration of loop - so ask again
        }
        Console.WriteLine($"You rolled a(n) {RollDie(totalSides)}!");
    }
}

// Test flipping a coin 10 times
for (int k = 1; k <= 10; k++)
{
    Console.WriteLine(FlipCoin());
}
// Test rolling a (6-sided) die 30 times
for (int k = 1; k <= 30; k++)
{
    Console.WriteLine(RollDie());
}
// Test rolling a 15-sided die 50 times
for (int k = 1; k <= 50; k++)
{
    Console.WriteLine($"Trial #{k}: {RollDie(15)}");
}
Console.WriteLine("["+String.Join(", ",RollManyTimes())+"]"); // Roll 4 times
Console.WriteLine("["+String.Join(", ",RollManyTimes(15))+"]"); // Roll 15 times
// Roll until a certain value is attained
Console.WriteLine(RollUntilValue(5));
Console.WriteLine(RollUntilValue(10,7)); // Impossible to roll a 10 in a 7-sided die
Console.WriteLine(RollUntilValue(10,20)); // Roll a 10 in a 20-sided die
// Play with dice interactively!
PlayWithDice();