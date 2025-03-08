using Godot;
using System;

public partial class ProjectilePlayer : CharacterBody2D
{
	//[Export] public float speed {get;set;} 
	public float dir {get;set;} 
	public Vector2 spawnPos{get;set;} 
	public float spawnRot{get;set;} 
	//public float damage {get;set;} 
	public int penetrable;
	public  Stats stats;
	public Timer Cooldown;
	public float stop=1f;
	// Called when the node enters the scene tree for the first time.
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

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
		Velocity=(new Vector2(0,-stats.speed).Rotated(dir)+Vector2.Right)*stop;
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
		//GD.Print(bullet.GetType());
		if(bullet.GetType().IsAssignableTo(new wall().GetType())){
			//GD.Print("wall");
			stop=0;
			}
		if(stats.penetrationInf==false){
		
		
		if(bullet.GetType().IsAssignableTo(new EnemyBasic().GetType()))
		{
			penetrable--;
			//GD.Print(penetrable+"/"+stats.penetration);
			if(penetrable<0) Despawn();
		}else{
			if(bullet.GetType().IsAssignableTo(new wall().GetType())){
				Despawn();
			}
		}
		}
	}
}