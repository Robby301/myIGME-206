using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE8Q8
{
    class Program
    {
        static void Main(string[] args)
        {
            string sentence = "No, I have nothing in my purse!";

            sentence = sentence.Replace("No", "Yes");
            sentence = sentence.Replace("no", "yes");

            Console.WriteLine(sentence);
        }
    }
}
