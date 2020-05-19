using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace class2
{
    class Car
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Price { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }

        public Car(string name, int age, int price, string color, int horsePower)
        {
            this.Name = name;
            this.Age = age;
            this.Price = price;
            this.Color = color;
            this.HorsePower = horsePower;
        }

        public Car(string ln)
        {
            var line1 = ln.Split();
            this.Name = line1[0].ToString();
            this.Age = Convert.ToInt32(line1[1].ToString());
            this.Price = Convert.ToInt32(line1[2].ToString());
            this.Color = Convert.ToString(line1[3]);
            this.HorsePower = Convert.ToInt32(Convert.ToString(line1[4]));
        }

        public void Print()
        {
            Console.WriteLine("car name: {0}, car age: {1}, car price: {2}, car color: {3}, horse power: {4}" ,Name,Age,Price,Color,HorsePower);
        }

        public override string ToString() => $"{Name} {Age} {Price} {Color} {HorsePower}";

        public static Car ReadCar()
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
            Car car = null;

            if (ValidateElem(full_line))
            {
                car = new Car(full_line);
            }

            return car;
        }

        public static Car EditElement()
        {
            Console.WriteLine("Enter new string text: ");
            string newText = Console.ReadLine();
            Car car = null;

            if (ValidateElem(newText))
                car = new Car(newText);

            return car;
        }

        public static bool ValidateElem(string line)
        {
            string[] line1 = line.Split();

            if (!validString(line1[0]) || !validDigit(line1[1]) || !validAge(line1[1]) || !validDigit(line1[2]) ||
                !validString(line1[3]) || !validDigit(line1[4]))
            {
                return false;
            }
            else
                return true;
        }

        public static bool validString(string word)
        {
            foreach (char c in word)
                if (Char.IsNumber(c) || Char.IsSymbol(c))
                {
                    return false;
                }
            return true;
        }
        public static bool validDigit(string number)
        {
            foreach (char c in number)
                if (Char.IsLetter(c) || Char.IsSymbol(c))
                {
                    return false;
                }
            if (Convert.ToInt32(number) < 0)
            { 
                return false;
            }
            return true;
        }
        public static bool validAge(string number)
        {
            foreach (char c in number)
                if (Convert.ToInt32(number) > 2020 || Convert.ToInt32(number) < 1970)
                {
                    return false;
                }
            return true;
        }
        
    }
}