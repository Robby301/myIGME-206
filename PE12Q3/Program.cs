using System;

namespace PE12Q3
{
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

		public virtual string GetString()
		{
			return myString;
		}
	}

	public class MyDerivedClass : MyClass
    {
        public override string GetString()
        {
            return base.GetString() + " (output from the derived class)";
		}
    }

	class Program
    {
        static void Main(string[] args)
        {
			MyDerivedClass test = new MyDerivedClass();
			Console.WriteLine(test.GetString());
        }
    }
}