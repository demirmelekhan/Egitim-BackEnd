using System;
using System.Collections.Generic;

namespace Proje2_TODO_App
{
    public enum KartBuyuklugu
    {
        XS=1,
        S,
        M,
        L,
        XL
    }
    public class Kart
    {
        public string Baslik{ get; set; }
        public string Icerik{ get; set; }
        public string AtananKisi{ get; set; }
        public KartBuyuklugu Buyukluk{ get; set; }
        public Kart(string baslik, string icerik, string atananKisi,KartBuyuklugu buyukluk)
        {
            Baslik = baslik;
            Icerik = icerik;
            AtananKisi = atananKisi;
            Buyukluk=buyukluk;
        }
    }
    public class Board
    {
        public List<Kart> Todo { get; set; }=new List<Kart>();
        public List<Kart> InProgress { get; set; }=new List<Kart>();
        public List<Kart> Done { get; set; }=new List<Kart>();

        public void Listele()
        {
            Console.WriteLine("TODO Line");
            Console.WriteLine("***********************");
            foreach (var kart in Todo)
            {
                Console.WriteLine($"Başlık: {kart.Baslik}, İçerik: {kart.Icerik}, Atanan Kişi: {kart.AtananKisi}, Büyüklük: {kart.Buyukluk}");

            }

            Console.WriteLine("\nIN PROGRESS Line");
            Console.WriteLine("***********************");
            foreach (var kart in InProgress)
            {
                Console.WriteLine($"Başlık: {kart.Baslik}, İçerik: {kart.Icerik}, Atanan Kişi: {kart.AtananKisi}, Büyüklük: {kart.Buyukluk}");
                
            }

            Console.WriteLine("\nDONE Line");
            Console.WriteLine("***********************");
            if (Done.Count == 0)
            {
                Console.WriteLine("~ BOŞ ~");
            }
            else
            {
                foreach (var kart in Done)
                {
                    Console.WriteLine($"Başlık: {kart.Baslik}, İçerik: {kart.Icerik}, Atanan Kişi: {kart.AtananKisi}, Büyüklük: {kart.Buyukluk}");
                }
            }
        }
    }

    public class TakimUyesi
    {
        public int ID{ get; set; }
        public string Isim{ get; set; }

        public TakimUyesi(int id, string isim)
        {
            ID = id;
            Isim = isim;
        }
    }

    class Program
    {
        static Board board =new Board();
        static Dictionary<int, TakimUyesi> takimUyeleri=new Dictionary<int,TakimUyesi>();

        static void Main(string[] args)
        {
            takimUyeleri.Add(1, new TakimUyesi(1, "Melek"));
            takimUyeleri.Add(2, new TakimUyesi(2, "Minel"));
            takimUyeleri.Add(3, new TakimUyesi(3, "Sultan"));

            board.Todo.Add(new Kart("Görev 1", "ilk görev", "Melek", KartBuyuklugu.XL));
            board.InProgress.Add(new Kart("Görev 2", "İkinci görev", "Minel", KartBuyuklugu.M));
            board.Done.Add(new Kart("Görev 3", "Üçüncü görev", "Sultan", KartBuyuklugu.S));

            while(true)
            {
                Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :)");
                Console.WriteLine("*******************************************");
                Console.WriteLine("(1) Board Listelemek");
                Console.WriteLine("(2) Board'a Kart Eklemek");
                Console.WriteLine("(3) Board'dan Kart Silmek");
                Console.WriteLine("(4) Kart Taşımak");
                Console.WriteLine("(0) Çıkış");

                var secim=Console.ReadLine();

                switch(secim)
                {
                    case "1":
                        board.Listele();
                        break;
                    case "2":
                        KartEkle();
                        break;
                    case "3":
                        KartSil();
                        break;
                    case "4":
                        KartTasima();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Hatalı bir seçim yaptınız:");
                        break;
                }
            }
        }
        static void KartEkle()
        {
            Console.WriteLine("Başlık Giriniz:");
            string baslik=Console.ReadLine();

            Console.WriteLine("İçerik Giriniz:");
            string icerik=Console.ReadLine();   

            Console.WriteLine("Büyüklük Seçiniz -> XS(1), S(2), M(3), L(4), XL(5):");
            if(!Enum.TryParse<KartBuyuklugu>(Console.ReadLine(), out KartBuyuklugu 
            buyukluk) || !Enum.IsDefined(typeof(KartBuyuklugu), buyukluk))
            {
                Console.WriteLine("Hatalı büyüklük seçimi!");
                return;

            }

            Console.WriteLine("Kişi Seçiniz (ID giriniz):");
            int kisiId;
            if (!int.TryParse(Console.ReadLine(), out kisiId) || !takimUyeleri.ContainsKey(kisiId))
            {
                Console.WriteLine("Hatalı girişler yaptınız!");
                return;
            }


            string atananKisi=takimUyeleri[kisiId].Isim;
            board.Todo.Add(new Kart(baslik,icerik,atananKisi,buyukluk));
            Console.WriteLine("Kart başarıyla eklendi.");
        }
        static void KartSil()
        {
            Console.WriteLine("Lütfen kart başlığını yazınız:");
            string baslik =Console.ReadLine();

            var kartlar=board.Todo.FindAll(k=>k.Baslik.Equals(baslik,StringComparison.OrdinalIgnoreCase))
            .Concat(board.InProgress.FindAll(k=>k.Baslik.Equals(baslik,StringComparison.OrdinalIgnoreCase)))
            .Concat(board.Done.FindAll(k=>k.Baslik.Equals(baslik,StringComparison.OrdinalIgnoreCase)))
            .ToList();

            if(kartlar.Count==0)
            {
                Console.WriteLine("Aradığınız kriterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.");
                Console.WriteLine("* Silmeyi sonlandırmak için : (1)");
                Console.WriteLine("* Yeniden denemek için : (2)");
                var secim=Console.ReadLine();
                if(secim=="1") return;
                if(secim=="2") KartSil();
                return;
            }

            foreach(var kart in kartlar)
            {
                if(board.Todo.Contains(kart)) board.Todo.Remove(kart);
                else if (board.InProgress.Contains(kart)) board.InProgress.Remove(kart);
                else if(board.Done.Contains(kart)) board.Done.Remove(kart);
            }
            Console.WriteLine("Kart(lar) başarıyla silindi");

        }

