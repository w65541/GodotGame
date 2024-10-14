using Godot;
using System;
using System.Collections;
using System.Collections.Generic;
public partial class OrbitalLaser : ProjectilePlayer
{
	
	// Get the gravity from the project settings to be synced with RigidBody nodes.
	
	public List<EnemyBasic> enemies=new List<EnemyBasic>();
	
	AnimatedSprite2D sprite;
	Sprite2D spriteTEMP;
	public override void _PhysicsProcess(double delta)
	{
		base._PhysicsProcess(delta);
		if(enemies.Count>0) enemies.ForEach(x=> x.hp-=stats.damage*stats.damageMult);
	}
public override void _Ready()
	{
		Timer time=GetChild<Timer>(2);
		time.WaitTime=stats.duration*stats.durationMult+0.1f;
		time.Start();
		base._Ready();
	}
	override public void _on_timer_timeout()
	{
		Visible=false;
		QueueFree();
	}
	public override void _on_area_2d_body_entered(Node2D node)
	{
		if(node.GetType().IsAssignableTo(new EnemyBasic().GetType()))
		{
			enemies.Add(node as EnemyBasic);
		}
	}
public void _on_area_2d_body_exited(Node2D node)
{
	if(node.GetType().IsAssignableTo(new EnemyBasic().GetType()))
		{
			enemies.Remove(node as EnemyBasic);
		}
}
}
