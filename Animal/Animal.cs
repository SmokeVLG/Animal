using System.Collections;

namespace Animals
{
    internal class Animal
    {
        private string animalName;
        private AnimalType animalType;
    
        public string AnimalName
        {
            get { return animalName; }
            set { animalName = value; }
        }
        
        public AnimalType AnimalType
        {
            get { return animalType; }
            set { animalType = value; }
        }

        public Animal(AnimalType animalType, string animalName)
        {
            this.animalName = animalName;
            this.AnimalType = animalType;
        }
    }
}