using Godot;
using System;
using System.Collections.Generic;

public class Database
{
    public List<StructurePattern> Structures { get; set; } = new();

    public void Save()
    {
        GFile.Save(this, Global.DatabasePath);
    }
    public void Indexing()
    {
        int x = 0;
        Structures.ForEach(structure => structure.Id = x++);
        Save();
    }
}
