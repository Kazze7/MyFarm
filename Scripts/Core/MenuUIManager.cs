using Godot;
using System;
using System.IO;
using System.Linq;

public partial class MenuUIManager : Node
{
	[Export] Control[] subMenu;
	[Export] Control selectGameContainer;
	[Export] PackedScene gameWorldButton;
	string worldName;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        SelectSubMenu(0);
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	void SelectSubMenu(int _id)
    {
        subMenu.ToList().ForEach(subMenu => subMenu.Hide());
        subMenu[_id].Show();
		switch(_id)
		{
			case 1:
				{
					LoadWorldSave();
                    break;
				}
		}
    }
	void LoadWorldSave()
    {
        GUtility.FreeAllChildNode(selectGameContainer);
        GFile.GetDirectories(Global.WorldDirectoryPath).ToList().ForEach(worldDirectory =>
        {
            Control control = gameWorldButton.Instantiate() as Control;
            control.Name = Path.GetFileName(worldDirectory);
            control.GetNode<Label>("Button/Label").Text = Path.GetFileName(worldDirectory);
            control.GetNode<Button>("Button").Pressed += () => { LoadWorld(worldDirectory); };
            control.GetNode<Button>("Delete").Pressed += () => { DeleteWorld(worldDirectory); control.QueueFree(); };
            selectGameContainer.AddChild(control);
        });
    }
	void CreateWorld()
	{
		if (worldName.Length > 3)
		{
			GFile.CreateDirectory(Global.WorldDirectoryPath + worldName);
			GFile.Save(new WorldData(), Global.WorldDirectoryPath + worldName + Global.WorldDataPath);
			LoadWorld(Global.WorldDirectoryPath + worldName);
		}
		//else
		//pop up
	}
	void SetWorldName(string _worldName)
	{
		worldName = _worldName;
	}
	void LoadWorld(string _worldDirectory)
	{
        GD.Print("Load world " + Path.GetFileName(_worldDirectory));
		Manager.Game.WorldDirectory = _worldDirectory;
		Manager.Game.SetScene(Scene.Game);
    }
	void DeleteWorld(string _worldDirectory)
	{
		GFile.DeleteDirector(_worldDirectory);
    }
	void ExitGame()
	{
		GetTree().Quit();
	}
}
