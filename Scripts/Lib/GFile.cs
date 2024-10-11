using Godot;
using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;

public static class GFile
{
    public static void Load<T>(out T _fileData, string _filePath)
    {
        if (File.Exists(_filePath))
            _fileData = JsonSerializer.Deserialize<T>(File.ReadAllText(_filePath));
        else
            _fileData = default;
    }
    public static void Save<T>(T _fileData, string _filePath)
    {
        File.WriteAllText(_filePath, JsonSerializer.Serialize(_fileData, new JsonSerializerOptions() { WriteIndented = true }));
    }
    public static string[] GetFiles(string _filePath)
    {
        if (Directory.Exists(_filePath))
            return Directory.GetFiles(_filePath);
        return Array.Empty<string>();
    }
    public static bool IsDirectoryExists(string _filePath)
    {
        return Directory.Exists(_filePath);
    }
    public static string[] GetDirectories(string _filePath)
    {
        if (Directory.Exists(_filePath))
            return Directory.GetDirectories(_filePath);
        return Array.Empty<string>();
    }
    public static void CreateDirectory(string _filePath)
    {
        if (!Directory.Exists(_filePath))
            Directory.CreateDirectory(_filePath);
    }
    public static void DeleteDirector(string _filePath)
    {
        Directory.Delete(_filePath, true);
    }
}
