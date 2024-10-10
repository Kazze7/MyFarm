using Godot;
using System;
using System.Linq;

public partial class BuildModeManager : Node3D
{
    public bool BuildMode = false;

    Vector3I currentID;

    StructurePattern structurePattern;
    PackedScene structurePackedScene = null;
    Node3D ghostContainer;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Manager.BuildMode = this;
        ghostContainer = this;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        if (Manager.Input.MouseOverUI && BuildMode)
        {
            ghostContainer.Position = GMath.WorldIDToPosition(currentID);
            ghostContainer.Show();
        }
        else
        {
            ghostContainer.Hide();
        }
    }

    public void SetMousePosition(Vector3 _position)
    {
        currentID = GMath.PositionToWorldID(GMath.PositionToTile(_position));
    }

    public void SelectStructure(int _id)
    {
        //check requirments
        BuildMode = true;
        structurePattern = Manager.Game.Database.Structures[_id];
        structurePackedScene = GD.Load<PackedScene>(structurePattern.PackedScene);
        Manager.Input.SetInputBehavior(InputMode.BuildModeInput);

        //ghost
        Clean();
        ghostContainer.AddChild(structurePackedScene.Instantiate());
    }
    public void BuildStructure()
    {
        Manager.World.AddStructure(new StructureData(currentID, structurePattern));
    }

    public void DisableBuildMode()
    {
        BuildMode = false;
        Manager.Input.SetInputBehavior(InputMode.BaseInput);
        Clean();
    }
    void Clean() { ghostContainer.GetChildren().ToList().ForEach(child => child.Free()); }
}
