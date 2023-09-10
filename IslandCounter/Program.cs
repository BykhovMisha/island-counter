Console.WriteLine("Please provide map string:");
var userInput = Console.ReadLine()!;

var islandCounter = new IslandCounter();
var result = islandCounter.Solve(userInput);

Console.WriteLine($"Answer: {result}");