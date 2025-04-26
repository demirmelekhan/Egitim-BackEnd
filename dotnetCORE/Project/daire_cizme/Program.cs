using System;

namespace daire_cizme
{
    // Daire çizme sorumluluğunu üstlenen sınıf
    public class CircleDrawer
    {
        // Dairenin çizilmesi ile ilgili metodu
        public void DrawCircle(int radius)
        {
            // Yarıçapa göre daireyi çizen kod
            for (int i = 0; i <= 2 * radius; i++)
            {
                for (int j = 0; j <= 2 * radius; j++)
                {
                    double distance = Math.Sqrt(Math.Pow(i - radius, 2) + Math.Pow(j - radius, 2));
                    if (distance > radius - 0.5 && distance < radius + 0.5)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // Kullanıcıdan yarıçap bilgisi al
            Console.Write("Yarıçapı giriniz: ");
            if (int.TryParse(Console.ReadLine(), out int radius) && radius > 0)
            {
                // Daireyi çizme işlemi
                var drawer = new CircleDrawer();
                drawer.DrawCircle(radius);
            }
            else
            {
                Console.WriteLine("Geçersiz bir yarıçap girdiniz.");
            }
        }
    }
}