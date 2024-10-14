using Godot;
using System;
using System.ComponentModel;

public partial class PickableBasic : StaticBody2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}
	public bool Picked=false;
	public Player player;
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(Picked){
			Vector2 dir= Position.DirectionTo(player.Position);//*speed;
		MoveAndCollide(dir*300f*(float)delta);
		}
	}
	public virtual void player_near(Area2D area)
	{
		var p=area.GetParent();
		if(p.GetType().IsAssignableTo(new Player().GetType()))
		{
			Picked=true;
			player=p as Player;
		}
		
	}
	public virtual void picked(Area2D area)
	{
		var p=area.GetParent();
		if(p.GetType().IsAssignableTo(new Player().GetType()))
		{
		QueueFree();
		}
	}
}
