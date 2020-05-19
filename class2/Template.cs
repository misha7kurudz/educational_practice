using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace class2
{
    class Cars<T> where T : Car   
    {
        public List<T>  cars = new List<T>();
        public string filename { get; set; }
        public void Print()
        {
            foreach (var car in cars)
            {
                car.Print();
            }
        }

        public void Sort()
        {
            try
            {
                string sortBy = Console.ReadLine();
                cars = cars.OrderBy(r => r.GetType().GetProperty(sortBy).GetValue(r, null)).ToList();
                Print();
            }
            catch (Exception e)
            {
                Console.WriteLine("Enter existing field!");
            }
        }

        public string Read()
        {
            Console.WriteLine("Enter name: ");
            string s1 = Console.ReadLine();
            Console.WriteLine("Enter age: ");
            string s2 = Console.ReadLine();
            Console.WriteLine("Enter price: ");
            string s3 = Console.ReadLine();
            Console.WriteLine("Enter color: ");
            string s4 = Console.ReadLine();
            Console.WriteLine("Enter horse power: ");
            string s5 = Console.ReadLine();
            string full_line = s1 + " " + s2 + " " + s3 + " " + s4 + " " + s5;

            return full_line;
        }

        public void AddElement(T car)
        {
            List<string> strings = new List<string>();
            var appRoot = Directory.GetCurrentDirectory();
            var fullPath = Path.Combine(appRoot, filename);
            strings.AddRange(File.ReadAllLines(fullPath));

            if (car == null)
            {
                Console.WriteLine("Data is incorrect.");
                return;
            }

            string full_line = car.Name + " " + car.Age + " " + car.Price + " " + car.Color + " " + car.HorsePower;
            strings.Add(full_line);
            string[] stringsArray = strings.ToArray();
            File.WriteAllLines(fullPath, stringsArray);
            cars.Add(car);
        }

        public void SaveEditedElement(T car)
        {
            if (car == null)
            {
                Console.WriteLine("Data is incorrect.");
                return;
            }

            string newText = car.Name + " " + car.Age + " " + car.Price + " " + car.Color + " " + car.HorsePower;

             Console.WriteLine("Enter an index of line to edit: ");
             int indexLine = Convert.ToInt32(Console.ReadLine());
             var appRoot = Directory.GetCurrentDirectory();
             var fullPath = Path.Combine(appRoot, filename);
             string[] arrLine = File.ReadAllLines(fullPath);
             arrLine[indexLine - 1] = newText;
             File.WriteAllLines(fullPath, arrLine);
             cars[indexLine - 1] = car;
             Console.WriteLine("Edit completed.");
        }

        public void DeleteElement()
        {
            Console.WriteLine("Enter an index of line to delete: ");
            int index = int.Parse(Console.ReadLine());
            var temp = cars[index];
            cars.Remove(temp);
            var appRoot = Directory.GetCurrentDirectory();
            var fullPath = Path.Combine(appRoot, filename);
            string[] temp_array = new string[cars.Count];
            for (var i = 0; i < cars.Count; i++)
                temp_array[i] = cars[i].ToString();
            File.WriteAllLines(fullPath, temp_array);
            Console.WriteLine("Line successfully deleted!");
        }

        public void SearchElement()
        {
            string key = Console.ReadLine();
            foreach (var car in cars)
            {
                if (car.ToString().ToLower().Contains(key.ToLower()))
                {
                    Console.WriteLine(car);
                }
            }
        }
    }
}