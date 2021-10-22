using System;

namespace Unit2TestQ4_7
{
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
    public interface PhoneInterface
    {
        void Answer();
        void MakeCall();
        void HangUp();
    }

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

    class Program
    {
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
        static void Main(string[] args)
        {
            Tardis theTardis = new Tardis();
            PhoneBooth thePhonebooth = new PhoneBooth();

            UsePhone(theTardis);
            UsePhone(thePhonebooth);
        }
    }
}