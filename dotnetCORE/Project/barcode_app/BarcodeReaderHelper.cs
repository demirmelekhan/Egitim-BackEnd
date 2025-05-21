using ZXing;
using ZXing.ImageSharp;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

public class BarcodeReaderHelper
{
    public static void ReadQRCode(string imagePath)
    {
        var reader = new BarcodeReaderGeneric();

        using var image = Image.Load<Rgba32>(imagePath);
        var result = reader.Decode(image);

        if (result != null)
            Console.WriteLine("QR kod içeriği: " + result.Text);
        else
            Console.WriteLine("QR kod okunamadı.");
    }
}
