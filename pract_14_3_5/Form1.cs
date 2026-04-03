using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace pract_14_3_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                if (int.TryParse(textBox1.Text, out int num) && num > 0)
                {
                    listBox1.Items.Clear();
                    Queue<int> list = new Queue<int>();
                    for (int i = 1; i <= num; i++)
                    {
                        list.Enqueue(i);
                    }
                    listBox1.Items.Add("Размерность очереди: " + list.Count);
                    listBox1.Items.Add("Верхний элемент очереди: " + list.Peek());
                    string result = "";
                    while (list.Count > 0)
                    {
                        result += list.Dequeue() + " ";
                    }
                    listBox1.Items.Add("Содержимое очереди: " + result);
                    listBox1.Items.Add("Новая размерность очереди: " + list.Count);
                }
                else
                {
                    MessageBox.Show("Введите целое положительное число!", "Ошибка", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Введите число!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Person.ClearPeople();
            if (File.Exists("zad_4.txt"))
            {
                if (Person.ReadFile("zad_4.txt"))
                {
                    listBox2.Items.Clear();
                    Queue<Person> people = Person.GetPeople();
                    var youngPeople = people.Where(p => p.Age < 40);
                    var oldPeople = people.Where(p => p.Age > 39);
                    listBox2.Items.Add("--- Люди моложе 40 лет ---");
                    foreach (var person in youngPeople)
                    {
                        listBox2.Items.Add(person.ToString());
                    }
                    listBox2.Items.Add("--- Люди старше 39 лет ---");
                    foreach (var person in oldPeople)
                    {
                        listBox2.Items.Add(person.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Файл невозможно прочесть!\nНеверный формат записи файла.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Файл не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Person.ClearPeople();
            if (File.Exists("zad_5_1.txt") && File.Exists("zad_5_2.txt"))
            {
                if (Person.ReadTwoFiles("zad_5_1.txt", "zad_5_2.txt"))
                {
                    listBox3.Items.Clear();
                    Queue<Person> people = Person.GetPeople();
                    var sortedPeople = people.OrderBy(p => p.Age).GroupBy(p => char.ToUpper(p.Surname[0]));
                    foreach (var group in sortedPeople)
                    {
                        listBox3.Items.Add($"--- Буква: {group.Key} ---");
                        foreach (var person in group)
                        {
                            listBox3.Items.Add(person.ToString());
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Файл невозможно прочесть!\nНеверный формат записи файла.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Файл не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
