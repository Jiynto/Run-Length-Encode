using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Run_Length_Encode
{

    public static class Encoder
    {



        public static string Encode(string inputString) => inputString.Length == 0 ? "" 
            : inputString.Skip(1).Aggregate((length: 1, workingChar: inputString[0], workingString: new StringBuilder()),
            (workingTuple, currentChar) => workingTuple.workingChar == currentChar 
            ? (workingTuple.length + 1, workingTuple.workingChar, workingTuple.workingString) 
            : (1, currentChar, workingTuple.workingString.Append(workingTuple.length).Append(workingTuple.workingChar)), 
            resultTuple => resultTuple.workingString.Append(resultTuple.length).Append(resultTuple.workingChar)).ToString();


        public static float CompressionRatio(int unCompressedSize, int compressedSize) => ((float)unCompressedSize / (float)compressedSize);




        public static string Decode(string inputString) => inputString.Aggregate(
            (count: 1, occurance: 0, workingString: new StringBuilder()), 
                (workingTuple, currentChar) => IsEven(workingTuple.count) 
                ? (workingTuple.count + 1, workingTuple.occurance, workingTuple.workingString.Append(new string(currentChar, workingTuple.occurance)))
                : (workingTuple.count + 1, (int)Char.GetNumericValue(currentChar), workingTuple.workingString),
                a => a.workingString.ToString());



        public static bool correctFormat(string input)
        {
            bool isOk = Regex.IsMatch(input, @"^(\d{1}\D{1})+");
            return isOk;
        }

        public static bool IsEven(int count) => count % 2 == 0 ? true : false;
    }
}
