using Godot;
using System;

public partial class EndScreen : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Visible=!Visible;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public void backToMenu()
	{
		var menu=GetTree().GetFirstNodeInGroup("LevelSelectMenu") as Control;
		menu.Visible=true;
		var level=GetTree().GetFirstNodeInGroup("Main") as Node2D;
		level.Visible=false;
		level.QueueFree();
	}
}
