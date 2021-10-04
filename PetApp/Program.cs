using System;
using System.Collections.Generic;

namespace PetApp
{
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
    public class Pets
    {
        List<Pet> petList = new List<Pet>();

        public Pet petEI
        {
            get
            {

            }
            set
            {

            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}