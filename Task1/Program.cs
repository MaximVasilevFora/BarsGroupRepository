using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarsGroupHomework1
{
    internal class Program
    {
        public class WorkerEventArgs : EventArgs
        {
            public char value { get; }

            public WorkerEventArgs(char someValue)
            {
                value = someValue;
            }
        }
        public class SomeClassWorker
        {
            public event EventHandler<char> OnKeyPresed;

            public void Run()
            {
                Console.WriteLine("Вводите символы с клавиатуры. P.s если вы хотите выйти нажмите клавишу 'c'...");
                bool exitPressed = true;
                while (exitPressed)
                {
                    char value = Convert.ToChar(Console.ReadLine());
                    if ((int)value == 67 || value == 'C')
                    {
                        exitPressed = false;
                        return;
                    }else if ((int)value == 99 || value == 'c')
                    {
                        exitPressed = false;
                        return;
                    }
                    OnKeyPresed?.Invoke(this, value);
                }
            }
        }

        public class SomeClassSubscriber
        {
            public void FuncListener()
            { 
                var worker = new SomeClassWorker();
                worker.OnKeyPresed += test;
                worker.Run();
            }

            private void test(object sender, char e)
            {
                Console.WriteLine(e);
            }

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Привет мир!");
            SomeClassSubscriber someClassSubscriber = new SomeClassSubscriber();
            someClassSubscriber.FuncListener();
            Console.ReadKey();
        }
    }
}
