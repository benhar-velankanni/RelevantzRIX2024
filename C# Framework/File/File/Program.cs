using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
namespace consoleApp
{
    class Program

    {
        static void Main()
        {
            // string Filepath = @"C:\L1\C# Framework\File\myfile.txt";
            // File.AppendAllText(Filepath, "Hello World");
            // File.AppendAllText(Filepath, "Hello World 1");

            String path = @"C:\L1\C# Framework\File\myfile.txt";
            if (File.Exists(path))
            {
                File.Delete(path);
                Console.WriteLine("File has been deleted");
            }
            

            // FileStream fileStream = new FileStream(Filepath, FileMode.Create);
            // FileStream fileStream1 = new FileStream(Filepath, FileMode.Append);
            // byte[] bytedata = Encoding.Default.GetBytes("Hai Mukesh!!!!");
            // fileStream.Write(bytedata, 0, bytedata.Length);
            // fileStream.Close();
            // Console.WriteLine("File has been appended");
            // StreamReader reader = new StreamReader(@"C:\L1\C# Framework\File\myfile.txt");
            // string line;
            // while ((line = reader.ReadLine()) != null)
            // {
            //     Console.WriteLine(line);
            // }
            // using (StreamWriter writer = File.AppendText(@"C:\L1\C# Framework\File\myfile.txt"))
            // {
            //     writer.WriteLine("This line is appended");
            // }

            // string path = @"C:\L1\C# Framework\File\myfile.txt";
            // if (File.Exists(path))
            // {
            //     File.Delete(path);
            //     Console.WriteLine("File has been deleted");
            // }
            // else {
            // Console.WriteLine("File does not exist");
        }
       
        }
       
    }
