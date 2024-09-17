using Godot;
using System;

public partial class Flame : ProjectilePlayer
{
	public override void _Ready()
	{
		base._Ready();
	}

	public override void _Process(double delta)
	{
		base._Process(delta);
		Scale*=1.01f;
		stats.speed*=0.99f*stop;
	}
}
