using Godot;
using System;

public partial class EnemyBullet : CharacterBody2D
{
	public float dir {get;set;} 
	public Vector2 spawnPos{get;set;} 
	public float spawnRot{get;set;} 
	//public float damage {get;set;} 
	public int penetrable;
	public  Stats stats;
	public Timer Cooldown;
	public float stop=1f;
	public override void _Ready()
	{
		Scale*=stats.size;
		GlobalPosition=spawnPos;
		GlobalRotation=spawnRot+Vector2.Down.Angle();
		//GD.Print("rotate"+GlobalRotation);
		//Rotation=spawnRot;
		dir+=Vector2.Down.Angle();
		penetrable=stats.penetration;
		Cooldown= (Timer)GetNode("Timer");
		Cooldown.WaitTime=stats.duration*stats.durationMult+0.01f;
		Cooldown.Start();
		//GD.Print(stats.penetration);
	}
		public override void _PhysicsProcess(double delta)
	{
		
		Velocity=(new Vector2(0,-stats.speed).Rotated(dir)+Vector2.Right);
		MoveAndSlide();
	}
	virtual public void Despawn()
	{
		QueueFree();
	}
	virtual public void _on_timer_timeout()
	{
		Visible=false;
		Despawn();
	}
	virtual public void _on_area_2d_body_entered(Node2D bullet)
	{
		GD.Print(bullet.GetType());
		if(bullet.GetType().IsAssignableTo(new wall().GetType()) || bullet.GetType().IsAssignableTo(new Player().GetType())){
			GD.Print("wall");
			Despawn();
			}
	}
}
