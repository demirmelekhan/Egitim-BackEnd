using System;

namespace ikililer_toplam_kare
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kaç sayı çifti oluşturmak istediğinizi bir rakamla girin: ");
            int n =Convert.ToInt32(Console.ReadLine());
            int[] sayilar = new int[2*n];


            for (int i = 0; i < 2*n; i++)
            {
                Console.WriteLine($"{i+1}. sayıyı girin: ");
                sayilar[i]= Convert.ToInt32(Console.ReadLine());
            }
            for (int i = 0; i < 2*n; i+=2)
            {   
                int a = sayilar[i];
                int b=sayilar[i+1];
                int toplam=a+b;
                
                if(a==b)
                    Console.WriteLine(toplam*toplam);
                else
                    Console.WriteLine(toplam);
            }

        }
    }
}