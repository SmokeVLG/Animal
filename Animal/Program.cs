using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Animals
{
    class Program
    {
        public static void MyAnimals_AnimalRemoved(MyAnimalList collection, Animal anim)
        {
            string sAnimalType = anim.AnimalType.ToString();
            string sAnimalName = anim.AnimalName;

            MessageBox.Show("A " + sAnimalName + " was removed from the list", 
                            sAnimalType + " Removed");
        }

        static void Main(string[] args)
        {
            MyAnimalList MyAnimals = new MyAnimalList();
            //Add the following Animal objects to MyAnimals using the Add() method:
            MyAnimals.Add(new Animal(AnimalType.Amphibian, "Frog"));
            MyAnimals.Add(new Animal(AnimalType.Bird, "Eagle"));
            MyAnimals.Add(new Animal(AnimalType.Fish, "Bass"));
            //Add the following Animal objects to MyAnimals using the overridden + operator:
            MyAnimals += new Animal(AnimalType.Invertebrate, "Worm");
            Animal lionAnimal = new Animal(AnimalType.Mammal, "Lion");
            MyAnimals += (lionAnimal);
            MyAnimals += new Animal(AnimalType.Reptile, "Snake");
            //If you try and Add() any object other than an Animal:
            MyAnimals.Add("Dog");
            MyAnimals.m_animalDeleteHandler += MyAnimals_AnimalRemoved;
            Object obj = new Object();
            MyAnimals.Remove(obj);
            MyAnimals.Remove(lionAnimal);
            MyAnimals.RemoveAt(3);
            MyAnimals.RemoveRange(1, 2);
            MyAnimals.RemoveAt(5);

            foreach (Animal animal in MyAnimals)
            {
                MessageBox.Show("You still have a " + animal.AnimalName + " (" + animal.AnimalType + ")", 
                                "CS559 - Assignment 2", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
