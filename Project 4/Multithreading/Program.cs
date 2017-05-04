using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Multithreading
{
    class Program
    {
        struct bankAccount
        {
           public double balance;
           public int accountNum;
        };
        static Mutex mutex = new Mutex();
        static Random rand = new Random();
        static bankAccount acc = new bankAccount();
        static void Main(string[] args)
        {
            acc.balance = 1000;
            acc.accountNum = 12345678;
            int numThread = 10;
            createThread(numThread);
            Console.ReadLine();
        }
        static void deposit()
        {
            double amount = Math.Round(rand.NextDouble()*500);
            mutex.WaitOne();
            Console.WriteLine("$" + amount + " has been added to the " + acc.accountNum + " account");
            acc.balance += amount;
            Console.WriteLine("The current balance is " + acc.balance);
            mutex.ReleaseMutex();
        }
        static void withdraw()
        {
            double amount = Math.Round(rand.NextDouble() * 500);
           mutex.WaitOne();
            if(amount <= acc.balance)
            {
                Console.WriteLine("$" + amount + " has been withdrawn from the " + acc.accountNum + " account");
                acc.balance -= amount;
                Console.WriteLine("The current balance is " + acc.balance);
            }
            mutex.ReleaseMutex();
        }
        static void createThread(int numThread)
        {
            Thread thread;
            for(int i=0; i<numThread; i++)
            {
                if(i%2==0)
                 thread = new Thread(deposit);
                else
                 thread = new Thread(withdraw);
                thread.Start();
            }
        }


    }
}
