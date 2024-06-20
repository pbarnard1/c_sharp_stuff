using System.Net.Http.Headers;

List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46, "Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};
// Example Query - Prints all Stratovolcano eruptions
// IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
// PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");

// Execute Assignment Tasks here!

// First eruption from Chile
Eruption? chileEruption = eruptions.FirstOrDefault(eruption => eruption.Location.Equals("Poland"),null); // Note the "?" to allow for null
Console.WriteLine(chileEruption != null ? chileEruption.ToString() : "No eruptions in Chile");
// Find first eruption in list from Hawaii and Greenland
string curLocale = "Hawaiian Is";
Eruption? possibleEruption = eruptions.FirstOrDefault(eruption => eruption.Location.Equals(curLocale), null);
Console.WriteLine(possibleEruption != null ? possibleEruption.ToString() : $"No {curLocale} eruption found.");
curLocale = "Greenland";
possibleEruption = eruptions.FirstOrDefault(eruption => eruption.Location.Equals(curLocale), null);
Console.WriteLine(possibleEruption != null ? possibleEruption.ToString() : $"No {curLocale} eruption found.");
// Find first eruption after 1900 and in New Zealand
Eruption? nzEruption = eruptions.Where(e => e.Location.Equals("New Zealand")).FirstOrDefault(e => e.Year > 1900, null);
Console.WriteLine(nzEruption != null ? nzEruption.ToString() : $"No New Zealand eruption found.");
// Find all eruptions where the elevation is over 2000m
IEnumerable<Eruption> eruptionsOver2000m = eruptions.Where(e => e.ElevationInMeters > 2000);
PrintEach(eruptionsOver2000m,"All volcanoes over 2000 meters in elevation:");
// Find all eruptions where the volcano's name starts with "L", print them, then print the number found
IEnumerable<Eruption> eruptionsStartingWithL = eruptions.Where(e => e.Volcano.ToUpper().StartsWith('L'));
PrintEach(eruptionsStartingWithL, "All volcanoes starting with L:");
Console.WriteLine("There is/are "+eruptionsStartingWithL.Count()+" volcano(es) that start with L.");
// Find the highest elevation of all the volcanoes, then print it, and use that value to find the highest volcano
int? maxElevation = eruptions.Count > 0 ? eruptions.Max(e => e.ElevationInMeters) : null;
Console.WriteLine(maxElevation != null ? $"The max elevation is {maxElevation} meters." : "No volcanoes available, so we can't find the max elevation.");
Eruption? highestVolcano = eruptions.Count > 0 && maxElevation != null ? 
    eruptions.FirstOrDefault(e => e.ElevationInMeters == maxElevation,null) :
    null;
Console.WriteLine(highestVolcano != null ? $"The highest volcano is {highestVolcano.Volcano}." : "No volcanoes found.");
// Print all eruptions in alphabetical order
IEnumerable<Eruption> eruptionsInAlphabeticalOrder = eruptions.OrderBy(e => e.Volcano);
PrintEach(eruptionsInAlphabeticalOrder,"Volcanoes in alphabetical order:");
// Add up all the elevations
int? totalElevations = eruptions.Count > 0 ? eruptions.Sum(e => e.ElevationInMeters) : null;
Console.WriteLine(totalElevations != null ? $"The total elevation of all volcanoes = {totalElevations} meter(s)." : "No volcanoes found.");
// Check to see whether any volcanoes erupted in 2000
bool didEruptIn2000 = eruptions.Any(e => e.Year == 2000);
Console.WriteLine("There {0} that erupted in 2000.",didEruptIn2000 ? "was at least 1 volcano" : "were no volcanoes");
// Grab the first 3 volcanoes that are stratovolcanoes
IEnumerable<Eruption> stratovolcanoes = eruptions.Where(e => e.Type.Equals("Stratovolcano")).Take(3);
PrintEach(stratovolcanoes, "The first 3 stratovolcanoes found:");
// Grab all volcanoes alphabetically that happened before 1000 - first, with all info, then by name only
IEnumerable<Eruption> eruptionsBefore1000Alphabetically = eruptions.Where(e => e.Year < 1000).OrderBy(e => e.Volcano);
PrintEach(eruptionsBefore1000Alphabetically, "All volcanoes that erupted before the year 1000 alphabetically:");
Console.WriteLine("Volcanoes that erupted before 1000 by name only:");
IEnumerable<string> eruptionsBefore1000ByNameOnly = eruptionsBefore1000Alphabetically.Select((e) => e.Volcano);
foreach(string volcano in eruptionsBefore1000ByNameOnly)
{
    Console.WriteLine(volcano);
}

// Helper method to print each item in a List or IEnumerable. This should remain at the bottom of your class!
static void PrintEach(IEnumerable<Eruption> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (Eruption item in items)
    {
        Console.WriteLine(item.ToString());
    }
}

