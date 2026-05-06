using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;
using TestHomework.Models;

namespace TestDataGenerator;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 4)
        {
            Console.WriteLine("Укажите параметры: <тип(e)> <количество> <имя_файла.xml> <формат(xml)>");
            return;
        }

        string type = args[0]; 
        int count = Convert.ToInt32(args[1]);
        string filename = args[2];
        string format = args[3];

        if (type == "e")
        {
            GenerateForEmployees(count, filename, format);
        }
        else
        {
            Console.WriteLine("Неизвестный тип сущности: " + type);
        }
    }

    static void GenerateForEmployees(int count, string filename, string format)
    {
        List<EmployeeData> employees = new List<EmployeeData>();
        Random rnd = new Random();

        for (int i = 0; i < count; i++)
        {
            employees.Add(new EmployeeData(GenerateRandomString(7), GenerateRandomString(10))
            {
                EmployeeId = "QA" + rnd.Next(1000, 9999).ToString()
            });
        }

        if (format == "xml")
        {
            WriteEmployeesToXmlFile(employees, filename);
            Console.WriteLine($"Успешно сгенерировано {count} сотрудников в файл {filename}");
        }
        else
        {
            Console.WriteLine("Неподдерживаемый формат: " + format);
        }
    }

    static void WriteEmployeesToXmlFile(List<EmployeeData> employees, string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            new XmlSerializer(typeof(List<EmployeeData>)).Serialize(writer, employees);
        }
    }

    static string GenerateRandomString(int max)
    {
        Random rnd = new Random();
        int length = rnd.Next(3, max);
        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        char[] stringChars = new char[length];
        for (int i = 0; i < length; i++)
        {
            stringChars[i] = chars[rnd.Next(chars.Length)];
        }
        return new string(stringChars);
    }
}