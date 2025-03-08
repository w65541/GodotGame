using Godot;
using System;

public partial class X : Node2D
{
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		GlobalPosition=new Vector2(0,GlobalPosition.Y);
	}
}
