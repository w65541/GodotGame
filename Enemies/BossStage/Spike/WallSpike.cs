using Godot;
using System;

public partial class WallSpike : Sprite2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void start(float x){
		
			var t=GetChild<Timer>(1);
			t.WaitTime=x+0.5f;
			t.Start();
	}
}
