using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Run_Length_Encode
{
    public static class FileHandler
    {

        private static StreamReader reader;
        private static FileStream fileStream;

        public static string[] GetFiles()
        {
            return Directory.GetFiles("Files/");
        }

        public static void OpenFile(string fileName)
        {
            if (fileStream != null) fileStream.Close();
            fileStream = File.Open(fileName, FileMode.Open, FileAccess.Read);
            reader = new StreamReader(fileStream);
        }

        public static string GetText()
        {
            return reader.ReadToEnd();
        }

        public static void WriteFile(string fileText, string fileName)
        {
            File.WriteAllText(fileName, fileText);
        }

    }
}
