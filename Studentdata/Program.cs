using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "C:\\Mphasis dot net\\Day 11\\Studentdata\\students.txt"; 
        
        if (File.Exists(filePath))
        {
            string schoolName = "";
            bool isHeaderLine = true;
            using (StreamReader reader = new StreamReader(filePath))
            {
                schoolName = reader.ReadLine();
                Console.WriteLine($"School Name: {schoolName}");
                Console.WriteLine("Name\tAge\tDept\tGrade");
                Console.WriteLine("---------------------------------------");
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (isHeaderLine)
                    {
                        isHeaderLine = false;
                        continue; // Skip processing the header line
                    }


                    string[] values = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);


                    if (values.Length == 4)
                    {
                        string name = values[0];
                        int age = int.Parse(values[1]);
                        string department = values[2];
                        double grade = double.Parse(values[3]);


                        Console.WriteLine($"{name,-6}\t{age,-3}\t{department,-4}\t{grade,-5}");
                    }
                    else
                    {
                        
                        Console.WriteLine("Invalid data format in the file.");
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("File not found.");
        }
        Console.ReadKey();
    }
}

