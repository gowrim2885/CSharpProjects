using System;
using System.Threading.Tasks;

namespace Labs
{
    public  class StudentThread
    {
        public static void Main()
        {
            Console.WriteLine("Main Thread Start");
            MultipleThreadSample();
            Console.WriteLine("Main thread End"); 
        }

        public static void SingleThread()
        {
            LoadStudents();
            GenerateStudent();
            SendEmail();
        }

        public static void MultipleThreadSample()
        {
            //create the thread for each task
            Thread T1 = new Thread(LoadStudents);
            Thread T2 = new Thread(GenerateStudent);
            Thread T3 = new Thread(SendEmail);

            T1.Start();
            T2.Start();
            T3.Start();
             
            // Join Method is Wait untill the thread finsh the task
            T1.Join();
            T2.Join();
            T3.Join();
        }

        public static void LoadStudents()
        {
            Console.WriteLine("Start Loading Student Information...");
            Thread.Sleep(3000);
            Console.WriteLine("End Loading Student Information...");
        }
        public static void GenerateStudent()
        {
            Console.WriteLine("Start Generate Student Reports...");
            Thread.Sleep(3000);
            Console.WriteLine("End Generate Student Reports...");
        }
        public static void SendEmail()
        {
            Console.WriteLine("Start Send Mail to Student...");
            Thread.Sleep(3000);
            Console.WriteLine("End Send Mail to Student...");
        }
    }
}
