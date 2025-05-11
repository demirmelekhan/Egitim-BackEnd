using System;

namespace vote_app
{
    class Program
    {
        //Pre-defined kategoriler
        static List<string> categories= new List<string>
        {
            "En İyi Film",
            "En İyi Tech Stack",
            "En İyi Spor Dalı"
        };

        static List<string> registeredUsers =new List<string>
        {
            "Hyeri",
            "Subin",
            "Sonya"
        };

        static Dictionary<string,int> votes = new Dictionary<string, int>();

        static void Main(string[] args)
        {
            Console.WriteLine("Voting Uygulamasına Hoşgeldiniz!\n");

            // Oyları sıfırla
            foreach (var category in categories)
            {
                votes[category] = 0;
            }

            while (true)
            {
                Console.Write("Kullanıcı adınızı girin (çıkmak için 'çık' yazın): ");
                string username = Console.ReadLine();

                if (username.ToLower() == "çık")
                {
                    break;
                }

                if (!registeredUsers.Contains(username))
                {
                    Console.WriteLine("Kullanıcı bulunamadı. Kayıt olunuyor...");
                    registeredUsers.Add(username);
                }

                Console.WriteLine($"\nMerhaba, {username}! Oy vermek istediğiniz kategoriyi seçin:");

                for (int i = 0; i < categories.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {categories[i]}");
                }

                Console.Write("Kategori numarası girin: ");
                string input = Console.ReadLine();

                bool isValid = int.TryParse(input, out int choice);

                if (isValid && choice >= 1 && choice <= categories.Count)
                {
                    string selectedCategory = categories[choice - 1];
                    votes[selectedCategory]++;
                    Console.WriteLine($"\n'{selectedCategory}' kategorisine oy verdiniz. Teşekkürler!\n");
                }
                else
                {
                    Console.WriteLine("Geçersiz kategori numarası. Oy verilmedi.\n");
                }
            }

            // Oy sonuçlarını göster
            ShowResults();
        }

         static void ShowResults()
        {
            Console.WriteLine("\n📊 Oylama Sonuçları:\n");

            int totalVotes = votes.Values.Sum();

            foreach (var entry in votes)
            {
                string category = entry.Key;
                int count = entry.Value;
                double percentage = totalVotes > 0 ? (count / (double)totalVotes) * 100 : 0;

                Console.WriteLine($"- {category}: {count} oy (%{percentage:F1})");
            }

            Console.WriteLine("\n👋 Uygulama sona erdi. İyi günler!");
        }
    
    }
}