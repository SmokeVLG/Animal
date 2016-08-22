using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Animals
{
    internal class MyAnimalList : IEnumerable
    {
        public delegate void AnimalDeleteHandler(MyAnimalList collection, Animal item);

        private static List<Animal> m_animals = new List<Animal>();
        public event AnimalDeleteHandler m_animalDeleteHandler;
        
        public void Add(object anyObject)
        {
            Animal curAnimal = anyObject as Animal;
            if (curAnimal != null)
            {
                m_animals.Add(curAnimal);
            }
            else
            {
                MessageBox.Show("Only animal type objects can be added to the MyAnimalListCollection", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static MyAnimalList operator +(MyAnimalList animalList, Animal newAnimal)
        {
            animalList.Add(newAnimal);
            return animalList;
        }

        public void Remove(object animal)
        {
            Animal anim = animal as Animal;
            if (anim == null)
            {
                MessageBox.Show("Only animal type objects can be removed", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            bool isRemove = m_animals.Remove(anim);
            
            if (isRemove)
            {
                if(m_animalDeleteHandler != null)
                    m_animalDeleteHandler(this, anim);
            }
            else
            {
                string sAnimalType = anim.AnimalType.ToString();
                string sAnimalName = anim.AnimalName;
                MessageBox.Show("A " + sAnimalName + " not exists", sAnimalType + " Removed");
            }

        }

        public void RemoveAt(int i)
        {
            try
            {
                Animal curAnimal = m_animals[i];
                Remove(curAnimal);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show(i + " is not a valid index", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RemoveRange(int index, int count)
        {
            try
            {
                List<Animal> delAnimals = m_animals.GetRange(index, count);
                foreach (Animal animal in delAnimals)
                {
                    Remove(animal);
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                MessageBox.Show(e.Message, "Error");
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return m_animals.GetEnumerator();
        }
    }
}