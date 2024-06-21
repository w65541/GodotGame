using Godot;
using System;

public partial class Main : Node2D
{
	public int Score=0;
	levelupmenu level;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		level=GetNode<levelupmenu>("Player/LevelUpMenu");
		//GetChild(1).ReplaceBy;   //
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("ui_focus_next"))
		{
			level.Visible=true;
			level.rollLevelUp();
		}
	}
}
