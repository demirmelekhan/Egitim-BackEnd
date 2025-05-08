using System;

namespace toplam_mutlak_kare
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("kaç sayı gireneceğinizi belirtin: ");
            int n = Convert.ToInt32(Console.ReadLine());
            
            int [] sayilar=new int[n];
            int kucukToplam=0;
            int buyukToplam=0;
            for (int i = 0; i < n; i++)
            {
                
                sayilar[i]=Convert.ToInt32(Console.ReadLine());

                if(sayilar[i] <67)
                {
                    kucukToplam+= Math.Abs(67-sayilar[i]);

                }
                else if(sayilar[i] >67)
                {
                    buyukToplam+= Convert.ToInt32(Math.Pow(Math.Abs(67-sayilar[i]),2));

                }
                else
                    Console.WriteLine("Üzgünüm algoritma tanımlama dışında 67 sayısıyla ne yapılacağı belirtilmedi");
                }
                Console.WriteLine($"Küçüklerin fark toplamı: {kucukToplam}");
                Console.WriteLine($"Büyüklerin mutlak kare toplamı: {buyukToplam}");

            
        }
    }
}