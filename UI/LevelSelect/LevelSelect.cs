using Godot;
using System;

public partial class LevelSelect : Control
{
	public ConfigFile levels=new ConfigFile();
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		levels.Load("res://Configs/Levels.ini");
		foreach (LevelButton item in GetChild(0).GetChildren() )
		{
			item.level=levels;
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
