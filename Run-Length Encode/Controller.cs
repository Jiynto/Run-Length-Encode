using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Run_Length_Encode
{
    public static class Controller
    {
        static int fileNumber;
        static string[] files;
        static string file;
        static string filePath;


        public static void Initialize()
        {
            files = FileHandler.GetFiles();
            fileNumber = files.Count();
            TUI.Initialize(files, fileNumber);
            SelectFile();
        }

        private static void SelectFile()
        {
            char inputChar = Console.ReadKey().KeyChar;

            if (Char.IsDigit(inputChar))
            {
                int inputNumber = (int)Char.GetNumericValue(inputChar);
                if (0 < inputNumber && inputNumber <= fileNumber)
                {
                    LoadFile(inputNumber);
                    
                }
                else
                {
                    TUI.NonNumber();
                    SelectFile();
                }
            }
            else
            {
                TUI.NonNumber();
                SelectFile();
            }
        }

        private static void SelectProcess()
        {
            TUI.ProcessPrompt();
            ConsoleKey inputChar = Console.ReadKey().Key;

            if (inputChar.ToString().Equals("E"))
            {
                EncodeFile();
            }
            else if (inputChar.ToString().Equals("D"))
            {
                DecodeFile();
            } 
            else
            {
                
                TUI.ProcessError();
                SelectProcess();

            }
        }

        private static void EncodeFile()
        {
            string result = Encoder.Encode(file);
            FileHandler.WriteFile(result, filePath + "Encoded");
            float compressionRatio = Encoder.CompressionRatio(file.Length, result.Length);
            TUI.DisplayProcess(file, result);
            TUI.DisplayCompressionRatio(compressionRatio);
            Initialize();
        }

        private static void DecodeFile()
        {
            if (Encoder.correctFormat(file))
            {
                string result = Encoder.Decode(file);
                FileHandler.WriteFile(result, filePath + "Decoded");
                TUI.DisplayProcess(file, result);
                Initialize();
            }
            else
            {
                TUI.WrongFileFormat();
                Initialize();
            }
            
        }


        private static void LoadFile(int inputNumber)
        {
           
            filePath = files[inputNumber - 1];
            FileHandler.OpenFile(filePath);
            file = FileHandler.GetText();
            SelectProcess();
        }


    }
}
