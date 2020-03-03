using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Run_Length_Encode
{
    public static class TUI
    {
        public static void Initialize(string[] files, int fileNumber)
        {
            Console.WriteLine("Current files:");
            for(int i = 1; i <= fileNumber; i++)
            {
                Console.WriteLine("" + i + ": " + files[i - 1]);
                
            }
            Console.WriteLine("Please Enter a number between 1 and " + fileNumber);
        }

        public static void NonNumber()
        {
            Console.WriteLine();
            Console.WriteLine("Please enter an appropriate number.");
        }

        public static void ProcessError()
        {
            Console.WriteLine();
            Console.WriteLine("Unrecognised input, please enter input as instructed");
        }

        public static void ProcessPrompt()
        {
            Console.WriteLine();
            Console.WriteLine("Now please enter the process you'd like to perform.");
            Console.WriteLine("Encode = E, Decode = D");
        }

        public static void DisplayProcess(string raw, string processed)
        {
            Console.WriteLine();
            Console.WriteLine("Raw file data: " + raw);
            Console.WriteLine("Processed file data: " + processed);
        }

        public static void DisplayCompressionRatio(float ratio)
        {
            Console.WriteLine("Compression ratio: " + ratio);
        }


    }
}
