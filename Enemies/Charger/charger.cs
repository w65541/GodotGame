using Godot;
using System;

public partial class charger : EnemyBasic
{
	bool readyToCharge=true;
	public override void _Ready()
	{
		base._Ready();
		stats.maxHp=500f;
		hp=stats.maxHp;
		stats.speed=100f;
		stats.damage=10f;
	}
	public override void _PhysicsProcess(double delta)
	{
		if(hp<=0)Death();
		
		
		player=(Player) GetTree().GetFirstNodeInGroup("Player");
		main=(BasicLevel) GetTree().GetFirstNodeInGroup("Main");
		Vector2 dir= Position.DirectionTo(player.Position);//*speed;
		//GD.Print(dir.ToString());
		if(Position.DistanceTo(player.Position)>1000) 
		{
			readyToCharge=true;
			stats.speed=100f;
		}
		if(readyToCharge)
		{
			if(stats.speed<1000f)stats.speed+=5f;
			MoveAndCollide(dir*stats.speed*(float)delta);
		}else{
			MoveAndCollide(dir*-1000f*(float)delta);
		}
		
		/*if(GlobalPosition.AngleTo(player.GlobalPosition)<Rotation)
		{
			Rotation++;
		}//else{Rotation--;}
		Velocity=Transform.X*stats.speed;
		MoveAndSlide();
		//MoveAndCollide(Transform.X*stats.speed);//((dir*stats.speed*(float)delta));*/
		
		MoveAndCollide(dir*stats.speed*(float)delta);
	}

	public override void _on_area_2d_body_entered(Node2D bullet)
	{
		//GD.Print("ENTER "+bullet.Name+" "+bullet.GetType());
		if(bullet.GetType().IsAssignableTo(new Player().GetType()) && readyToCharge)
		{
			player.hp-=stats.damage;
			//hp-=x.damage;
			GD.Print("Hit player"+hp);
			readyToCharge=false;
		}
		if(bullet.GetType()==new explosion().GetType())
		{
			var x=(explosion) bullet;
			hp-=x.damage;
			GD.Print("hp: "+hp);
		}
		if(bullet.GetType().IsAssignableTo(new ProjectilePlayer().GetType()))
		{
			GD.Print(readyToCharge);
			if(readyToCharge)
			{
				var x=(ProjectilePlayer) bullet;
			hp-=(x.stats.damage*x.stats.damageMult);
			
			stats.speed-=100f;
			if(stats.speed<0)stats.speed=1f;
			}
		}
	}

	public void _on_area_2d_area_entered(Area2D area2D)
	{
		
		var z=area2D.GetParent();
		if(z.GetType().IsAssignableTo(new Player().GetType()) && readyToCharge)
		{
			player.hp-=stats.damage;
			//hp-=x.damage;
			GD.Print("Hit player"+hp);
			readyToCharge=false;
			return;
		}
		if(z.GetType().IsAssignableTo(new ProjectilePlayer().GetType()))
		{
			GD.Print(readyToCharge);
			if(readyToCharge)
			{
				var x=(ProjectilePlayer) z;
			hp-=(x.stats.damage*x.stats.damageMult);
			
			stats.speed-=100f;
			if(stats.speed<0)stats.speed=1f;
			}
		}
	}
}
