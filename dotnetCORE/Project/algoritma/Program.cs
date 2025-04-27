using System;

namespace algoritma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bir kelime girin virgülden sonra da bir sayı:");
            string input = Console.ReadLine();
            string [] kelimeler= input.Split(',');
            string newinput=kelimeler[0].Remove(Convert.ToInt32(kelimeler[1]),1);
            Console.WriteLine("Yeni çıktı: "+ newinput);

        }
    }
}