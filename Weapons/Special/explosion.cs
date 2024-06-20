using Godot;
using System;

public partial class explosion : AnimatedSprite2D
{
	public Vector2 spawnPos{get;set;} 
	public float spawnRot{get;set;} 
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GlobalPosition=spawnPos;
		GlobalRotation=spawnRot+Vector2.Down.Angle();
	}
public float damage=5f;
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void _on_area_2d_body_entered(Node2D bullet)
	{
		if(bullet.GetType()==new EnemyBasic().GetType()){ var en=(EnemyBasic) bullet; en.hp-=5;}
	}

	public void _on_animation_finished()//_on_timer_timeout()
	{
		QueueFree();
	}
	public void _on_timer_timeout()
	{
		QueueFree();
	}
}
