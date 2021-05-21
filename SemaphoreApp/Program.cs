using System;
using System.Threading;

namespace SemaphoreApp
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 10; i++)
            {
                Reader reader = new Reader(i);
            }

            Console.ReadLine();
        }
    }

    class Reader
    {
        // создаем семафор
        static Semaphore sem = new Semaphore(2, 2);
        Thread myThread;

        public Reader(int i)
        {
            myThread = new Thread(Read);
            myThread.Name = $"Философ {i}";
            myThread.Start();
        }

        public void Read()
        {
            sem.WaitOne();

            Console.WriteLine($"{Thread.CurrentThread.Name} начал обедать");
            Random rand = new Random();
            Thread.Sleep(rand.Next(1000, 2000));

            Console.WriteLine($"{Thread.CurrentThread.Name} закончил обедать");

            sem.Release();

        }
    }
}