using Godot;
using System;
using System.Collections.Generic;

public partial class GameManager : Node
{
    public static GameManager Access;
    public GConfig Config = new();
    public GameData Data = new();

    Dictionary<Scene, Node> scenes = new();
    Scene activeScene = Scene.Empty;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Access = this;
        //	Save files
        KazFile.Save(Config, "GameConfig.json");
        //	Load files
        KazFile.Load(out Config, "GameConfig.json");
        //	Load scenes
        scenes.Add(Scene.Game, GD.Load<PackedScene>("res://Scenes/Game.tscn").Instantiate());
        //	Set scene
        SetScene(Scene.Game);
    }
    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }

    void SetScene(Scene _scene)
    {
        Node node;
        if (scenes.TryGetValue(activeScene, out node))
            RemoveChild(node);
        activeScene = _scene;
        if (scenes.TryGetValue(activeScene, out node))
            AddChild(node);
    }
}
