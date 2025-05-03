using System;

namespace input_reverse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Bir cümle girin: ");
            string input = Console.ReadLine();
            char[] karakterler =input.ToCharArray();
            Array.Reverse(karakterler);
            string ters = new string(karakterler);

            Console.WriteLine(ters);
        }
    }
}