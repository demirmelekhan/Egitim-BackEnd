class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Kullanım:");
            Console.WriteLine("  qr write <yazılacak metin> <çıktı yolu>");
            Console.WriteLine("  qr read <dosya yolu>");
            return;
        }

        var command = args[0].ToLower();

        if (command == "write" && args.Length >= 3)
        {
            BarcodeWriterHelper.CreateQRCode(args[1], args[2]);
        }
        else if (command == "read" && args.Length >= 2)
        {
            BarcodeReaderHelper.ReadQRCode(args[1]);
        }
        else
        {
            Console.WriteLine("Hatalı argümanlar.");
        }
    }
}
