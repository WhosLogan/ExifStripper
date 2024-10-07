using ExifLibrary;

namespace ExifStripper;

internal static class Program
{
    internal static void Main(string[] args)
    {
        var files = Directory.GetFiles(args[0]);
        var targetPath = Path.Join(args[0], "Stripped");
        Directory.CreateDirectory(targetPath);
        foreach (var file in files.Where(f => 
                     string.Compare(Path.GetExtension(f), ".jpg", StringComparison.OrdinalIgnoreCase) == 0))
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