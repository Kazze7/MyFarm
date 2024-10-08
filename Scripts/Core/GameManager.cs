using Godot;
using System;
using System.Collections.Generic;

public partial class GameManager : Node
{
    public AppConfig Config = new();

    public Database Database = new();
    public WorldData WorldData = new();

    Dictionary<Scene, Node> scenes = new();
    Scene activeScene = Scene.Empty;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Manager.Game = this;
        //	Save files
        KazFile.Save(Config, "DataFiles/GameConfig.json");
        //	Load files
        KazFile.Load(out Config, "DataFiles/GameConfig.json");
        //  Load database
        LoadDatabase();
        //	Load scenes
        scenes.Add(Scene.Menu, GD.Load<PackedScene>("res://Scenes/MainMenu.tscn").Instantiate());
        scenes.Add(Scene.Game, GD.Load<PackedScene>("res://Scenes/GameWorld.tscn").Instantiate());
        //	Set scene
        SetScene(Scene.Menu);
    }
    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }

    void LoadDatabase()
    {
        KazFile.Load(out Database, Database.filePath);
        //Database.Indexing();
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
