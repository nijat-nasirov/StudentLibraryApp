using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Entities
{
    public class Library
    {
        private Semaphore _semaphore;
        private int _minReaders;
        private int _maxReaders;
        private List<Student> _studentsInLibrary = new List<Student>();
        private static readonly object _lock = new object();

        public Library(int maxReaders, int minReaders)
        {
            _maxReaders = maxReaders;
            _minReaders = minReaders;
            _semaphore = new Semaphore(0, _maxReaders);
        }

        public void Enter(Student student)
        {
            _semaphore.WaitOne();
            lock (_lock)
            {
                _studentsInLibrary.Add(student);
                student.EnterLibrary();
            }
        }

        public void Leave(Student student)
        {
            lock (_lock)
            {
                student.LeftLibrary();
                _studentsInLibrary.Remove(student);
            }
            _semaphore.Release();
        }

        public void StartLibraryOperations(int totalStudents)
        {
            Random random = new Random();

            // Release initial min readers
            for (int i = 0; i < _minReaders; i++)
            {
                _semaphore.Release();
            }

            for (int i = 1; i <= totalStudents; i++)
            {
                int readingTime = random.Next(5, 61); 
                Student student = new Student(i, readingTime);

                new Thread(() =>
                {
                    Enter(student);
                    Thread.Sleep(student.ReadingTime * 1000); 
                    Leave(student);
                }).Start();

                Thread.Sleep(random.Next(500, 2000)); 
            }
        }
    }
}
