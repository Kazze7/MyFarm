using Godot;
using System;
using System.Collections.Generic;

public partial class GameManager : Node
{
    public static GameManager Access;
    public GameConfig Config = new();

    public Database Database = new();

    Dictionary<Scene, Node> scenes = new();
    Scene activeScene = Scene.Empty;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Access = this;
        //	Save files
        KazFile.Save(Config, "Data/GameConfig.json");
        //	Load files
        KazFile.Load(out Config, "Data/GameConfig.json");
        //  Load database
        KazFile.Load(out Database, Database.filePath);
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
