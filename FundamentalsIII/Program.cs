// First challenge
using System.Linq.Expressions;
using System.Numerics;
using System.Reflection;

static void PrintList(List<string> MyList)
{
    // One way to loop through the list - foreach loop
    foreach(string name in MyList) 
    {
        Console.WriteLine(name);
    }
    // Second way to loop through a list - using a plain for loop
    for(int k = 0; k < MyList.Count; k++) 
    {
        Console.WriteLine(MyList[k]);
    }
    Console.WriteLine(string.Join(", ", MyList)); // Third way to do this
    MyList.ForEach(name => Console.WriteLine(name)); // 4th way to do this
}
List<string> TestStringList = new List<string>() {"Harry", "Steve", "Carla", "Jeanne"};
PrintList(TestStringList);

/*
Second challenge
*/
static void SumOfNumbers(List<int> IntList)
{
    int sum = 0; // Starting point for sum
    foreach (int val in IntList) 
    {
        sum += val;
    }
    Console.WriteLine(sum); // Print the sum
}
List<int> TestIntList = new List<int>() {2,7,12,9,3};
// You should get back 33 in this example
SumOfNumbers(TestIntList);

// Third challenge
static int FindMax(List<int> IntList)
{
    int maxValue = Int32.MinValue; // The smallest value for an int
    foreach (int val in IntList)
    {
        if (val > maxValue) // New max found
        {
            maxValue = val;
        }
    }
    return maxValue;
}
List<int> TestIntList2 = new List<int>() {-9,12,10,3,17,5};
// You should get back 17 in this example
Console.WriteLine(FindMax(TestIntList2));

// Fourth challenge
static List<int> SquareValues(List<int> IntList)
{
    List<int> newList = new List<int>();
    foreach(int val in IntList)
    {
        newList.Add(val * val); // If using the old-fashioned for loop, do IntList[k] * IntList[k], where k is an index
    }
    return newList;
}
List<int> TestIntList3 = new List<int>() {1,2,3,4,5};
// You should get back [1,4,9,16,25], think about how you will show that this worked
List<int> answer4 = SquareValues(TestIntList3);
Console.WriteLine("["+string.Join(",",answer4)+"]");

// Fifth challenge
static int[] NonNegatives(int[] IntArray)
{
    // Go through the array - here we're changing the values IN PLACE
    for(int k = 0; k < IntArray.Length; k++)
    {
        if (IntArray[k] < 0) // Value is negative, so make it 0 instead
        {
            IntArray[k] = 0;
        }
    }
    return IntArray;
}
int[] TestIntArray = new int[] {-1,2,3,-4,5};
// You should get back [0,2,3,0,5], think about how you will show that this worked
NonNegatives(TestIntArray);
Console.WriteLine("["+string.Join(",",TestIntArray)+"]"); // Notice that an array is MUTABLE - its contents stay changed!

// Sixth challenge
static void PrintDictionary(Dictionary<string,string> MyDictionary)
{
    foreach(KeyValuePair<string,string> item in MyDictionary)
    {
        Console.WriteLine($"Current key = {item.Key}, with its value equal to {item.Value}");
    }
}
Dictionary<string,string> TestDict = new Dictionary<string,string>();
TestDict.Add("HeroName", "Iron Man");
TestDict.Add("RealName", "Tony Stark");
TestDict.Add("Powers", "Money and intelligence");
PrintDictionary(TestDict);

// Seventh challenge
static bool FindKey(Dictionary<string,string> MyDictionary, string SearchTerm)
{
    return MyDictionary.ContainsKey(SearchTerm); // OR .TryGetValue(key)
}
// Use the TestDict from the earlier example or make your own
// This should print true
Console.WriteLine(FindKey(TestDict, "RealName"));
// This should print false
Console.WriteLine(FindKey(TestDict, "Name"));
// Using default values if keys do not exist (BONUS)
Console.WriteLine(TestDict.GetValueOrDefault<string,string>("hello","Does NOT exist"));
Console.WriteLine(TestDict.GetValueOrDefault<string,string>("RealName","Does NOT exist"));

// Eighth challenge
// Ex: Given ["Julie", "Harold", "James", "Monica"] and [6,12,7,10], return a dictionary
// {
//	"Julie": 6,
//	"Harold": 12,
//	"James": 7,
//	"Monica": 10
// } 
static Dictionary<string,int> GenerateDictionary(List<string> Names, List<int> Numbers)
{
    Dictionary<string, int> newDictionary = new Dictionary<string, int>();
    for (int k = 0; k < Names.Count; k++) 
    { // Loop through both lists by index
        newDictionary.Add(Names[k],Numbers[k]); // Add key-value pair
    }
    return newDictionary;
}
// We've shown several examples of how to set your tests up properly, it's your turn to set it up!
// Lists we'll use for testing
List<string> variousNames = new List<string>();
variousNames.Add("Julie");
variousNames.Add("Harold");
variousNames.Add("James");
variousNames.Add("Monica");
List<int> variousNumbers = new List<int>();
variousNumbers.Add(6);
variousNumbers.Add(12);
variousNumbers.Add(7);
variousNumbers.Add(10);
Dictionary<string,int> myDictionary = GenerateDictionary(variousNames, variousNumbers);
// Test the dictionary out
foreach(KeyValuePair<string,int> curItem in myDictionary)
{
    Console.WriteLine($"Key = {curItem.Key}, Value = {curItem.Value}");
}