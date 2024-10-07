using ExifLibrary;

namespace ExifStripper;

internal static class Program
{
    private static readonly IReadOnlyList<string> Extensions = [".jpg", ".png", ".jpeg"];
    
    internal static void Main(string[] args)
    {
        var files = Directory.GetFiles(args[0]);
        var targetPath = Path.Join(args[0], "Stripped");
        Directory.CreateDirectory(targetPath);
        foreach (var file in files.Where(f => Extensions.Contains(Path.GetExtension(f).ToLower())))
        {
            var img = ImageFile.FromFile(file);
            for (var i = 0; i < img.Properties.Count; i++)
            {
                var property = img.Properties[0];
                img.Properties.Remove(property);
            }
            img.Save(Path.Join(Path.GetDirectoryName(file), "Stripped", Path.GetFileName(file)));
        }
    }
}