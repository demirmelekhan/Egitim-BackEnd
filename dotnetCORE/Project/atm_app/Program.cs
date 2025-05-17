using System;
using System.Runtime.CompilerServices;

namespace MyApp
{
    class atm_app
    {
        class User
        {
            //kullanıcıların kimlik bilgisini ve bakiyelerini tutan sınıf
            public string Username { get; set; }
            public string Password { get; set; }
            public decimal Balance { get; set; }

            public User(string username, string password, decimal balance)
            {
                Username = username;
                Password = password;
                Balance = balance;

            }
        }
        class Transaction
        {
            public string Username { get; set; }
            public string Type { get; set; }
            public decimal Amount { get; set; }
            public DateTime Date { get; set; }

            public Transaction(string username, string type, decimal amount)
            {
                Username = username;
                Type = type;
                Amount = amount;
                Date = DateTime.Now;
            }

            public override string ToString()
            {
                return $"{Date:dd-MM-yyyy HH:mm:ss} - User:{Username} - {Type} Amount: {Amount:C}";
            }

        }

        //dolandırıcılık durumlarını engellemek amaçlı giriş kayıtlarını tutmalı
        class fraudAttempt
        {
            public string Username { get; }
            public string Reason { get; }
            public DateTime Date { get; }

            public fraudAttempt(string username, string reason)
            {
                Username = username;
                Reason = reason;
                Date = DateTime.Now;

            }

            public override string ToString()
            {
                return $"{Date:dd-MM-yyyy HH:mm:ss} - Kullanıcı: {Username} - Açıklama: {Reason}";
            }


        }
        //Tanımlanmış kullanıcılar
        static List<User> users = new List<User>
        {
            new User("Melek", "1234" , 20000M),
            new User("Hyeri", "0609", 10000M),
            new User("Sonya","5678" , 7000M)

        };

        //Log kayıtlarını tutan liste
        static List<Transaction> transactions = new List<Transaction>();
        static List<fraudAttempt> fraudAttempts = new List<fraudAttempt>();
        static void Main(string[] args)
        {
            Console.WriteLine("ATM uygulamasına hoşgeldiniz...");

            User currentUser = null;
            int loginAttemps = 0;

            while (currentUser == null)
            {
                Console.WriteLine("Kullanıcı adını giriniz: ");
                string username = Console.ReadLine();
                Console.WriteLine("Kart şifrenizi giriniz: ");
                string password = Console.ReadLine();

                var user = users.FirstOrDefault(u => u.Username == username && u.Password == password);

                if (user != null)
                {
                    currentUser = user;
                    Console.WriteLine($"Giriş başarılı. Hoşgeldin, {currentUser.Username}!");

                }
                else
                {
                    loginAttemps++;
                    Console.WriteLine("Giriş işlemi başarısız! Lütfen tekrar deneyin...");
                    fraudAttempts.Add(new fraudAttempt(username, "Başarısız giriş"));
                    if (loginAttemps >= 3)
                    {
                        Console.WriteLine("Çok sayıda başarısız giriş. Çıkış...");
                        return;
                    }
                }

            }
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n Yapmak istediğiniz işlemi seçin...");
                Console.WriteLine("1- Para Çek");
                Console.WriteLine("2- Para Yatır");
                Console.WriteLine("3- Ödeme Yap");
                Console.WriteLine("4- Bakiyeyi Göster");
                Console.WriteLine("5- Gün Sonu Raporu");
                Console.WriteLine("0- Çıkış");

                Console.WriteLine("Seçenek: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Withdraw(currentUser);
                        break;
                    case "2":
                        Deposit(currentUser);
                        break;
                    case "3":
                        MakePayment(currentUser);
                        break;
                    case "4":
                        Console.WriteLine("Güncel Bakiyeniz: {currentUser.Balance: C}");
                        break;
                    case "5":
                        EndOfDay();
                        break;
                    case "0":
                        exit = true;
                        Console.WriteLine("ATM'yi kullandığınız için teşekkürler. Hoşçakalın...");
                        break;
                    default:
                        Console.WriteLine("Lütfen seçeneklerden birini tekrar deneyin.");
                        break;
                }
            }
        }

