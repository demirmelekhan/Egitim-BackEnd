using System;
using System.Collections.Generic;

namespace fibonacci_ort_hesaplama
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Fibonacci serisinin kaç elemanının ortalamasını istediğinizi yazın: ");
            int rakam = Convert.ToInt32(Console.ReadLine());

            double ortalama = FibonacciOrt(rakam);
            Console.WriteLine($"Ortalaması: {ortalama}");
            
        }

        public static double FibonacciOrt(int deger)
        {
            if(deger<=0) return 0;

            int first=1;
            int second=1;
            int toplam= first + second;

            for (int i = 3; i <= deger ; i++)
            {
                int twin=first + second;
                toplam +=twin;
                first=second;
                second=twin;
                
            }
            return (double)toplam/deger;
        }
    }
}
