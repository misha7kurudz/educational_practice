using System;
using System.Diagnostics;
using System.IO;

namespace class2
{
    class Program
    {
        static Cars<Car> cars = new Cars<Car>();

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the file name: ");

            var appRoot = Directory.GetCurrentDirectory();
            while (true)
            {
                cars.filename = Console.ReadLine();
                var fullPath = Path.Combine(appRoot, cars.filename);
                if (File.Exists(fullPath))
                {
                    ReadFromFile(fullPath);
                    break;
                }
                Console.WriteLine("Data is incorrect Please recheck the data...");
            }
            while (true)
            {
                try
                {
                    Console.WriteLine("Choose your option: ");
                    Console.WriteLine("Sort - press 1");
                    Console.WriteLine("Search - press 2");
                    Console.WriteLine("Delete - press 3");
                    Console.WriteLine("Append - press 4");
                    Console.WriteLine("Edit - press 5");
                    Console.WriteLine("Print - press 6");
                    Console.WriteLine("Exit -  press 7");
                    int menu = Convert.ToInt32(Console.ReadLine());

                    switch (menu)
                    {
                        case 1:
                            Console.WriteLine("Enter the name of field to sort: ");
                            cars.Sort();
                            break;
                        case 2:
                            Console.WriteLine("Enter the key to search: ");
                            cars.SearchElement();
                            break;
                        case 3:
                            cars.DeleteElement();
                            break;
                        case 4:
                            var note = Car.ReadCar();
                            cars.AddElement(note);
                            break;
                        case 5:
                            var editedCar = Car.EditElement();
                            cars.SaveEditedElement(editedCar);
                            break;
                        case 6:
                            Console.WriteLine("The array is: ");
                            cars.Print();
                            break;
                        case 7:
                            Process.GetCurrentProcess().Kill();
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid data");
                    Console.ReadKey();
                }
            }
        }

        static void ReadFromFile(string fullPath)
        {
            using (StreamReader file = new StreamReader(fullPath))
            {
                string ln;
                while ((ln = file.ReadLine()) != null)
                {
                    if (Car.ValidateElem(ln))
                    {
                        var car = new Car(ln);
                        cars.cars.Add(car);
                    }
                }
                file.Close();
            }
        }
    }
}