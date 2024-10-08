using Godot;
using System;
using System.Collections.Generic;

public class Database
{
    public static string filePath = "DataFiles/Database.json";

    public List<Structure> Structures { get; set; } = new();

    public void Save()
    {
        KazFile.Save(this, filePath);
    }
}
