using Godot;
using System;

public class StructureData
{
    public WorldID WorldID {  get; set; }
    public int Id { get; set; }

    public StructureData() { }
    public StructureData(WorldID _worldID, StructurePattern _structurePattern)
    {
        WorldID = _worldID;
        Id = _structurePattern.Id;
    }
}
