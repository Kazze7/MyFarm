using Godot;
using System;

public class BuildModeInput : InputBehavior
{
    public override void Keyboard()
    {

    }

    public override void Mouse()
    {
        if (Input.IsActionJustPressed("mouse_right"))
        {
            Manager.BuildMode.DisableBuildMode();
            return;
        }
        if (Manager.Input.MouseOverUI)
        {
            if (Manager.BuildMode.BuildMode)
            {
                if (GPhysics.MouseRaycast(Manager.Camera.MainCamera, 100.0f, out GRaycastResult result))
                {
                    if (Input.IsActionJustPressed("mouse_left"))
                    {
                        GD.Print("left build");
                        GD.Print(GMath.PositionToWorldID(result.position));
                    }

                    //Manager.BuildMode.SetGhostPosition(GMath.PositionToTile(result.position));

                    //Manager.BuildMode.ShowGhost();
                }
            }
        }
    }
}
