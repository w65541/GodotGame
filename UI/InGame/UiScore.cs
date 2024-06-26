using Godot;
using System;

public partial class UiScore : Label
{
	BasicLevel main;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		main=(BasicLevel) GetTree().GetFirstNodeInGroup("Main");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Text="Exp: "+main.exp+"/"+main.nextLevelExp;
	}
}
