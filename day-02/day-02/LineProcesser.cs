
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
    }
}
