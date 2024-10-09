using Godot;
using System;
using System.Linq;

public partial class GameUIManager : Node
{
    [Export] PackedScene structureButton;
    [Export] public Node structureContainer;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Manager.GameUI = this;
        ReloadUI();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }

    void MouseEnterUI() { Manager.Input.MouseOverUI = true; }
    void MouseExitUI() { Manager.Input.MouseOverUI = false; }

    void ReloadUI()
    {
        //  Clean
        structureContainer.GetChildren().ToList().ForEach(child => child.Free());
        //  Load
        Manager.Game.Database.Structures.ForEach(structure =>
        {
            Button button = structureButton.Instantiate().GetNode<Button>("Button");
            button.Text = structure.Name;
            button.Pressed += () => Manager.BuildMode.SelectStructure(structure.Id);
            button.GetParent().Name = structure.Name;
            structureContainer.AddChild(button.GetParent());
        });
    }
}
