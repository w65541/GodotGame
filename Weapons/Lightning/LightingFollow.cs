using Godot;
using System;

public partial class LightingFollow : PathFollow2D
{
	public float speed=0;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		ProgressRatio+= (float)(delta * speed);
		if(ProgressRatio==1) GetParent().QueueFree();
	}
	public void Start(){
		speed=5;
	}
}
