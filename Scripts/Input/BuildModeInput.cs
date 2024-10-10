using Godot;
using System;

public class BuildModeInput : InputBehavior
{
    public override void Keyboard()
    {
        if(Input.IsActionJustPressed("key_esc"))
        {
            Manager.BuildMode.DisableBuildMode();
            return;
        }
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
                    Manager.BuildMode.SetMousePosition(result.position);
                    if (Input.IsActionJustPressed("mouse_left"))
                    {
                        Manager.BuildMode.BuildStructure();
                    }
                }
            }
        }
    }
}
