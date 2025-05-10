using System;

namespace character_change
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bir giriş yapın: ");
            string input = Console.ReadLine();

            string [] kelimeler = input.Split(' ');

            foreach (string kelime in kelimeler)
            {
                string yeniKelime= "";

                if (kelime.Length <= 1)
                {
                    yeniKelime = kelime;
                }
                else
                {
                    char ilk =kelime[0];
                    char son =kelime[kelime.Length -1];
                    string orta =kelime.Substring(1, kelime.Length - 2);

                    yeniKelime = son + orta + ilk; 
                }
                Console.WriteLine(yeniKelime + " "); 
            }
            Console.WriteLine(); //alt satıra geçmek için
        }
    }
}