        static void KartTasima()
        {
            Console.WriteLine("Lütfen kart başlığını yazınız:");
            string baslik=Console.ReadLine();

            var kartlar = board.Todo.FindAll(k => k.Baslik.Equals(baslik, StringComparison.OrdinalIgnoreCase))
                .Concat(board.InProgress.FindAll(k => k.Baslik.Equals(baslik, StringComparison.OrdinalIgnoreCase)))
                .Concat(board.Done.FindAll(k => k.Baslik.Equals(baslik, StringComparison.OrdinalIgnoreCase)))
                .ToList();

            
            if (kartlar.Count == 0)
            {
                Console.WriteLine("Aradığınız kriterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.");
                Console.WriteLine("* İşlemi sonlandırmak için : (1)");
                Console.WriteLine("* Yeniden denemek için : (2)");
                var secim = Console.ReadLine();
                if (secim == "1") return;
                if (secim == "2") KartTasima();
                return;
            }

            Kart kartToMove=kartlar[0];
            Console.WriteLine($"Başlık: {kartToMove.Baslik}, İçerik: {kartToMove.Icerik}, Atanan Kişi: {kartToMove.AtananKisi}, Büyüklük: {kartToMove.Buyukluk}");

            Console.WriteLine("Lütfen taşımak istediğiniz Line'ı seçiniz: ");
            Console.WriteLine("(1) TODO");
            Console.WriteLine("(2) IN PROGRESS");
            Console.WriteLine("(3) DONE");

            var lineSecim=Console.ReadLine();
            switch (lineSecim)
            {
                case "1":
                    if(board.InProgress.Contains(kartToMove)) board.InProgress.Remove(kartToMove);
                    else if (board.Done.Contains(kartToMove)) board.Done.Remove(kartToMove);
                    board.Todo.Add(kartToMove);
                    break;
                case "2":
                    if(board.Todo.Contains(kartToMove)) board.InProgress.Remove(kartToMove);
                    else if (board.Done.Contains(kartToMove)) board.Done.Remove(kartToMove);
                    board.InProgress.Add(kartToMove);
                    break;
                case "3":
                    if(board.Todo.Contains(kartToMove)) board.Todo.Remove(kartToMove);
                    else if (board.InProgress.Contains(kartToMove)) board.InProgress.Remove(kartToMove);
                    board.Done.Add(kartToMove);
                    break;
                default:
                    Console.WriteLine("Hatalı bir seçim yaptınız!");
                    return;
            }
            Console.WriteLine("Kart başarıyla taşındı.");
        }

    }
}
