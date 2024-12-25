// See https://aka.ms/new-console-template for more information
using day_02;

var lineProcessor = new LineProcesser(@"C:\others\AdventOfCode2024\day-02\input.txt");
var intLists = lineProcessor.GetIntLists();

Console.WriteLine("Orignal List");
foreach (var intList in intLists)
{
    Console.WriteLine(string.Join(" ", intList));
}

var safeNumber = lineProcessor.ValidateIntLists(intLists);
Console.WriteLine($"Part 1 how many reports are safe: {safeNumber}");