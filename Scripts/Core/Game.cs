using Godot;
using Godot.Collections;
using System;
using System.Linq;

public partial class Game : Node3D
{
    bool MouseOverUI = false;
    [Export]
    public PackedScene structureButton;
    [Export]
    public Node bottomPanel;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        ReloadUI();
    }
    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        if (MouseOverUI)
        {
            if (Input.IsActionJustPressed("mouse_left"))
            {
                GD.Print("left");
                if (GPhysics.MouseRaycast(GetNode<Camera3D>("Camera3D"), 100.0f, out GRaycastResult result))
                {
                    GD.Print(result.position);
                    GD.Print(GMath.PositionToWorldID(result.position));
                }
            }
        }
    }

    void MouseEnterUI() { MouseOverUI = true; }
    void MouseExitUI() { MouseOverUI = false; }

    void ReloadUI()
    {
        bottomPanel.GetChildren().ToList().ForEach(child => child.Free());
        GameManager.Access.Database.Structures.ForEach(structure =>
        {
            Button button = structureButton.Instantiate().GetNode<Button>("Button");
            button.Text = structure.Name;
            button.Pressed += () => SelectStructure(structure.Id);
            button.GetParent().Name = structure.Name;
            bottomPanel.AddChild(button.GetParent());
        });
    }
    void SelectStructure(int _id)
    {
        GD.Print(_id);
    }
}
