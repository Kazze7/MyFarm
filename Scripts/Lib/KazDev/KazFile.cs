using System.IO;
using System.Text.Json;

public static class KazFile
{
    public static void Load<T>(out T _fileData, string _filePath)
    {
        _fileData = JsonSerializer.Deserialize<T>(File.ReadAllText(_filePath));
    }
    public static void Save<T>(T _fileData, string _filePath)
    {
        File.WriteAllText(_filePath, JsonSerializer.Serialize(_fileData, new JsonSerializerOptions() { WriteIndented = true }));
    }
}
