using System;
using System.Collections.Generic;
using System.Linq;

namespace Wizard
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Wizard> wizards = new List<Wizard>();

            Wizard wizard1 = new Wizard("Robby", 301);
            Wizard wizard2 = new Wizard("Noah", 75);
            Wizard wizard3 = new Wizard("Dan", 746);
            Wizard wizard4 = new Wizard("Matt", 1);
            Wizard wizard5 = new Wizard("Glenn", 1000000);
            Wizard wizard6 = new Wizard("Tom", 323);
            Wizard wizard7 = new Wizard("Jake", 500);
            Wizard wizard8 = new Wizard("Randy", 7);
            Wizard wizard9 = new Wizard("Brett", 23);
            Wizard wizard10 = new Wizard("Ryan", 999999);

            wizards.Add(wizard1);
            wizards.Add(wizard2);
            wizards.Add(wizard3);
            wizards.Add(wizard4);
            wizards.Add(wizard5);
            wizards.Add(wizard6);
            wizards.Add(wizard7);
            wizards.Add(wizard8);
            wizards.Add(wizard9);
            wizards.Add(wizard10);

            wizards.Sort();

            for (int i = 0; i < wizards.Count(); i++)
            {
                Console.WriteLine(wizards[i]);
            }


        }
    }

    class Wizard : IComparable<Wizard>
    {
        string wName;
        int wAge;

        public Wizard(string name, int age)
        {
            this.wName = name;
            this.wAge = age;
        }

        public int CompareTo(Wizard other)
        {
            return this.wAge.CompareTo(other.wAge);
        }

        public override string ToString()
        {
            return ("Name: " + wName + " Age: " + wAge);
        }
    }
}