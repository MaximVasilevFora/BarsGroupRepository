using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarsGroupHW2
{
    internal class Program
    {
        interface ILogger
        {
            void LogInfo(string message);
            void LogWarning(string message);
            void LogError(string message, Exception ex);

        }

        class LocalFileLogger<t> : ILogger
        {
            private string ReadWay;
            public LocalFileLogger(string ReadWay)
            { 
                this.ReadWay = ReadWay;
                Console.WriteLine("Экземпляр класса успешно создан!");
            }

            public void LogInfo(string message)
            {
                Console.WriteLine($"[Info]:[{typeof(t).Name}]:{message}");
            }

            public void LogWarning(string message)
            {
                Console.WriteLine($"[Warning]:[{typeof(t).Name}]:{message}");
            }

            public void LogError(string message, Exception ex)
            {
                Console.WriteLine($"[Error]:[{typeof(t).Name}]:{message}.{ex.Message}");
            }
        }
        static void Main(string[] args)
        {
            var local = new LocalFileLogger<string>("D:\\Maxima\\Myproject");
            local.LogInfo("Info");
            local.LogWarning("Warning");
            Exception ex = new Exception();
            local.LogError("Error", ex);

            var local1 = new LocalFileLogger<int>("D:\\Maxima\\Myproject");
            local1.LogInfo("Info");
            local1.LogWarning("Warning");
            DivideByZeroException ex1 = new DivideByZeroException();
            local1.LogError("Error", ex1);

            Console.Read();
        }
    }
}
