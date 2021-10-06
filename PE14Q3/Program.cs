using System;

namespace PE14Q3
{
    // Interface: Professors
    // Author: Robert Gregory Disbrow
    // Purpose: Implement a method called SayHello() that will be used by the CSProfessor and HISTProfessor classes later in the program; and SayHello's purpose
    //          is to just use Console.WriteLine to post something into the console depending on what class is using SayHello.
    // Restrictions: None
    public interface Professors
    {
        void SayHello();
    }

    // Class: CSProfessor
    // Author: Robert Gregory Disbrow
    // Purpose: The CSProfessor class inherits the Professors interface and implements the SayHello method definined by the interface to return a message into the
    //          console saying "Hello, I am a computer science professor!"
    // Restrictions: None
    public class CSProfessor : Professors
    {
        public void SayHello()
        {
            Console.WriteLine("Hello, I am a computer science professor!");
        }
    }
    // Class: HISTProfessor
    // Author: Robert Gregory Disbrow
    // Purpose: The HISTProfessor class inherits the Professors interface and implements the SayHello method definined by the interface to return a message into
    //          the console saying "Hello, I am a history science professor!"
    // Restrictions: None
    public class HISTProfessor : Professors
    {
        public void SayHello()
        {
            Console.WriteLine("Hello, I am a history professor!");
        }
    }

    // Class: Program
    // Author: Robert Gregory Disbrow
    // Purpose: Program has a main method and a MyMethod method which are both used to create an object of CSProfessor and HISTProfessor and then they both call
    //          the SayHello method, which should return a different message into the console because each class had a different console output for the SayHello
    //          method.
    // Restrictions: None
    class Program
    {
        // Method: MyMethod
        // Purpose: MyMethod is used to call the SayHello method from the interface, and depending on the type of class object that is used the outcome will either
        //          be the output for the CSProfessor class or the HISTProfessor class
        // Restrictions: None
        public static void MyMethod(object myObject)
        {
            Professors professorInterfaceCheck = (Professors)myObject;
            professorInterfaceCheck.SayHello();
        }
        // Method: Main
        // Purpose: The main is used to create two objects, one being for the CSProfessor class and the other being for the HISTProfessor class. Then the MyMethod
        //          method is called with each object as a parameter, which should allow both outcomes of SayHello to be printed to the console.
        // Restrictions: None
        static void Main(string[] args)
        {
            CSProfessor davidSchuh = new CSProfessor();
            HISTProfessor corinnaSchlombs = new HISTProfessor();

            MyMethod(davidSchuh);
            MyMethod(corinnaSchlombs);
        }
    }
}