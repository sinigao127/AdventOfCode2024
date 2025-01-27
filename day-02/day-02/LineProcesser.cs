
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

            return IsAllNegative(list) || IsAllPositive(list);
        }

        private static bool IsAllNegative(List<int> list)
        {
            return list.TrueForAll(x => x < 0);
        }

        private static bool IsAllPositive(List<int> list)
        {
            return list.TrueForAll(x => x > 0);
        }

        private static bool IsAtRangOfOneToThree(List<int> list)
        {
            var positveList = list.ConvertAll(x => Math.Abs(x));
            return positveList.TrueForAll(x => x >= 1 && x <= 3); 
        }

        private List<int> GetAdjacentDifferList(List<int> intList)
        {
            var adjacentDifferList = new List<int>();
            for (int i = 0; i < intList.Count - 1; i++)
            {
                adjacentDifferList.Add(intList[i] - intList[i + 1]);
            }
            return adjacentDifferList;
        }

        // The levels are either all increasing or all decreasing.
        // Any two adjacent levels differ by at least one and at most three.
        internal bool validate(List<int> intList)
        {
            var adjacentDifferList = GetAdjacentDifferList(intList);
            if (IsAllIncresingOrDecresing(adjacentDifferList) && IsAtRangOfOneToThree(adjacentDifferList))
            {
                return true;
            }
            return false;
        }

        internal int ValidateIntLists(List<List<int>> intLists)
        {   
            var safeNumber = 0;
            foreach (var intList in intLists)
            {
                if (validate(intList))
                {
                    safeNumber++;
                }
            }
            return safeNumber;
        }

        internal bool IsValidAfterRemoveOneElement(List<int> intList)
        {
            for (int i = 0; i < intList.Count; i++)
            {
                var temp = new List<int>(intList);
                temp.RemoveAt(i);
                if (validate(temp))
                {
                    return true;
                }
            }
            return false;
        }

        internal int ValidateIntListsWithProblemDepensor(List<List<int>> intLists)
        {
            var safeNumber = 0;
            foreach (var intList in intLists)
            {
                if (validate(intList))
                {
                    safeNumber++;
                }else{
                   if (IsValidAfterRemoveOneElement(intList))
                    {
                        safeNumber++;
                    }
                }
            }
            return safeNumber;
        }
    }
}
