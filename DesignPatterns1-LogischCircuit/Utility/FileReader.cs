using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns1_LogischCircuit.Utility
{
    static class FileReader
    {
        private static String folderName = "circuits";

        public static String[] ReadFile(int level)
        {
            String downloads = Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents") + @"\" + folderName + "\\Circuit" + level + ".txt";
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

            return fileLines.ToArray();
        }
        
        public static int CountFiles()
        {
            return Directory.GetFiles(Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents") + @"\"+ folderName).Length;
        }
    }
}
