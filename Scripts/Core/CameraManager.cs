using Godot;
using System;

public partial class CameraManager : Node
{
	public Camera3D MainCamera;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Manager.Camera = this;
		MainCamera = GetNode<Camera3D>("Camera3D");
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
