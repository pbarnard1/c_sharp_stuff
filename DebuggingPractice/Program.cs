// Challenge 1

bool amProgrammer = true; // CORRECTION: just true without the quotes, otherwise it's a string
int Age = 27; // CORRECTION: changed from 27.9 to 27 so it's an int instead of a float
List<string> Names = new List<string>();
Names.Add("Monica"); // CORRECTION - cannot assign a name like this; you can add it, however (original line: Names = "Monica";)
Dictionary<string, string> MyDictionary = new Dictionary<string, string>();
MyDictionary.Add("Hello", "0");
MyDictionary.Add("Hi there", "0"); // CORRECTION: 0 is an int, not a string, so use "0" (original line: MyDictionary.Add("Hi there", 0);)
// This is a tricky one! Hint: look up what a char is in C#
string MyName = "MyName"; // CORRECTION: use double quotes, NOT single quotes, for strings!  Single quotes are for chars.

// Challenge 2
List<int> Numbers = new List<int>() {2,3,6,7,1,5};
for(int i = Numbers.Count - 1; i >= 0; i--) // CORRECTION: start at Numbers.Count - 1, NOT Numbers.Count due to invalid index
{
    Console.WriteLine(Numbers[i]);
}

// Challenge 3
List<int> MoreNumbers = new List<int>() {12,7,10,-3,9};
foreach(int i in MoreNumbers)
{
    Console.WriteLine(i); // CORRECTION: you can just use i here, NOT MoreNumbers[i], as "i" means the number, NOT an index, in a foreach loop
}

// Challenge 4
List<int> EvenMoreNumbers = new List<int> {3,6,9,12,14};
// COMMENTED OUT below as it's not usable as is
// foreach(int num in EvenMoreNumbers)
// {
//     if(num % 3 == 0)
//     {
//         num = 0; // ILLEGAL: You CANNOT reassign an iteration variable in a foreach loop
//     }
// }
// Fix: Use a for loop and then reassign as needed in the array
for (int k = 0; k < EvenMoreNumbers.Count; k++)
{
    if(EvenMoreNumbers[k] % 3 == 0)
    {
        EvenMoreNumbers[k] = 0;
    }
}

// Challenge 5
// What can we learn from this error message?
string MyString = "superduberawesome";
// MyString[7] = "p"; // ERROR: You can't change a character like this, as it's read-only - it's immutable
// One way to replace a string - make a character array
char[] stringChars = MyString.ToCharArray();
stringChars[7] = 'p';
MyString = new string(stringChars); // Re-form string
Console.WriteLine(MyString);

// Challenge 6
// Hint: some bugs don't come with error messages
Random rand = new Random();
int randomNum = rand.Next(12); 
if(randomNum == 0) // CORRECTION: 12 is impossible, as rand.Next(12) will generate values from 0 through 11, so it will not include 12
{
    Console.WriteLine("Hello");
}

