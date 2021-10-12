using System;

namespace CafeLib
{
    // Interface: IMood
    // Author: Robert Gregory Disbrow
    // Purpose: This section sets up an interface that has a read only property called Mood
    // Restrictions: None
    public interface IMood
    {
        string Mood
        {
            get;
        }
    }
    // Class: Waiter
    // Author: Robert Gregory Disbrow
    // Purpose: This class implements the IMood interface and handles a method called ServeCustomer that allows the waiter to "serve the customer"
    // Restrictions: None
    public class Waiter : IMood
    {
        public string name;

        public string Mood
        {
            get
            {
                return Mood;
            }
        }
        public void ServeCustomer(HotDrink cup)
        {
            Console.WriteLine("Here is your " + cup);
        }
    }
    // Class: Customer
    // Author: Robert Gregory Disbrow
    // Purpose: Also implements IMood and allows to handle all the information regarding the customer, such as the name and credit card number
    // Restrictions: None
    public class Customer : IMood
    {
        public string name;
        public string creditCardNumber;

        public string Mood
        {
            get
            {
                return Mood;
            }
        }
    }

    // Interface: ITakeOrder
    // Author: Robert Gregory Disbrow
    // Purpose: ITakeOrder is an interface that has one method called TakeOrder that will be used later within the program
    // Restrictions: None
    public interface ITakeOrder
    {
        void TakeOrder();
    }
    // Class: HotDrink
    // Author: Robert Gregory Disbrow
    // Purpose: An abstract class that the rest of the below classes inherit from (HotDrink is the overall parent class to all the below classes). HotDrink also 
    //          has several variables and methods that all the other classes (or hot drinks) will need to use.
    // Restrictions: None
    public abstract class HotDrink
    {
        public bool instant;
        public bool milk;
        private byte sugar;
        public string size;
        public Customer customer;

        public virtual void AddSugar(byte amount)
        {
            sugar += amount;
        }
        public abstract void Steam();

        public HotDrink()
        {

        }
        public HotDrink(string brand)
        {

        }
    }
    // Class: CupOfCoffee
    // Author: Robert Gregory Disbrow
    // Purpose: This class is the child of HotDrink and inherits the ITakeOrder interface. This class overrides previous methods, and has a variable of its own
    //          that all relates to a CupOfCoffee
    // Restrictions: None
    public class CupOfCoffee : HotDrink, ITakeOrder
    {
        public string beanType;

        public override void Steam()
        {
            Console.WriteLine("Yep, this coffee's steamin.");
        }
        public void TakeOrder()
        {
            Console.WriteLine("Would you like the coffee?");
        }

        public CupOfCoffee(string brand) : base(brand)
        {

        }
    }
    // Class: CupOfTea
    // Author: Robert Gregory Disbrow
    // Purpose: This class is the child of HotDrink and inherits the ITakeOrder interface. This class overrides previous methods, and has a variable of its own
    //          that all relates to a CupOfTea
    // Restrictions: None
    public class CupOfTea : HotDrink, ITakeOrder
    {
        public string leafType;

        public override void Steam()
        {
            Console.WriteLine("This tea is surely steamin.");
        }
        public void TakeOrder()
        {
            Console.WriteLine("Would you like the tea?");
        }

        public CupOfTea(bool customerIsWealthy)
        {

        }
    }
    // Class: CupOfCocoa
    // Author: Robert Gregory Disbrow
    // Purpose: This class is the child of HotDrink and inherits the ITakeOrder interface. This class overrides previous methods, and has variables of its own
    //          that all relates to a CupOfCocoa
    // Restrictions: None
    public class CupOfCocoa : HotDrink, ITakeOrder
    {
        public static int numCups;
        public bool marshmallows;
        private string source;

        public string Source
        {
            set
            {
                source = Console.ReadLine();
            }
        }
        public override void Steam()
        {
            Console.WriteLine("This is a steamin cup of cocoa");
        }
        public override void AddSugar(byte amount)
        {
            base.AddSugar(amount);
        }
        public void TakeOrder()
        {
            Console.WriteLine("Would you like the cup of cocoa?");
        }

        /*
         * I was unsure of how to approac this section
        public CupOfCocoa this[bool theBool]
        {

        }
        */
        public CupOfCocoa(bool marshmallows) : base("Expensive Organic Brand")
        {

        }
    }
}