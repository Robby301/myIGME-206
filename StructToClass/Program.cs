using System;

namespace StructToClass
{
    // Class: Friend
    // Author: Robert Gregory Disbrow
    // Purpose: This class was changed from a struct to try to get the same output the struct could do (was an issue, needed to implement the Clone method for shallow
    //          copying used later in the program)
    // Restrictions: None
    public class Friend
    {
        public string name;
        public string greeting;
        public DateTime birthdate;
        public string address;

        public Object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    // Class: Program
    // Author: Robert Gregory Disbrow
    // Purpose: This is the part of the program that tests to see if the new Friend class still performs the same as the previous Friend struct
    // Restrictions: None
    class Program
    {
        static void Main(string[] args)
        {
            Friend friend = new Friend();
            Friend enemy;

            // create my friend Charlie Sheen
            friend.name = "Charlie Sheen";
            friend.greeting = "Dear Charlie";
            friend.birthdate = DateTime.Parse("1967-12-25");
            friend.address = "123 Any Street, NY NY 12202";

            // now he has become my enemy
            enemy = (Friend)friend.Clone();

            // set the enemy greeting and address without changing the friend variable
            enemy.greeting = "Sorry Charlie";
            enemy.address = "Return to sender.  Address unknown.";

            Console.WriteLine($"friend.greeting => enemy.greeting: {friend.greeting} => {enemy.greeting}");
            Console.WriteLine($"friend.address => enemy.address: {friend.address} => {enemy.address}");
        }
    }
}