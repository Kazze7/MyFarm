using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class WorldManager : Node
{
    WorldData world;

    Dictionary<Vector3I, StructureLogic> structures = new();

    Dictionary<Vector3I, int> tiles = new();

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Manager.World = this;
        world = Manager.Game.WorldData;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }

    public void AddStructure(StructureData _structureData)
    {
        if (!structures.ContainsKey(_structureData.worldID))
        {
            StructureLogic structureLogic = (StructureLogic)GD.Load<PackedScene>(Manager.Game.Database.Structures[_structureData.id].PackedScene).Instantiate();
            structureLogic.Position = GMath.WorldIDToPosition(_structureData.worldID);
            structureLogic.Name += " " + _structureData.worldID;
            structureLogic.data = _structureData;
            if (structures.TryAdd(_structureData.worldID, structureLogic))
                Manager.World.AddChild(structureLogic);
        }
    }
}
