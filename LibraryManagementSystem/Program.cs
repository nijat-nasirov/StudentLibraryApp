// See https://aka.ms/new-console-template for more information
using LibraryManagementSystem.Entities;

Console.Write("Enter the maximum number of students: ");
int maxStudents = int.Parse(Console.ReadLine());

Console.Write("Enter the maximum number of readers allowed at the same time: ");
int maxReaders = int.Parse(Console.ReadLine());

Console.Write("Enter the minimum number of readers required at the same time: ");
int minReaders = int.Parse(Console.ReadLine());

if (minReaders > maxReaders)
{
    Console.WriteLine("Minimum number of readers cannot be greater than maximum readers. Exiting...");
    return;
}

Library library = new Library(maxReaders, minReaders);
library.StartLibraryOperations(maxStudents);

Console.WriteLine("Library operations started...");
Console.ReadLine(); // Prevent program from closing immediately
