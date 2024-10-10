using Godot;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

public partial class WorldManager : Node
{
    WorldData world;
    ConcurrentDictionary<WorldID, bool> nodes = new();

    ConcurrentDictionary<WorldID, StructureLogic> structures = new();

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Manager.World = this;
        world = Manager.Game.WorldData;
        Load();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }

    void Load()
    {
        KazFile.Load(out world, "DataFiles/WorldData.json");
        world.structures.ForEach(structure => AddStructure(structure));
        Manager.GameUI.SetResources(world.resources);
    }
    void Save()
    {
        world.structures.Clear();
        structures.Values.ToList().ForEach(structure => world.structures.Add(structure.data));
        KazFile.Save(world, "DataFiles/WorldData.json");
    }

    public bool IsBuildable(WorldID _worldID)
    {
        return !nodes.TryGetValue(_worldID, out bool _);
    }
    public void AddStructure(StructureData _structureData)
    {
        if (!structures.ContainsKey(_structureData.worldID))
        {
            StructureLogic structureLogic = (StructureLogic)GD.Load<PackedScene>(Manager.Game.Database.Structures[_structureData.id].PackedScene).Instantiate();
            structureLogic.Position = GMath.WorldIDToPosition((Vector3I)_structureData.worldID);
            structureLogic.Name += " " + _structureData.worldID;
            structureLogic.data = _structureData;
            if (structures.TryAdd(_structureData.worldID, structureLogic))
            {
                nodes.TryAdd(_structureData.worldID, true);
                Manager.World.AddChild(structureLogic);
            }
            //Save();
        }
    }
    public void RemoveStructure(WorldID _worldID)
    {
        if(structures.TryRemove(_worldID, out StructureLogic structureLogic))
        {
            nodes.TryRemove(_worldID, out bool _);
            structureLogic.Free();
        }
    }
}
