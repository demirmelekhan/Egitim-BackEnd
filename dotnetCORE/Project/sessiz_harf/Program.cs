using System;

namespace sessiz_harf
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("String bir ifade girin: ");
            string input =Console.ReadLine();

            string [] kelimeler= input.Split(' ');

            char [] sesliHarfler = {'a', 'e', 'ı', 'i', 'o', 'ö', 'u', 'ü'};

            foreach (string kelime in kelimeler)
            {
                bool yanyanaSessizVar = false;

                for (int i = 0; i < kelime.Length -1; i++)
                {
                    char ilk=char.ToLower(kelime[i]);
                    char ikinci=char.ToLower(kelime[i+1]);

                    bool ilkSesliMi = Array.Exists(sesliHarfler, h=>h ==ilk);
                    bool ikinciSesliMi =Array.Exists(sesliHarfler, h=> h == ikinci);

                    if(!ilkSesliMi && !ikinciSesliMi && Char.IsLetter(ilk) && Char.IsLetter(ikinci))
                    {
                        yanyanaSessizVar = true;
                        break;
                    }


                }
                Console.WriteLine(yanyanaSessizVar + " ");
            }

            Console.WriteLine();


        }
    }
}