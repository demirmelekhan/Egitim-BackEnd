using System;

namespace kalitim
{
    public class Hayvanlar:Canlilar
    {
        public void Adaptasyon()
        {
            Console.WriteLine("Hayvanlar adaptasyon kurabilir.");
        }
        public override void UyaranlaraTepki()
        {
            base.UyaranlaraTepki();
            Console.WriteLine("Hayvanlar temasa tepki verir.");
        }
    }
    public class Sürüngenler:Hayvanlar
    {
        public Sürüngenler()
        {
            base.Adaptasyon();
            base.Beslenme();
            base.Bosaltim();
            base.Solunum();
            
        }
        public void SurunerekHareketEder()
        {
            Console.WriteLine("---------Sürüngenler sürünerek hareket eder.---------");
        }
    }
    public class Kuslar:Hayvanlar
    {
        public Kuslar()
        {
            base.Adaptasyon();
            base.Beslenme();
            base.Bosaltim();
            base.Solunum();
            base.UyaranlaraTepki();
        }
        public void UcarakHareketEder()
        {
            Console.WriteLine("---------Kuşlar uçarak hareket eder.---------");
        }
    }
}
