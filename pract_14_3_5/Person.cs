using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace pract_14_3_5
{
    class Person
    {
        private string surname;
        private string name;
        private string patronymic;
        private int age;
        private double weight;
        static private Queue<Person> people = new Queue<Person>();
        public string Surname { get { return surname; } set { surname = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Patronymic { get { return patronymic; } set { patronymic = value; } }
        public int Age
        {
            get => age;
            set
            {
                if (value > 0)
                {
                    age = value;
                }
            }
        }
        public double Weight
        {
            get => weight;
            set
            {
                if (value > 0)
                {
                    weight = value;
                }
            }
        }
        public Person(string surname, string name, string patronymic, int age, double weight)
        {
            this.surname = surname;
            this.name = name;
            this.patronymic = patronymic;
            this.age = age;
            this.weight = weight;
            people.Enqueue(this);
        }
        static public void ClearPeople()
        {
            people.Clear();
        }
        static public Queue<Person> GetPeople()
        {
            return people;
        }
        public string ToString()
        {
            return $"{surname} {name} {patronymic} {age} {weight}";
        }
        static public bool ReadFile(string filePath)
        {
            if (!File.Exists(filePath)) return false;
            string[] text = File.ReadAllLines(filePath);
            for (int i = 0; i < text.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(text[i])) continue;
                string[] data = text[i].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (data.Length == 5)
                {
                    bool ageParsed = int.TryParse(data[3], out int age);
                    bool vesParsed = double.TryParse(data[4], out double ves);
                    if (ageParsed && vesParsed && age > 0 && ves > 0)
                    {
                        Person person = new Person(data[0], data[1], data[2], age, ves);
                    }
                    else return false;
                }
                else return false;
            }
            return true;
        }
        static public bool ReadTwoFiles(string filePath1, string filePath2)
        {
            if (!File.Exists(filePath1) && !File.Exists(filePath2)) return false;
            string[] text1 = File.ReadAllLines(filePath1);
            string[] text2 = File.ReadAllLines(filePath2);
            if (text1.Length != text2.Length) return false;
            string[] text = new string[text1.Length];
            for (int i = 0; i < text.Length; i++)
            {
                text[i] = text1[i] + " " + text2[i];
            }
            for (int i = 0; i < text.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(text[i])) continue;
                string[] data = text[i].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (data.Length == 5)
                {
                    bool ageParsed = int.TryParse(data[3], out int age);
                    bool vesParsed = double.TryParse(data[4], out double ves);
                    if (ageParsed && vesParsed && age > 0 && ves > 0)
                    {
                        Person person = new Person(data[0], data[1], data[2], age, ves);
                    }
                    else return false;
                }
                else return false;
            }
            return true;
        }
    }
}
