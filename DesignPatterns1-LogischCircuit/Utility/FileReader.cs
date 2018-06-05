using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DesignPatterns1_LogischCircuit.Utility
{
    static class FileReader
    {
        private static readonly String _folderName = "circuits";
        private static readonly String _folderPath = Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents") + @"\" + _folderName;
        private static Boolean _setOutputs;
        private static Dictionary<string, string[]> _nodes;
        private static Dictionary<string, string[]> _outputs;

        public static Dictionary<string, string[]>[] ReadFile(string levelName)
        {
            _setOutputs = false;
            _nodes = new Dictionary<string, string[]>();
            _outputs = new Dictionary<string, string[]>();

            String downloads = _folderPath + "\\" + levelName + ".txt";
            System.IO.StreamReader file = new System.IO.StreamReader(downloads);

            StringBuilder builder = new StringBuilder();
            String lineBuffer;

            List<String> fileLines = new List<String>();
            while ((lineBuffer = file.ReadLine()) != null)
            {
                builder.Append(lineBuffer);
                fileLines.Add(builder.ToString());
                builder.Clear();
            }

            file.Close();

            String[] fileArray = fileLines.ToArray();

            foreach (string c in fileArray)
            {
                if (c.Length > 0 && c.First() == '#')
                {
                    continue;
                }
                if (c.Length == 0)
                {
                    _setOutputs = true;
                    continue;
                }

                if (!_setOutputs)
                {
                    String[] node = GetNode(c);
                    _nodes.Add(node[0], new string[] { node[1] });
                    
                }
                else
                {
                    String[][] output = GetOutput(c);
                    _outputs.Add(output[0][0], output[1]);
                }
            }

            return new Dictionary<string, string[]>[] { _nodes, _outputs };
        }

        private static String[] GetNode(String nodeText)
        {
            String nodeName = TrimText(nodeText, ':');
            String nodeType = FindType(nodeText); 
            return new String[] { nodeName, nodeType };
        }

        private static String TrimText(String text, Char TrimAtChar)
        {
            int index = text.IndexOf(TrimAtChar);
            if (index > 0)
            {
                return text.Substring(0, index);
            }
            return "";
        }

        private static String FindType(String text)
        {
            string pattern = @"[\w\d]+:[\s]+([\w,]+);";
            MatchCollection matches = Regex.Matches(text, pattern);
            return matches[0].Groups[1].Value;
        }

        private static String[] FindTypes(String text)
        {
            String[] types = FindType(text).Split(',');
            return types;
        }

        private static String[][] GetOutput(String outputText)
        {
            String nodeName = TrimText(outputText, ':');
            String[] outputNames = FindTypes(outputText);
            return new String[][] { new String[] { nodeName }, outputNames };
        }

        public static string[] GetFileNames()
        {
            string path = _folderPath;

            List<string> fileNames = new List<string>();

            if (!Directory.Exists(path))
                return fileNames.ToArray();

            foreach (string fileName in Directory.GetFiles(path) )
            {
                string pat = @"([\w\d^\]+[\d]+_[\w\d]+).txt"; 
                Regex r = new Regex(pat, RegexOptions.IgnoreCase);
                Match m = r.Match(fileName);
                fileNames.Add(m.Groups[1].Value);
            }

            return fileNames.ToArray();
        }

    }
}
