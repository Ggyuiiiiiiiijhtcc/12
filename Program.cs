using System;
using System.Collections.Generic;


abstract class Device
{
    public string Manufacturer { get; set; }   
    public string Model { get; set; }          
    public int Quantity { get; set; }          
    public double Price { get; set; }          
    public string Color { get; set; }          

    public abstract void PrintInfo();
}


class MobilePhone : Device
{
    public string OperatingSystem { get; set; }  

    
    public override void PrintInfo()
    {
        Console.WriteLine("Мобильный телефон:");
        Console.WriteLine($"Производитель: {Manufacturer}");
        Console.WriteLine($"Модель: {Model}");
        Console.WriteLine($"Количество: {Quantity}");
        Console.WriteLine($"Цена: {Price}");
        Console.WriteLine($"Цвет: {Color}");
        Console.WriteLine($"Операционная система: {OperatingSystem}");
    }
}


class Laptop : Device
{
    public int Ram { get; set; }       
    public int DiskSize { get; set; }  

    
    public override void PrintInfo()
    {
        Console.WriteLine("Ноутбук:");
        Console.WriteLine($"Производитель: {Manufacturer}");
        Console.WriteLine($"Модель: {Model}");
        Console.WriteLine($"Количество: {Quantity}");
        Console.WriteLine($"Цена: {Price}");
        Console.WriteLine($"Цвет: {Color}");
        Console.WriteLine($"Объем оперативной памяти: {Ram} ГБ");
        Console.WriteLine($"Объем жесткого диска: {DiskSize} ГБ");
    }
}


class Tablet : Device
{
    public string DisplayType { get; set; }   
    public double DisplaySize { get; set; }   

    
    public override void PrintInfo()
    {
        Console.WriteLine("Планшет:");
        Console.WriteLine($"Производитель: {Manufacturer}");
        Console.WriteLine($"Модель: {Model}");
        Console.WriteLine($"Количество: {Quantity}");
        Console.WriteLine($"Цена: {Price}");
        Console.WriteLine($"Цвет: {Color}");
        Console.WriteLine($"Тип дисплея: {DisplayType}");
        Console.WriteLine($"Размер дисплея: {DisplaySize} дюймов");
    }
}
class Program
{
    static List<Device> devices = new List<Device>(); 

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Добавить устройство");
            Console.WriteLine("2. Найти устройство");
            Console.WriteLine("3. Вывести список устройств");
            Console.WriteLine("4. Выход");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddDevice();
                    break;
                case 2:
                    FindDevice();
                    break;
                case 3:
                    PrintDevices();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте еще раз.");
                    break;
            }

            Console.WriteLine();
        }
    }

    
    static void AddDevice()
    {
        Console.WriteLine("Выберите тип устройства:");
        Console.WriteLine("1. Мобильный телефон");
        Console.WriteLine("2. Ноутбук");
        Console.WriteLine("3. Планшет");

        int choice = int.Parse(Console.ReadLine());

        Device device = null;

        switch (choice)
        {
            case 1:
                device = new MobilePhone();
                break;
            case 2:
                device = new Laptop();
                break;
            case 3:
                device = new Tablet();
                break;
            default:
                Console.WriteLine("Неверный выбор. Попробуйте еще раз.");
                return;
        }

        Console.Write("Введите наименование производителя: ");
        device.Manufacturer = Console.ReadLine();

        Console.Write("Введите модель: ");
        device.Model = Console.ReadLine();

        Console.Write("Введите количество: ");
        device.Quantity = int.Parse(Console.ReadLine());

        Console.Write("Введите цену: ");
        device.Price = decimal.Parse(Console.ReadLine());

        Console.Write("Введите цвет: ");
        device.Color = Console.ReadLine();

       
        devices.Add(device);

        Console.WriteLine("Устройство успешно добавлено!");
    }
    static void FindDevice()
    {
        Console.WriteLine("Введите критерии поиска:");
        Console.WriteLine("Производитель:");
        string manufacturer = Console.ReadLine();
        Console.WriteLine("Модель:");
        string model = Console.ReadLine();
        Console.WriteLine("Цвет:");
        string color = Console.ReadLine();
        bool found = false;
        foreach (Device device in devices)
        {
            if (device.Manufacturer == manufacturer && device.Model == model && device.Color == color)
            {
                Console.WriteLine("Найдено устройство:");
                device.PrintInfo();
                found = true;
                break;
            }
        }

        if (!found)
        {
            Console.WriteLine("Устройство не найдено");
        }
    }
