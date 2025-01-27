// See https://aka.ms/new-console-template for more information
using day_03;

var textProcessor = new TextProcesser(@"C:\others\AdventOfCode2024\day-03\input.txt");
var rawText = textProcessor.GetRawText();

var list = TextProcesser.GetMatches(rawText);
var result = TextProcesser.GetResultOfMultification(list);
Console.WriteLine("Answer day 3 first question: " + result);

var newText = TextProcesser.GetSanitizedString(rawText);
var list2 = TextProcesser.GetMatches(newText);
var result2 = TextProcesser.GetResultOfMultification(list2);
Console.WriteLine("Answer day 3 second question: " + result2);