using System.Text.Json;

namespace OnlineShopWebApp.Service;

public static class Serializator
{
    private static readonly JsonSerializerOptions _options = new JsonSerializerOptions
    {
        WriteIndented = true,
        Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    };

    public static List<T> Deserialize<T>(string data)
    {
        try
        {
            var result = JsonSerializer.Deserialize<List<T>>(data);
            return result ?? [];
        }
        catch (Exception)
        {
            return [];
        }
    }

    public static string Serialize<T>(List<T> list)
    {
        var jsonString = JsonSerializer.Serialize(list, _options);

        return jsonString;
    }

}
