using System;
using System.Collections.Generic;

namespace PetApp
{
    // Class: Pet
    // Author: Robert Gregory Disbrow
    // Purpose: This class sets up the general format/layout for what a Pet object can contain
    // Restrictions: None
    public abstract class Pet
    {
        private string name;
        public int age;

        public Pet()
        {

        }
        public Pet(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public string Name;
        public abstract void Eat();
        public abstract void Play();
        public abstract void GotoVet();
    }
    // Interface: ICat
    // Author: Robert Gregory Disbrow
    // Purpose: This interface is used to set up the layout/methods that the Cat pet can use
    // Restrictions: None
    public interface ICat
    {
        void Eat();
        void Play();
        void Scratch();
        void Purr();
    }
    // Interface: IDog
    // Author: Robert Gregory Disbrow
    // Purpose: This interface is used to set up the layout/methods that the Dog pet can use
    // Restrictions: None
    public interface IDog
    {
        void Eat();
        void Play();
        void Bark();
        void NeedWalk();
        void GotoVet();
    }

    // Class: Cat
    // Author: Robert Gregory Disbrow
    // Purpose: The Cat class sets up the template for Cat objects, cat is also a child class of the Pet class and it implements the ICat interface
    // Restrictions: None
    public class Cat : Pet, ICat
    {
        public Cat()
        {

        }

        public override void Eat()
        {
            Console.WriteLine(Name + " is enjoying some raw tuna");
        }
        public override void Play()
        {
            Console.WriteLine(Name + " is chasing a laser pointer");
        }
        public override void GotoVet()
        {
            Console.WriteLine(Name + " is going to the vet");
        }

        public void Purr()
        {
            Console.WriteLine(Name + " is purring");
        }
        public void Scratch()
        {
            Console.WriteLine(Name + " IS SCRATCHING THE COUCH!");
        }
    }
    // Class: Dog
    // Author: Robert Gregory Disbrow
    // Purpose: The Dog class has a variable, constructor, and methods that setup the format for all Dog object. It also is a child class of Pet and implements the
    //          IDog interface
    // Restrictions: None
    public class Dog : Pet, IDog
    {
        public string license;

        public Dog(string szLicense, string szName, int nAge) : base(szName, nAge)
        {
            this.license = szLicense;
        }

        public override void Eat()
        {
            Console.WriteLine(Name + " is eating a raw steak");
        }
        public override void Play()
        {
            Console.WriteLine(Name + " is chasing a frisbee");
        }
        public override void GotoVet()
        {
            Console.WriteLine(Name + " is going to the vet");
        }

        public void Bark()
        {
            Console.WriteLine(Name + " is barking loudly at the neighbor's cat");
        }
        public void NeedWalk()
        {
            Console.WriteLine(Name + " is whimpering near the door (they probably need a walk)");
        }
    }

    // Class: Pets
    // Author: Robert Gregory Disbrow
    // Purpose: The pets class holds the list of pets that will be used thoroughly throughout the program, and it sets up/has methods to: get the pet at the given
    //          index, the count of the list, add a pet to the list, remove a pet from the list, and remove a pet at a certain index of the list
    // Restrictions: None
    public class Pets
    {
        List<Pet> petList = new List<Pet>();

        public Pet this[int nPetEl]
        {
            get
            {
                Pet returnVal;
                try
                {
                    returnVal = (Pet)petList[nPetEl];
                }
                catch
                {
                    returnVal = null;
                }

                return (returnVal);
            }

            set
            {
                // if the index is less than the number of list elements
                if (nPetEl < petList.Count)
                {
                    // update the existing value at that index
                    petList[nPetEl] = value;
                }
                else
                {
                    // add the value to the list
                    petList.Add(value);
                }
            }
        }
        public int Count
        {
            get
            {
                return petList.Count;
            }
        }
        public void Add(Pet pet)
        {
            petList.Add(pet);
        }
        public void Remove(Pet pet)
        {
            petList.Remove(pet);
        }
        public void RemoveAt(int petEI)
        {
            petList.RemoveAt(petEI);
        }
    }

    // Class: Program
    // Author: Robert Gregory Disbrow
    // Purpose: The program class is where the actual program is performed (where the class objects are made and how the methods of the Car are Dog are called)
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: The main is the meat of where the program is performed, meaning the class objects are defined, a for loop is made to increment 50 times which
        //          either adds a new pet to the pet list or makes one of those pets perform one of their methods, and a random number generator is made for use
        //          within all of the sections that require a random number 
        // Restrictions: None
        static void Main(string[] args)
        {
            Pet thisPet = null;
            Dog dog = null;
            Cat cat = null;
            IDog iDog = null;
            ICat iCat = null;

            Pets pets = new Pets();

            Random rand = new Random();

            for(int i = 0; i < 50; i++)
            {
                // 1 in 10 chance of adding an animal
                if (rand.Next(1, 11) == 1)
                {
                    if (rand.Next(0, 2) == 0)
                    {
                        string license;
                        string name;
                        int age;

                        Console.Write("You Bought a dog!\nPlease type your new dog's license: ");
                        license = Console.ReadLine();
                        Console.Write("Please type your new dog's name: ");
                        name = Console.ReadLine();
                        Console.Write("Please type your new dog's age: ");
                        age = Int32.Parse(Console.ReadLine());

                        dog = new Dog(license, name, age);
                        dog.Name = name;
                        pets.Add(dog);
                    }
                    else
                    {
                        string name;
                        int age;

                        Console.Write("You bought a cat!\nPlease type your new cat's name: ");
                        name = Console.ReadLine();
                        Console.Write("Please type your new cat's age: ");
                        age = Int32.Parse(Console.ReadLine());

                        cat = new Cat();
                        cat.Name = name;
                        cat.age = age;
                        pets.Add(cat);
                    }
                }
                else
                {
                    thisPet = pets[rand.Next(0, pets.Count)];

                    if(thisPet == null)
                    {
                        continue;
                    }
                    else
                    {
                        int randomNumDog = rand.Next(0, 5);
                        int randomNumCat = rand.Next(0, 4);

                        //Console.WriteLine(thisPet.GetType().ToString());

                        if ((thisPet.GetType().ToString()).Equals("PetApp.Dog"))
                        {
                            iDog = (IDog)thisPet;

                            if(randomNumDog == 0)
                            {
                                iDog.Eat();
                            }
                            if (randomNumDog == 1)
                            {
                                iDog.Play();
                            }
                            if (randomNumDog == 2)
                            {
                                iDog.Bark();
                            }
                            if (randomNumDog == 3)
                            {
                                iDog.NeedWalk();
                            }
                            if (randomNumDog == 4)
                            {
                                iDog.GotoVet();
                            }
                        }
                        else if ((thisPet.GetType().ToString()).Equals("PetApp.Cat"))
                        {
                            iCat = (ICat)thisPet;

                            if (randomNumCat == 0)
                            {
                                iCat.Eat();
                            }
                            if (randomNumCat == 1)
                            {
                                iCat.Play();
                            }
                            if (randomNumCat == 2)
                            {
                                iCat.Scratch();
                            }
                            if (randomNumCat == 3)
                            {
                                iCat.Purr();
                            }
                        }
                    }
                }
            }
        }
    }
}