using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Entities
{
    public class Student
    {
        public int Id { get; }
        public int ReadingTime { get; }
        public DateTime EntryTime { get; private set; }

        public Student(int id, int readingTime)
        {
            Id = id;
            ReadingTime = readingTime;
        }

        public void EnterLibrary()
        {
            EntryTime = DateTime.UtcNow;
            Console.WriteLine($"Student {Id} entered library at {EntryTime}. Reading time =  {ReadingTime} seconds.");
        }

        public void LeftLibrary()
        {
            var exitTime = DateTime.UtcNow;
            Console.WriteLine($"No:{Id} has left library at {exitTime}. Stayed time interval = {(exitTime - EntryTime).TotalSeconds} seconds.");
        }
    }
}