        static void Withdraw(User user)
        {
            Console.WriteLine("Çekmek istediğiniz tutarı giriniz: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                if (amount <= 0)
                {
                    Console.WriteLine("Çekim işlemi için yeterli bakiyeniz yok.");
                    return;
                }
                if (user.Balance >= amount)
                {
                    user.Balance -= amount;
                    transactions.Add(new Transaction(user.Username, "Çekilecek Tutar:", amount));
                    Console.WriteLine($"{amount:C} para çekme işlemi başarılı Yeni bakiyeniz: {user.Balance:C}");

                }
                else
                {
                    Console.WriteLine("Yetersiz Bakiye...");
                }
            }
            else
            {
                Console.WriteLine("Geçersiz Miktar...");
            }

        }
        static void Deposit(User user)
        {
            Console.WriteLine("Yatırılacak tutarı giriniz: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                user.Balance += amount;
                transactions.Add(new Transaction(user.Username, "Yatırılan", amount));
                Console.WriteLine($"{amount:C} tutarındaki yatırma işlemi başarıyla gerçekleştirildi. Yeni bakiyeniz {user.Balance:C}");

            }
            else
            {
                Console.WriteLine("Geçersiz tutar");
            }
        }

        static void MakePayment(User user)
        {
            Console.WriteLine("Ödeme yapılacak alıcı bilgilerini giriniz: ");
            string recipient = Console.ReadLine();

            Console.WriteLine("Ödeme tutarını giriniz: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                if (amount <= 0)
                {
                    Console.WriteLine("Ödeme gerçekleştirmek için yeterli bakiyeniz yok.");
                    return;
                }
                if (user.Balance >= amount)
                {
                    user.Balance -= amount;
                    transactions.Add(new Transaction(user.Username, $"Payment to {recipient}", amount));
                    Console.WriteLine($"{amount:C} tutarındaki ödeme işlemi {recipient} hesabına yatırılmıştır. Yeni bakiyeniz: {user.Balance:C}");

                }
                else
                {
                    Console.WriteLine("Yetersiz Bakiye...");
                }

            }
            else
            {
                Console.WriteLine("Geçersiz Bakiye...");
            }


        }

        static void EndOfDay()
        {
            Console.WriteLine("Gün Sonu Raporu oluşturuluyor...");

            //Log dizini yoksa oluştur
            string logDirectory = Path.Combine(Environment.CurrentDirectory, "Logs");
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }
            string dateString = DateTime.Now.ToString("ddMMyyyy");
            string logFileName = $"EOD_{dateString}.txt";
            string logFilePath = Path.Combine(logDirectory, logFileName);

            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"**** Gün Sonu Raporu {DateTime.Now:dd-MM-yyyy HH:mm:ss} ****");
                writer.WriteLine("\nİşlemler: ");
                if (transactions.Count == 0)
                {
                    writer.WriteLine("Bugün işlem yapılmadı...");
                }
                else
                {
                    foreach (var t in transactions)
                    {
                        writer.WriteLine(t.ToString());

                    }
                }
                writer.WriteLine("Potansiyel Dolandırıcılık girişimleri: ");
                if (fraudAttempts.Count == 0)
                    writer.WriteLine("Dolandırıcılık girişimi saptanmadı.");
                else
                {
                    foreach (var f in fraudAttempts)
                    {
                        writer.WriteLine(f.ToString());
                    }
                }
                writer.WriteLine("__________________________________________");
                writer.WriteLine();
            }
            Console.WriteLine($"Gün sonu raporu kaydedildi: {logFilePath}");
        }

        //Girileni göstermeden başarılı okuma yöntemi
        static string ReadPassword()
        {
            string password = "";
            ConsoleKeyInfo info = Console.ReadKey(true);

            while (info.Key != ConsoleKey.Enter)
            {
                if (info.Key == ConsoleKey.Backspace)
                {
                    if (password.Length > 0)
                    {
                        password = password.Substring(0, password.Length - 1);
                        Console.WriteLine("\b \b");
                    }
                }
                else if (!char.IsControl(info.KeyChar))
                {
                    password += info.KeyChar;
                    Console.WriteLine("*");
                }
                info = Console.ReadKey(true);
            }
            Console.WriteLine();
            return password;

        }
    }
}