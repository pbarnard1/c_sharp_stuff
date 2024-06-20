/*
Three Basic Arrays challenge
*/
// Make an array with the values 0 through 9
int[] intArray = new int[10];
for (int k = 0; k < intArray.Length; k++) 
{
    intArray[k] = k;
}
// Array of strings
string[] randomNames = new string[] {"Tim", "Martin", "Nikki", "Sara"};
bool[] myBoolArr = new bool[10];
for (int k = 0; k < myBoolArr.Length; k++)
{
    myBoolArr[k] = k % 2 == 0; 
    // Alternately, we could use a ternary operator: condition ? valueIfTrue : valueIfFalse
}
// Test the array
foreach(bool val in myBoolArr)
{
    Console.WriteLine(val);
}

/*
List of Flavors challenge
*/
List<string> flavors = new List<string>();
flavors.Add("Vanilla");
flavors.Add("Chocolate");
flavors.Add("Strawberry");
flavors.Add("Neapolitan");
flavors.Add("Mango");
Console.WriteLine($"There are {flavors.Count} flavors!");
Console.WriteLine($"The third flavor is {flavors[2]}.");
flavors.RemoveAt(2); // Remove the item at index 2 (alternately can do .Remove("Strawberry") or .RemoveAll("Strawberry"))
Console.WriteLine($"There are {flavors.Count} flavors after removing Strawberry!");

/*
User Dictionary challenge
*/
Dictionary<string,string> namesWithFlavors = new Dictionary<string, string>();
Random myRNG = new Random(); // For random numbers
foreach (string name in randomNames)
{
    namesWithFlavors.Add(name,flavors[myRNG.Next(flavors.Count)]); // Grab name, then randomly select a flavor
}
// Now examine each key-value pair
foreach (KeyValuePair<string,string> curItem in namesWithFlavors)
{
    Console.WriteLine($"Name is {curItem.Key} with a flavor of {curItem.Value}");
}