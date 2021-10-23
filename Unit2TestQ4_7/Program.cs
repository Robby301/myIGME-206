using System;

namespace Unit2TestQ4_7
{
    // Class: Phone
    // Author: Robert Gregory Disbrow
    // Purpose: The phone is an abstract class and is the highest class in the hierarchy (meaning it is the parent class of the other classes).
    //          This class also holds important variables, properties, and methods that the child classes will use.
    // Restrictions: None
    public abstract class Phone
    {
        private string phoneNumber;
        public string address;

        public string PhoneNumber
        {
            get
            {
                return this.phoneNumber;
            }
            set
            {
                this.phoneNumber = value;
            }
        }
        public abstract void Connect();
        public abstract void Disconnect();
    }
    // Interface: PhoneInterface
    // Author: Robert Gregory Disbrow
    // Purpose: This interface is used in the RotaryPhone and PushButtonPhone classes and contains the important template of methods that are essential in those child
    //          classes.
    // Restrictions: None
    public interface PhoneInterface
    {
        void Answer();
        void MakeCall();
        void HangUp();
    }

    // Class: RotaryPhone
    // Author: Robert Gregory Disbrow
    // Purpose: The RotaryPhone class is the child class of Phone and implements the PhoneInterface interface.
    //          All appropriate methods are carried over/overrided, with the only difference/importance being that the MakeCall and HangUp methods both have a unique
    //          output that is important for later in the program for when polymorphism is tested.
    // Restrictions: None
    public class RotaryPhone : Phone, PhoneInterface
    {
        public void Answer()
        {

        }
        public void MakeCall()
        {
            Console.WriteLine("A call from a rotary phone was made.");
        }
        public void HangUp()
        {
            Console.WriteLine("A call from a rotary phone has concluded.");
        }
        public override void Connect()
        {
            
        }
        public override void Disconnect()
        {
            
        }
    }
    // Class: PushButtonPhone
    // Author: Robert Gregory Disbrow
    // Purpose: The PushButtonPhone class is the child class of Phone and implements the PhoneInterface interface.
    //          All appropriate methods are carried over/overrided, with the only difference/importance being that the MakeCall and HangUp methods both have a unique
    //          output that is important for later in the program for when polymorphism is tested.
    // Restrictions: None
    public class PushButtonPhone : Phone, PhoneInterface
    {
        public void Answer()
        {

        }
        public void MakeCall()
        {
            Console.WriteLine("A call from a push button phone was made.");
        }
        public void HangUp()
        {
            Console.WriteLine("A call from a push button phone has concluded.");
        }
        public override void Connect()
        {
            
        }
        public override void Disconnect()
        {
            
        }
    }

    // Class: Tardis
    // Author: Robert Gregory Disbrow
    // Purpose: This class is the child of the RotaryPhone class
    //          The Tardis class has many new variables, properties, and methods that are unique to this class. The most important of these being the set of methods
    //          that overload the traditional boolean operators (==, !=, <, >, <=, >=). These are here so that the boolean operators specifically compare using the
    //          whichDrWho byte variable
    // Restrictions: None
    public class Tardis : RotaryPhone
    {
        private bool sonicScrewdriver;
        private byte whichDrWho;
        private string femaleSideKick;
        public double exteriorSurfaceArea;
        public double interiorVolume;

        public byte WhichDrWho
        {
            get
            {
                return this.whichDrWho;
            }
        }
        public string FemaleSideKick
        {
            get
            {
                return this.femaleSideKick;
            }
        }
        public void TimeTravel()
        {
            Console.WriteLine("YOU'RE TIME TRAVELING!!!");
        }
        public static bool operator == (Tardis drWho1, Tardis drWho2)
        {
            if(drWho1.WhichDrWho == drWho2.WhichDrWho)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator != (Tardis drWho1, Tardis drWho2)
        {
            if(drWho1.WhichDrWho != drWho2.WhichDrWho)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator < (Tardis drWho1, Tardis drWho2)
        {
            if(drWho1.WhichDrWho == 10)
            {
                return false;
            }
            else if (drWho1.WhichDrWho < drWho2.WhichDrWho)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator > (Tardis drWho1, Tardis drWho2)
        {
            if (drWho2.WhichDrWho == 10)
            {
                return false;
            }
            else if (drWho1.WhichDrWho > drWho2.WhichDrWho)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator <= (Tardis drWho1, Tardis drWho2)
        {
            if ((drWho1.WhichDrWho == 10) && (drWho2.WhichDrWho == 10))
            {
                return true;
            }
            else if (drWho1.WhichDrWho == 10)
            {
                return false;
            }
            else if (drWho1.WhichDrWho <= drWho2.WhichDrWho)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator >= (Tardis drWho1, Tardis drWho2)
        {
            if ((drWho1.WhichDrWho == 10) && (drWho2.WhichDrWho == 10))
            {
                return true;
            }
            else if (drWho2.WhichDrWho == 10)
            {
                return false;
            }
            else if (drWho1.WhichDrWho >= drWho2.WhichDrWho)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    // Class: PhoneBooth
    // Author: Robert Gregory Disbrow
    // Purpose: This class is the child class of the PushButtonPhone class and has unique variables and methods that will slightly be used later in the program
    // Restrictions: None
    public class PhoneBooth : PushButtonPhone
    {
        private bool superMan;
        public double costPerCall;
        public bool phoneBook;

        public void OpenDoor()
        {
            Console.WriteLine("The door has been opened.");
        }
        public void CloseDoor()
        {

        }
    }

    // Class: Program
    // Author: Robert Gregory Disbrow
    // Purpose: This is the main meat of the program that will handle the testing of polymorphism within this program by testing the output from a Tardis class object
    //          vs a PhoneBooth class object.
    // Restrictions: None
    class Program
    {
        // Method: UsePhone
        // Purpose: This method is used within main to test the polymorphism of the program by having the Tardis class object use its interface to call the MakeCall
        //          and HangUp methods. Then depedning on the type of class it uses a special method from that class.
        // Restrictions: None
        static void UsePhone(object obj)
        {
            if (obj.GetType() == typeof(Tardis))
            {
                Tardis tardisInUse = (Tardis)obj;
                PhoneInterface tardisInterface = (PhoneInterface)obj;
                tardisInterface.MakeCall();
                tardisInterface.HangUp();
                tardisInUse.TimeTravel();
            }
            else if (obj.GetType() == typeof(PhoneBooth))
            {
                PhoneBooth phoneboothInUse = (PhoneBooth)obj;
                PhoneInterface phoneboothInterface = (PhoneInterface)obj;
                phoneboothInterface.MakeCall();
                phoneboothInterface.HangUp();
                phoneboothInUse.OpenDoor();
            }
        }
        // Method: Main
        // Purpose: The main is used to test the polymorphism of the program
        // Restrictions: None
        static void Main(string[] args)
        {
            Tardis theTardis = new Tardis();
            PhoneBooth thePhonebooth = new PhoneBooth();

            UsePhone(theTardis);
            UsePhone(thePhonebooth);
        }
    }
}