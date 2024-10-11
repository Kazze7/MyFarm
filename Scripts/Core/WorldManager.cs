using Godot;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

public partial class WorldManager : Node
{
    WorldData data = new();
    ConcurrentDictionary<WorldID, bool> nodes = new();

    ConcurrentDictionary<WorldID, StructureLogic> structures = new();

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Manager.World = this;
        Load();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }

    void Load()
    {
        GFile.Load(out data, Manager.Game.WorldDirectory + Global.WorldDataPath);
        data.structures.ForEach(structure => AddStructure(structure));
        Manager.GameUI.SetResources(data.resources);
    }
    public void Save()
    {
        data.structures.Clear();
        structures.Values.ToList().ForEach(structure => data.structures.Add(structure.data));
        GFile.Save(data, Manager.Game.WorldDirectory + Global.WorldDataPath);
    }

    public bool IsBuildable(WorldID _worldID)
    {
        return !nodes.TryGetValue(_worldID, out bool _);
    }
    public void AddStructure(StructureData _structureData)
    {
        if (!structures.ContainsKey(_structureData.WorldID))
        {
            StructureLogic structureLogic = (StructureLogic)GD.Load<PackedScene>(Manager.Game.Database.Structures[_structureData.Id].PackedScene).Instantiate();
            structureLogic.Position = GMath.WorldIDToPosition((Vector3I)_structureData.WorldID);
            structureLogic.Name += " " + _structureData.WorldID;
            structureLogic.data = _structureData;
            if (structures.TryAdd(_structureData.WorldID, structureLogic))
            {
                nodes.TryAdd(_structureData.WorldID, true);
                Manager.World.AddChild(structureLogic);
            }
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
