using Godot;
using System.Collections.Generic;

public partial class InputManager : Node
{
    public bool MouseOverUI = false;

    List<InputBehavior> inputList = new()
    {
        new BaseInput(),
        new BuildModeInput()
    };
    InputBehavior inputBehavior;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
		Manager.Input = this;
        SetInputBehavior(InputMode.BaseInput);
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
    {
        inputBehavior.Process();
    }

    public void SetInputBehavior(InputMode _inputMode)
    {
        inputBehavior = inputList[(int)_inputMode];
    }
}
