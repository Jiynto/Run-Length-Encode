using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Run_Length_Encode
{
    class Program
    {
        static void Main(string[] args)
        {
            string raw1 = "bbbbsssddd bds wwwweeee lk kkjsdhfnnnn hhhhiiiiiqwe wieiekkkkri kk3p sjddjdddiop ioooiieeerruuuuuu";
            string raw2 = "4444444423455623456.4555555878888888888886555556764566533333295292834j";
            string encode1 = Encoder.Encode(raw1);
            string encode2 = Encoder.Encode(raw2);
            string decode1 = Encoder.Decode(encode1);
            Console.WriteLine(raw1);
            Console.WriteLine(encode1);
            Console.WriteLine(decode1);
            Console.WriteLine(raw2);
            Console.WriteLine(encode2);
            Controller.Initialize();
        }
    }
}
