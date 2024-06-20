// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
// Declaring variables
string name = "Adrian";
short z = 10; // 16-bit variable (-32,768 through 32,767, so -2^15 through 2^15 - 1; one bit is for the sign)
int x = 50; // 32-bit variable (-2^31 through 2^31 - 1)
long y = 1000; // 64-bit variable (-2^63 through 2^63 - 1)
float z2 = 2.5f; // Floating number - you do need the "f" at the end (32 bits)
double z3 = 1.55; // 64-bit decimal value
char z4 = 'a'; // Character (16 bits)
bool isHappy = true; // Boolean (8 bits)
Console.WriteLine($"My name is {name}"); // Notice the $ at the beginning for interpolation
Console.WriteLine($"Adding 5 and 3 gives {5 + 3}"); // We can do simple expressions like this too!
Console.WriteLine("Hello {0}!  I love {1}",name,"math"); // Alternate way to do interpolation

// Initializing arrays
int[] values = new int[] {1, 3, 5}; // Note the curly braces here
int[] placeholders = new int[10]; // Placeholder int array
string[] capitals = new string[] {"Olympia","Salem","Sacramento"};
Console.WriteLine(values);
Console.WriteLine(capitals);
// One way to loop through array
for (int k = 0; k < capitals.Length; k++) {
    Console.WriteLine(capitals[k]);
}

// Another way to loop - without indexes
foreach (int val in values) {
    Console.WriteLine(val);
}