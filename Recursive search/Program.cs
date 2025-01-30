using System;
using System.IO;

//variables artifacts of execution
//string PrefetchPath = @"C:\Windows\Prefetch";
//string LNKPath1 = @"C:\ProgramData\Microsoft\Windows\Start Menu";
//string LNKPath2 = @"C:\Users\creep\AppData\Roaming\Microsoft\Windows\Start Menu";
//string SRUMPath = @"C:\Windows\System32\sru";

Console.WriteLine("Please Enter a Volume to search: ");
string Volume = Console.ReadLine();

if (Directory.Exists(Volume))
{
    Console.WriteLine("Searching files...");
    SearchFiles(Volume);
}
else
{
    Console.WriteLine("The directory does not exist.");
}

void SearchFiles(string directory)
{
    try
    {
        // List all files in the current directory
        string[] Link = Directory.GetFiles(directory, "*.lnk");
        foreach (string file1 in Link)
        {
            Console.WriteLine($"File: {file1}");
        }
        string[] Prefetch = Directory.GetFiles(directory, "*.pf");
        foreach (string file2 in Prefetch)
        {
            Console.WriteLine($"File: {file2}");
        }
        string[] SRUM = Directory.GetFiles(directory, "*sru");
        foreach (string file3 in SRUM)
        {
            Console.WriteLine($"File: {file3}");
        }

        // Recursively search in subdirectories
        string[] subDirectories = Directory.GetDirectories(directory);
        foreach (string subDirectory in subDirectories)
        {
            SearchFiles(subDirectory);
        }
    }
    catch (UnauthorizedAccessException e)
    {
        Console.WriteLine($"Access denied: {e.Message}");
    }
    catch (Exception e)
    {
        Console.WriteLine($"Error: {e.Message}");
    }

}


Console.WriteLine("Search completed. Press any key to exit.");
Console.ReadKey();
