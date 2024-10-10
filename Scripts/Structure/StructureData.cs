using Godot;
using System;

public class StructureData
{
    public Vector3I worldID {  get; set; }
    public int id { get; set; }

    public StructureData(Vector3I _worldID, StructurePattern _structurePattern)
    {
        worldID = _worldID;
        id = _structurePattern.Id;
    }
}
