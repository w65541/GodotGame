using Godot;
using System;

public partial class TargetTest : Sprite2D
{
	TargetClosest closest;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		closest=GetTree().GetFirstNodeInGroup("Closest") as TargetClosest;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Rotation=closest.rotate;
	}
}
