using Godot;
using System;

public partial class Rang : ProjectilePlayer
{
	//public float dir {get;set;} 
	public Player player;
	public Boomerang boomerang;
	public Sprite2D sprite;
	public override void _Ready()
	{
		base._Ready();
		sprite=GetChild<Sprite2D>(2);
	}
	public override void _Process(double delta)
	{
		sprite.Rotate(1);
		if(Position.DistanceTo(player.Position)>5000) Despawn();
		if(penetrable>0)
			{
			Velocity=new Vector2(0,-stats.speed).Rotated(dir)+Vector2.Right;
			MoveAndSlide();
			}else
			{
			Vector2 dir2= Position.DirectionTo(player.Position);//*speed;
			MoveAndCollide(dir2*stats.speed*(float)delta);
			stats.speed++;
			if(GlobalPosition==player.GlobalPosition) Despawn();
			}
		

		
	}
	public override void Despawn()
	{
		boomerang.rangs++;
		QueueFree();
	}
	public override void _on_timer_timeout()
	{
		penetrable=0;
	}
	override public void _on_area_2d_body_entered(Node2D bullet)
	{
		GD.Print(bullet.GetType());
		if(stats.penetrationInf==false){
		
		if(bullet.GetType().IsAssignableTo(new Player().GetType()) && penetrable<=0)
		{
			Despawn();
			//GD.Print(penetrable+"/"+stats.penetration);
			
		}
		if(bullet.GetType().IsAssignableTo(new EnemyBasic().GetType()))
		{
			penetrable--;
			GD.Print(penetrable+"/"+stats.penetration);
			
		}
		}
	}
}
