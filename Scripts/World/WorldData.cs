using Godot;
using System;
using System.Collections.Generic;

public class WorldData
{
    public ResourceData resources { get; set; } = new();
    public List<StructureData> structures {  get; set; } = new();
}
