using Godot;
using System;

public partial class SpikeGroup : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public void attack(float x)
	{
		foreach (WallSpike item in GetChildren())
		{
			item.start(x);
			x+=0.25F;
			GD.Print("Spike "+x);
		}
	}
}
