using Godot;
using Godot.Collections;
using System;

public partial class Game : Node3D
{
    bool MouseOverUI = false;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        if (MouseOverUI)
        {
            if (Input.IsActionJustPressed("mouse_left"))
            {
                GD.Print("left");
                if (KazPhysics.MouseRaycast(GetNode<Camera3D>("Camera3D"), out KazRaycastResult result))
                {
                    GD.Print(result.position);
                }
            }
        }
    }
    public override void _PhysicsProcess(double delta)
    {

    }

    void MouseEnterUI() { MouseOverUI = true; }
    void MouseExitUI() { MouseOverUI = false; }
}
