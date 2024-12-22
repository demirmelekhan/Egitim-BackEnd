using System;

namespace arayuz
{
    public class DatabaseLogger : ILogger
    {
        public void WriteLog()
        {
            Console.WriteLine("Databse'e yazar.");
        }
    }
}