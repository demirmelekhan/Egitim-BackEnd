using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace alan_hesaplama
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Hangi şekil için alan hesabı yapmak istediğinizi seçin\n 1-KARE\n 2-DİKDÖRTGEN\n 3-DAİRE\n 4-ÜÇGEN");
                int input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case 1: KareAlan();
                            break;
                    case 2: DikdortgenAlan();
                            break;
                    case 3: DaireAlan();
                            break;
                    case 4: UcgenAlan();
                            break;
                    case 0:
                        Console.WriteLine("Programdan çıkılıyor....");
                        return;
                    default:
                        Console.WriteLine("Yanlış giriş yaptınız seçeneklerden birini ifade eden rakamsal karşılığı girin...");
                        break;
                }
            }
            Console.WriteLine(); // Görsel olarak bir boşluk bırak
        }
        static void KareAlan()
        {   
            Console.WriteLine("Kenar uzunluğunu giriniz:");
            int deger =Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Girilen Kare cisminin Alanı:"+ Math.Pow(deger,2));
        }
        static void DikdortgenAlan()
        {
            Console.WriteLine("Dikdörtgene ait iki komşu kenarın uzunluklarını giriniz:");
            int deger1 =Convert.ToInt32(Console.ReadLine());
            int deger2 =Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Girilen Dikdörtgen cisminin Alanı:"+deger1*deger2);
        }
        static void UcgenAlan()
        {
            Console.WriteLine("Taban uzunluğunu giriniz:");
            int taban =Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Yükseklik bilgilerini giriniz:");
            int yukseklik =Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Girilen Üçgen cisminin Alanı: "+ (taban*yukseklik)/2);
        }
        static void DaireAlan()
        {
            const double pi = 3.14159265;
            Console.WriteLine("Yarıçap uzunluğunu giriniz:");
            double deger =Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Girilen Daire cisminin Alanı:"+ Math.Pow(deger,2)*pi);
        }
    }
}