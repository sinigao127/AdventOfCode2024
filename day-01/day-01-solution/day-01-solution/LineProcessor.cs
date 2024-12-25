using day_01_solution;

namespace day_01_solution {
    public class LineProcessor
    {
        private readonly string _filePath;

        public LineProcessor(string filePath)
        {
            _filePath = filePath;
        }

        public LeftAndRightIntListModel GetLeftAndRightIntList()
        {
            string[] lines = File.ReadAllLines(_filePath);

            var leftLine = new List<int>();
            var rightLine = new List<int>();

            foreach (string line in lines)
            {
                string[] eachLine = line.Split("   ");
                leftLine.Add(int.Parse(eachLine[0]));
                rightLine.Add(int.Parse(eachLine[1]));
            }

            return new LeftAndRightIntListModel
            {
                LeftLine = leftLine,
                RightLine = rightLine
            };
        }


        public int CalculateSumOfDifferece()
        {
            var leftAndRightIntListModel = GetLeftAndRightIntList();
            var leftLine = leftAndRightIntListModel.LeftLine;
            var rightLine = leftAndRightIntListModel.RightLine;

            var differences = new List<int>();

            for (int i = 0; i <leftLine.Count; i++)
            {
                differences.Add(Math.Abs(rightLine[i] - leftLine[i]));
            }

            return differences.Sum();
        }

        public int CalculateSimilarityScore()
        {
            var leftAndRightIntListModel = GetLeftAndRightIntList();
            var leftLine = leftAndRightIntListModel.LeftLine;
            var rightLine = leftAndRightIntListModel.RightLine;

            var score = 0;

            for (int i = 0; i < leftLine.Count; i++)
            {
               int count = rightLine.FindAll(x => x == leftLine[i]).Count;
               score += leftLine[i]*count;
            }

            return score;
        }
    }
}
