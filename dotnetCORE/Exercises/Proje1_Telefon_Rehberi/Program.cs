using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;

namespace Proje1_Telefon_Rehberi
{
    class Program
    {
        static Dictionary<string, (string Ad, string Soyad, string Telefon)> telefonRehber = new Dictionary<string, (string Ad, string Soyad, string Telefon)>();

        static void Main(string[] args)
        {
            // Varsayılan Kayıtlar
            telefonRehber["Ahmet Yılmaz"] = ("Ahmet", "Yılmaz", "123456789");
            telefonRehber["Mehmet Kaya"] = ("Mehmet", "Kaya", "987654321");
            telefonRehber["Ayşe Demir"] = ("Ayşe", "Demir", "555666777");
            telefonRehber["Fatma Çelik"] = ("Fatma", "Çelik", "444555666");
            telefonRehber["Ali Şahin"] = ("Ali", "Şahin", "333222111");

            while(true)
            {
                Console.Clear();
                Console.WriteLine("TELEFON REHBERİ");
                Console.WriteLine("1. Telefon Numarası Kaydet");
                Console.WriteLine("2. Telefon Numarası Sil");
                Console.WriteLine("3. Telefon Numarası Güncelle");
                Console.WriteLine("4. Rehberi Listele (A-Z / Z-A)");
                Console.WriteLine("5. Rehberde Arama");
                Console.WriteLine("0. Çıkış");
                Console.WriteLine("Seçiminizi yapın: ");

                string choice=Console.ReadLine();

                switch(choice)
                {
                    case "1":
                        Ekleme();
                        break;
                    case "2":
                        Silme();
                        break;
                    case "3":
                        Guncelleme();
                        break;
                    case "4":
                        Listele();
                        break;
                    case "5":
                        Arama();
                        break;
                    case "0":
                        Console.WriteLine("Çıkış yapılıyor.");
                        return;
                    default:
                        Console.WriteLine("Geçersiz seçim. Tekrar deneyin.");
                        break;
                }
                Console.WriteLine("Devam etmek için bir tuşa basın...");
                Console.ReadKey();
            }
        }
        static void Ekleme()
        {
            Console.WriteLine("İsim: ");
            string ad=Console.ReadLine();
            Console.WriteLine("Soyisim: ");
            string soyad =Console.ReadLine();
            Console.WriteLine("Telefon Numarası: ");
            string numara=Console.ReadLine();

            string key =$"{ad} {soyad}";
            if(telefonRehber.ContainsKey(key))
            {
                Console.WriteLine("Bu kişi kayıtlı");
            }
            else
            {
                telefonRehber[key]=(ad,soyad,numara);
                Console.WriteLine("Kişi başarıyla kaydedildi.");
            }
        
        }
        static void Silme()
        {
            Console.WriteLine("Silmek istediğiniz kişinin ad: ");
            string ad=Console.ReadLine();
            Console.WriteLine("Silmek istediğiniz kişinin soyadı:");
            string soyad=Console.ReadLine();

            string key =$"{ad} {soyad}";

            if(telefonRehber.Remove(key))
            {
                Console.WriteLine("kişi başarıyla silindi.");

            }
            else
            {
                Console.WriteLine("Kişi bulunamadı.");
            }
        }
        static void Guncelleme()
        {
            Console.WriteLine("Güncellemek istediğiniz kişinin adı: ");
            string ad=Console.ReadLine();
            Console.WriteLine("Güncellemek istediğiniz kişinin adı: ");
            string soyad=Console.ReadLine();

            string key=$"{ad} {soyad}";

            if (telefonRehber.ContainsKey(key))
            {
                Console.WriteLine("Yeni telefon numarası: ");
                string yeniNumara=Console.ReadLine();
                telefonRehber[key]=(ad,soyad,yeniNumara);
                Console.WriteLine("Telefon numarası güncellendi.");
            }
            else
            {
                Console.WriteLine("Kişi bulunamadı.");
            }
        }
        static void Listele()
        {
            Console.WriteLine("1. A-Z");
            Console.WriteLine("2. Z-A");
            Console.WriteLine("Seçiminizi yapın: ");
            string siralama=Console.ReadLine();

            IEnumerable<KeyValuePair<string,(string Ad, string Soyad, string Telefon)>> siraliRehber;
            if(siralama=="2")
            {
                //Z-A siralama
                siraliRehber=telefonRehber.OrderByDescending(kvp=>kvp.Value.Ad);
            }
            else
            {
                //A-Z sıralama (varsayılan)
                siraliRehber=telefonRehber.OrderBy(kvp=>kvp.Value.Ad);
            }

            Console.WriteLine("\n Rehber: ");
            foreach(var contact in siraliRehber)
            {
                Console.WriteLine($"İsim: {contact.Value.Ad}, Soyisim: {contact.Value.Soyad}, Telefon: {contact.Value.Telefon}");
            }
        }
        static void Arama()
        {
            Console.WriteLine("Aramak istediğiniz isim veya telefon numarası:");
            string sorgu=Console.ReadLine();

            var sonuclar=telefonRehber
                .Where(kvp=>    kvp.Value.Ad.ToLower().Contains(sorgu) || 
                                kvp.Value.Soyad.ToLower().Contains(sorgu) ||
                                kvp.Value.Telefon.Contains(sorgu))
                                .ToList();

            
            if(sonuclar.Any())
            {
                Console.WriteLine("Sonuçlar: ");
                foreach (var sonuc in sonuclar)
                {
                    Console.WriteLine($"İsim: {sonuc.Value.Ad}, Soyad: {sonuc.Value.Soyad} Telefon: {sonuc.Value.Telefon}");
                }
            }
            else
            {
                Console.WriteLine("Eşleşen sonuç bulunamadı.");
            }
        }

    }
}
