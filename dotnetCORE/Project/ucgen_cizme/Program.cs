using System;

namespace ucgen_cizme
{
    class Program
    {
        public static void Main(string[] args)
        {
            CizUcgen();
        }

        public static void CizUcgen()
        {
            Console.WriteLine("Üçgenin boyutunu girin: ");
            if (int.TryParse(Console.ReadLine(), out int boyut) && boyut > 0)
            {
                for (int i = 1; i <= boyut; i++)
                {
                    // Boşlukları yazdır
                    for (int j = 0; j < boyut - i; j++)
                    {
                        Console.Write(" ");
                    }

                    // Yıldızları yazdır
                    for (int k = 0; k < i; k++)
                    {
                        Console.Write("* ");
                    }
                    // Yeni satıra geç
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Lütfen geçerli bir pozitif tam sayı girin.");
            }
        }
    }
}