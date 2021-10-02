using System;

namespace PE12Q3
{
	// Class: MyClass
	// Author: Robert Gregory Disbrow
	// Purpose: a simple class that has a myString private variable and it has a write only property for that variable, it also has a method called GetString
	//			that gets the myString variable
	// Restrictions: None
	public class MyClass
	{
		private string myString;

		public string MyString
		{
			set
			{
				myString = "Robby";
			}
		}

		// Method: GetString
		// Purpose: Gets the myString variable
		// Restrictions: None
		public virtual string GetString()
		{
			return myString;
		}
	}

	// Class: MyDerivedClass
	// Author: Robert Gregory Disbrow
	// Purpose: The child class of MyClass that overrides the GetString method from the parent class to also include an output of code that tells the user that
	//			the GetString that was used was form the derived class
	// Restrictions: None
	public class MyDerivedClass : MyClass
    {
        public override string GetString()
        {
            return base.GetString() + " (output from the derived class)";
		}
    }

	// Class: Program
	// Author: Robert Gregory Disbrow
	// Purpose: The only purpose is to test out the previous classes and variables by creating an object of the child class and then trying to use the child
	//			class's method
	// Restrictions: None
	class Program
    {
		// Method: Main
		// Purpose: Tests the other classes within the program by making a MyDerivedClass object called test and prints out the result of the use of the
		//			GetString method from the child class
		// Restrictions: None
		static void Main(string[] args)
        {
			MyDerivedClass test = new MyDerivedClass();
			Console.WriteLine(test.GetString());
        }
    }
}