using day_01_solution;

Console.WriteLine("Day one Part 1");

var lineProcessor = new LineProcessor(@"C:\others\AdventOfCode2024\day-01\day-01-solution\input.txt");
int sum = lineProcessor.CalculateSumOfDifferece();

Console.WriteLine($"The Sum is: {sum}");

Console.WriteLine("Day one Part 2");

int score = lineProcessor.CalculateSimilarityScore();

Console.WriteLine($"The Sum is: {score}");