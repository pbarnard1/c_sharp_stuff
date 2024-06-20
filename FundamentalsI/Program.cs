// See https://aka.ms/new-console-template for more information
// Print values from 1 through 255
for (int i = 1; i <= 255; i++) {
    Console.WriteLine(i);
}

// Generate 5 random numbers between 10 and 20, inclusively
int k = 1;
Random myRNG = new Random(); // Random number generator
int sum = 0;
while (k <= 5) {
    int pickedVal = myRNG.Next(10,21); // Anywhere from 10 through 20
    Console.WriteLine(pickedVal);
    sum += pickedVal;
    k++;
}
Console.WriteLine($"Sum = {sum}");

// Print values from 1 through 100 that are divisible by 3 or 5, but NOT both
for (int p = 1; p <= 100; p++) {
    if ((p % 3 == 0 && p % 5 != 0) || (p % 3 != 0 && p % 5 == 0)) {
        Console.WriteLine(p);
    }
}

// Print Fizz if divisible by 3, Buzz if divisible by 5, FizzBuzz if divisible by both 3 and 5
for (int p = 1; p <= 100; p++) {
    string outputStr = "";
    // Independently check for divisibility
    if (p % 3 == 0) {
        outputStr += "Fizz";
    }
    if (p % 5 == 0) {
        outputStr += "Buzz";
    }
    // Now print if not empty
    if (outputStr != "") {
        Console.WriteLine($"{p} results in {outputStr}");
    }
}