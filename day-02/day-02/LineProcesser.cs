
using System;
using System.Net.Http.Headers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace day_02
{
    internal class LineProcesser
    {
        private readonly string _filePath;
        internal LineProcesser(string filePath)
        {
            _filePath = filePath;
        }

        internal List<List<int>> GetIntLists() {
            var intLists = new List<List<int>>();
            var lines = File.ReadAllLines(_filePath);
            foreach (var line in lines)
            {
                var intList = new List<int>();
                var numbers = line.Split(' ');
                foreach (var number in numbers)
                {
                    intList.Add(int.Parse(number));
                }
                intLists.Add(intList);
            }
            return intLists;
        }

        private static bool IsAllIncresingOrDecresing(List<int> list) {
            bool allNegative = list.TrueForAll(x => x < 0);
            bool allPositive = list.TrueForAll(x => x > 0);
            return allNegative || allPositive;
        }

        private static bool IsAtRangOfOneToThree(List<int> list)
        {
            var positveList = list.ConvertAll(x => Math.Abs(x));
            return positveList.TrueForAll(x => x >= 1 && x <= 3); 
        }

        // The levels are either all increasing or all decreasing.
        // Any two adjacent levels differ by at least one and at most three.
        internal int ValidateIntLists(List<List<int>> intLists)
        {   
            var safeNumber = 0;
            foreach (var intList in intLists)
            {
                var adjacentDifferList = new List<int>();
                for (int i = 0; i < intList.Count - 1; i++)
                {
                    adjacentDifferList.Add(intList[i] - intList[i + 1]);
                }
                if (IsAllIncresingOrDecresing(adjacentDifferList) && IsAtRangOfOneToThree(adjacentDifferList))
                {
                    safeNumber++;
                }

            }
            return safeNumber;
        }
    }
}
