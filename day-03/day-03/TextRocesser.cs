using System.Text.RegularExpressions;

namespace day_03
{
    internal class TextProcesser
    {
        private readonly string _filePath;
        internal TextProcesser(string filePath)
        {
            _filePath = filePath;
        }

        internal string GetRawText() {
            return File.ReadAllText(_filePath);
        }

        internal static List<string> GetMatches(string input)
        {
            string pattern = @"mul\(\d{1,3},\d{1,3}\)";
            Regex regex = new Regex(pattern);
            var matchEnumerator = regex.EnumerateMatches(input).GetEnumerator();
            var list = new List<string>();
            while (matchEnumerator.MoveNext())
            {
                var match = matchEnumerator.Current;
                var length = match.Length;
                var index = match.Index;
                string matchValue = input.Substring(index, length);
                Console.WriteLine($"Match: '{length}' at Index: {index} value: {matchValue}");
                list.Add(matchValue);
            }
            return list;
        }

        internal static int GetResultOfMultification(List<string> list)
        {
            var sum = 0;
            foreach (var item in list)
            {
                var values = item.Split('(');
                var matchString = values[1].Replace(")", "");
                var numbers = matchString.Split(',');
                var num1 = int.Parse(numbers[0]);
                var num2 = int.Parse(numbers[1]);
                sum += num1 * num2;
            }
            return sum;
        }

        internal static MatchResult GetListBetweenDosAndDonts(string input)
        {
            var matchResult = new MatchResult() { MatchedString = "", MatchIndex = -1 };
            string pattern = @"do\(\)([\s\S]*?)don't\(\)";
            Regex regex = new Regex(pattern);
            if (regex.IsMatch(input)) { 
                matchResult.MatchIndex = regex.Match(input).Index;
                var matchEnumerator = regex.EnumerateMatches(input.Trim()).GetEnumerator();
                var list = new List<string>();
                while (matchEnumerator.MoveNext())
                {
                    var match = matchEnumerator.Current;
                    var length = match.Length;
                    var index = match.Index;
                    string matchValue = input.Substring(index, length);
                    list.Add(matchValue);
                }
                matchResult.MatchedString = string.Join("", list);
            }
            return matchResult;
        }

        internal static MatchResult GetStringBeforeFirstDo(string input)
        {
            var matchResult = new MatchResult() { MatchedString = "", MatchIndex = -1 };
            string pattern = @"do\(\)";
            Regex doRegex = new Regex(pattern);

            // Find the first do
            var match = doRegex.Match(input);
            if (match.Success)
            {
                var index = match.Index;
                // Get the string before the first do
                matchResult.MatchedString = input.Substring(0, index);
                matchResult.MatchIndex = index;

                // Check if there is a dont in the string before the first do
                string patternForDont = @"don't\(\)";
                Regex dontRegex = new Regex(patternForDont);
                var dontMatch = dontRegex.Match(matchResult.MatchedString);
                if (dontMatch.Success)
                {
                    var indexDont = dontMatch.Index;
                    // only get the string before the first dont
                    matchResult.MatchedString = matchResult.MatchedString.Substring(0, indexDont);
                }
            }
            
            return matchResult;
        }

        internal static MatchResult GetStringAfterLastDoThatNotFollowedWithDont(string input)
        {
            //search from the end of the string
            Regex regexForLastDo = new Regex(@"do\(\)", RegexOptions.RightToLeft);
            Regex regexForLastDont = new Regex(@"don't\(\)", RegexOptions.RightToLeft);
            var matchResult = new MatchResult() { MatchedString = "", MatchIndex = -1 };
            if (regexForLastDo.IsMatch(input) && regexForLastDont.IsMatch(input))
            {   
                var doIndex = regexForLastDo.Match(input).Index;
                var dontIndex = regexForLastDont.Match(input).Index;
                //if the last do is after the last dont
                if (doIndex > dontIndex)
                {
                    var match = regexForLastDo.Match(input);
                    var length = match.Length;
                    matchResult.MatchedString = input.Substring(doIndex + length);
                    matchResult.MatchIndex = doIndex;
                }
            }
            return matchResult;
        }

        internal static string GetSanitizedString(string input)
        {
            var firstMatch = GetStringBeforeFirstDo(input);
            var lastMatch = GetStringAfterLastDoThatNotFollowedWithDont(input);
            var firstPart = firstMatch.MatchedString;
            var lastPart = lastMatch.MatchedString;
            var matchString = "";
            if(firstPart.Length != 0)
            {
                input = input.Substring(firstMatch.MatchIndex);
                matchString += firstPart;
            }
            var secondPart = GetListBetweenDosAndDonts(input).MatchedString;
            if(secondPart.Length != 0)
            {
                matchString += secondPart; 
            }           
            if (lastPart.Length != 0)
            {
                matchString += lastPart;
            }
            return matchString;
        }
    }
}