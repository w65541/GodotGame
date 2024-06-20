using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class RPG : Node2D
{
	Node main;
	PackedScene  projectile,expl;
	String bulletType;
	 float r=100.0f;
	 int count=5;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		main= GetTree().Root.GetNode("Main");
		projectile=GD.Load<PackedScene>("res://Weapons//Projectiles//rocket.tscn");
		expl=GD.Load<PackedScene>("res://Weapons/Special/explosion.tscn");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	/*	var pPosition=(Vector2)GetParent().Get(Node2D.PropertyName.Position);
		var ang=(pPosition.AngleToPoint(GetGlobalMousePosition()));
		Rotation=ang;
		Position=new Vector2{
			Y=((float)Math.Sin(ang))*r,
			X=((float)Math.Cos(ang))*r
		};*/
	}

	void Shoot()
	{
		var instance = projectile.Instantiate() as rocket;
		var e=Enemies.OrderBy(x=>Position.DistanceTo(x.Position)).First();
		instance.dir =Position.AngleToPoint(e.Position);
		instance.stats.speed=5000;
		instance.spawnPos=GlobalPosition;
		//GD.Print("ShootRotate"+Rotation);
		instance.spawnRot=Position.AngleToPoint(e.Position);
		instance.projectile=expl;
		//instance.main=main;
		main.AddChild(instance);
	}
	public void _on_timer_timeout()
	{
		for (int i = 0; i < 1; i++)
		{
			Shoot();
		}		
		 
	}
	List<Node2D> Enemies=new List<Node2D>();
	public void _on_area_2d_body_entered(Node2D node)
	{
		

		if(node.GetType()==new EnemyBasic().GetType())
		{
			//var e=(EnemyBasic)node;
			Enemies.Add(node);
			GD.Print(Enemies.Count);
		}
	}
	public void _on_area_2d_body_exited(Node2D node)
	{
		if(node.GetType()==new EnemyBasic().GetType())
		{
			var e=(EnemyBasic)node;
			Enemies.Remove(e);
			GD.Print(Enemies.Count);
		}
	}
}

