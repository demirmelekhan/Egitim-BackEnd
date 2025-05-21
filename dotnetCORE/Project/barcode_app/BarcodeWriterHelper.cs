using ZXing;
using ZXing.ImageSharp.Rendering;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

public class BarcodeWriterHelper
{
    public static void CreateQRCode(string content, string outputPath)
    {
        var writer = new BarcodeWriter<Image<Rgba32>>
        {
            Format = BarcodeFormat.QR_CODE,
            Renderer = new ImageSharpRenderer<Rgba32>()
        };

        var image = writer.Write(content);
        image.Save(outputPath);

        Console.WriteLine($"QR kodu oluşturuldu: {outputPath}");
    }
}
