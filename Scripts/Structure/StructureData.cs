using Godot;
using System;

public class StructureData
{
    public WorldID worldID {  get; set; }
    public int id { get; set; }

    public StructureData() { }
    public StructureData(WorldID _worldID, StructurePattern _structurePattern)
    {
        worldID = _worldID;
        id = _structurePattern.Id;
    }
}
