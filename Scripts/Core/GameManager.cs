using Godot;
using System;
using System.Collections.Generic;

public partial class GameManager : Node
{
    public AppConfig Config = new();

    public Database Database = new();
    public string WorldDirectory = "";

    Dictionary<Scene, PackedScene> scenes = new();
    Node activeScene;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Manager.Game = this;
        //	Save files
        GFile.Save(Config, "DataFiles/GameConfig.json");
        //	Load files
        GFile.Load(out Config, "DataFiles/GameConfig.json");
        //  Load database
        GFile.Load(out Database, Global.DatabasePath);
        //	Load scenes
        scenes.Add(Scene.Menu, GD.Load<PackedScene>("res://Scenes/MainMenu.tscn"));
        scenes.Add(Scene.Game, GD.Load<PackedScene>("res://Scenes/GameWorld.tscn"));
        //	Set scene
        SetScene(Scene.Menu);
    }
    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }

    public void SetScene(Scene _scene)
    {
        if (activeScene!=null)
            RemoveChild(activeScene);
        if (scenes.TryGetValue(_scene, out PackedScene packedScene))
            AddChild(activeScene = packedScene.Instantiate());
    }
}
