namespace OnlineShopWebApp.Service;

public class FileProvider(string path)
{
    public static string Read(string filePath)
    {
        try
        {
            var data = File.ReadAllText(filePath);
            return data;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return String.Empty;
        }
    }

    public static void Write(string path, string item)
    {
        try
        {
            File.WriteAllText(path, item);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public static bool Exists(string fileName)
    {
        return File.Exists(fileName);
    }
}
