using Godot;
using System;
using System.Linq;

public partial class BuildModeManager : Node
{
    public bool BuildMode = false;
    //[Export] Node3D ghostNode;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
		Manager.BuildMode = this;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

    public void SelectStructure(int _id)
    {
        GD.Print("in world " + _id);
        SetGhost(Manager.Game.Database.Structures[_id - 1].PackedScene);
        Manager.Input.SetInputBehavior(InputMode.BuildModeInput);
    }
    void SetGhost(string _packetScene)
    {
        Clean();
        Node node = GD.Load<PackedScene>(_packetScene).Instantiate();
        AddChild(node);
        BuildMode = true;
    }

    public void DisableBuildMode()
    {
        Manager.Input.SetInputBehavior(InputMode.BaseInput);
        Clean();
    }
    void Clean() { GetChildren().ToList().ForEach(child => child.Free()); }
}
