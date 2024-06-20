using Godot;
using System;

public partial class EnemyBasic : CharacterBody2D
{
	public Stats stats;
	public float hp=5f;
	//float speed=80f;
	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
Player player;
Main main;
public Vector2 spawnPos{get;set;} 
	public override void _Ready()
	{
		player=(Player) GetTree().Root.GetNode("Main").GetNode("Player");
		main=(Main) GetTree().Root.GetNode("Main");
		GlobalPosition=spawnPos;
		stats=new Stats{maxHp=5f,speed=80f,speedMove=80f};
		//Velocity=Position.DirectionTo(player.Position)*speed;
		//MoveAndSlide();
	}
	public override void _PhysicsProcess(double delta)
	{
		
		if(hp<=0)Death();
		//if(Position.DistanceTo(player.Position)>1000) Despawn();
		//player=(Player) GetTree().Root.GetNode("Node2D").GetNode("Player");
		//Velocity=
		Vector2 dir= Position.DirectionTo(player.Position);//*speed;
		MoveAndCollide(dir*stats.speed*(float)delta);
		//MoveAndSlide();
	}
public void Death(){
	main.Score++;
	QueueFree();
}
public void Despawn(){
	QueueFree();
}
public void _on_area_2d_body_entered(Node2D bullet)
	{
if(bullet.GetType()==new explosion().GetType())
		{
			var x=(explosion) bullet;
			hp-=x.damage;
			GD.Print("hp: "+hp);
		}
		if(bullet.GetType().IsAssignableTo(new ProjectilePlayer().GetType()))
		{
			var x=(ProjectilePlayer) bullet;
			hp-=x.stats.damage;
		}
		//GD.Print(bullet.GetType());
		/*if(bullet.GetType()==new ShotgunBullet().GetType())
		{
			var x=(ShotgunBullet) bullet;
			hp-=x.stats.damage;
			//GD.Print("hp: "+hp);
		}
		
		if(bullet.GetType()==new rocket().GetType())
		{
			var x=(rocket) bullet;
			hp-=x.stats.damage;
			//GD.Print("hp: "+hp);
		}*/
	}
	
}
