using Godot;
using System;

public partial class ShotgunBullet : ProjectilePlayer
{
	/*[Export] public float speed {get;set;} 
	public float dir {get;set;} 
	public Vector2 spawnPos{get;set;} 
	public float spawnRot{get;set;} 
	public float damage {get;set;} 
	public int penetration=2;*/
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
		//GlobalPosition=spawnPos;
		//GlobalRotation=spawnRot+Vector2.Down.Angle();
		//GD.Print("rotate"+GlobalRotation);
		//Rotation=spawnRot;
		//dir+=Vector2.Down.Angle();
		//damage=1f;
		//penetrable=2;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
/*	public override void _Process(double delta)
	{
		Velocity=new Vector2(0,-speed).Rotated(dir)+Vector2.Right;
		MoveAndSlide();
	}

	public void _on_timer_timeout()
	{
		QueueFree();
	}
	public void _on_area_2d_body_entered(Node2D bullet)
	{

		
		
		if(bullet.GetType()!=new Player().GetType())
		{
			penetration--;
			if(penetration<0) QueueFree();
		}
	}*/
}
