using Godot;
using System;
using System.Collections;
using System.Collections.Generic;

public partial class Bombard : ProjectilePlayer
{
	

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	
	public List<EnemyBasic> enemies=new List<EnemyBasic>();
	
	AnimatedSprite2D sprite;
	Sprite2D spriteTEMP;
	public override void _PhysicsProcess(double delta)
	{
		base._PhysicsProcess(delta);
	}
public override void _Ready()
	{
		sprite=GetChild<AnimatedSprite2D>(2);
		spriteTEMP=GetChild<Sprite2D>(4);
		base._Ready();
		//_on_timer_timeout();
	}
	override public void _on_timer_timeout()
	{
		//sprite.Visible=true;
		spriteTEMP.Visible=true;
		//sprite.Play();
		enemies.ForEach(x=> x.hp-=stats.damage*stats.damageMult);
		//sprite.Stop();
		sprite.Visible=false;
		penetrable--;
		GD.Print("Bombardment: "+penetrable+"/"+stats.penetration);
		spriteTEMP.Visible=false;
		if(penetrable>=0)Despawn();
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
