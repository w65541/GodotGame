using Godot;
using System;

public partial class Y : Node2D
{
	public override void _Process(double delta)
	{
		GlobalPosition=new Vector2(GlobalPosition.X,0);
	}
}
