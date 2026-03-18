using System.Text.RegularExpressions;

namespace Scanner
{
    internal class Program
    {
        static void Main()
        {
            SourceCode Code = new SourceCode();
            Tokenize(Code.sourceCode);
        }

        static void Tokenize(string code)
        {
            // Removing Multiple Lines Comment
            code = Regex.Replace(code, @"/\*.*?\*/", "", RegexOptions.Singleline);
            // Removing One line Comment
            code = Regex.Replace(code, @"//.*", "");

            // Tokens Def
            var tokenDefinitions = new List<(string Name, string Pattern)>
            {
                ("KEYWORD", @"\b(int|main|if|else|return)\b"),
                ("NUMBER", @"\d+(\.\d+)?"),
                ("IDENTIFIER", @"\b[a-zA-Z_][a-zA-Z0-9_]*\b"),
                ("OPERATOR", @"==|[=\-+*/]"),
                ("SPECIALCHARACTER", @"[(){};,]")
            };

            // دمج كل الأنماط في Regex واحد
            string fullPattern = "";
            foreach (var def in tokenDefinitions)
            {
                fullPattern += $"(?<{def.Name}>{def.Pattern})|";
            }
            fullPattern = fullPattern.TrimEnd('|');

            Regex regex = new Regex(fullPattern);
            MatchCollection matches = regex.Matches(code);

            // Printing The Specific Output Format
            foreach (Match match in matches)
            {
                foreach (var def in tokenDefinitions)
                {
                    if (match.Groups[def.Name].Success)
                    {
                        Console.WriteLine($"<{def.Name}, {match.Value}>");
                        break;
                    }
                }
            }
        }
    }
}
