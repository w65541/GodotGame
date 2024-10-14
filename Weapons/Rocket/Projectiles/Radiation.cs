using Godot;
using System;
using System.Collections;
using System.Collections.Generic;

public partial class Radiation : Area2D
{
	public Stats stats;
	bool active=true;
	public List<EnemyBasic> enemies=new List<EnemyBasic>();
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Timer time=GetChild<Timer>(2);
		time.WaitTime=stats.duration*stats.durationMult+0.1f;
		time.Start();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(active && enemies.Count>0)
		{
			enemies.ForEach(x=> x.hp-=stats.damage*stats.damageMult*0.1f);
		}
	}
	public void _on_body_entered(Node2D node)
	{
		if(node.GetType().IsAssignableTo(new EnemyBasic().GetType()))
		{
			enemies.Add((EnemyBasic)node);
		}
	}
	public void _on_body_exited(Node2D node)
	{
		if(node.GetType().IsAssignableTo(new EnemyBasic().GetType()))
		{
			enemies.Remove((EnemyBasic)node);
		}
	}
	public void _on_timer_timeout()
	{
		active=false;
		Visible=false;
		QueueFree();
	}
}
