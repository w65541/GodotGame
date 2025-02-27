using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class RPG : Weapon
{
	//Node main;
	PackedScene  expl;
	//String bulletType;
	// float r=100.0f;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		targeting=Targeting.Closest;
		stats=new Stats{
			damage=1f,
			count=1,
			penetrationInf=false,
			penetration=2,
			cooldown=1f,
			durationMult=1,
			fireRate=1,
			speed=1000f
		};
		bulletType="rocket";
		//main= GetTree().Root.GetNode("Main");
		//projectile=GD.Load<PackedScene>("res://Weapons//Projectiles//rocket.tscn");
		expl=GD.Load<PackedScene>("res://Weapons/Special/explosion.tscn");
		projectile=GD.Load<PackedScene>("res://Weapons/Projectiles/"+bulletType+".tscn");
		data=new itemData{
			name="Rpg",
			level=2,
			opis="afdgsdg",
			sprite="res://Items/Textures/Shotgun.png",
			scene="res://Weapons/rpg.tscn"
		};
		base._Ready();
	}

	public override void Shoot()
	{
		closest._on_timer_timeout();
		var instance = projectile.Instantiate() as rocket;
		instance.dir =Rotation;
		instance.stats=stats;
		instance.spawnPos=GlobalPosition;
		GD.Print("Rakieta: ShootRotate"+Rotation);
		instance.spawnRot=Rotation;//Position.AngleToPoint(closest.Position);
		instance.projectile=expl;
		//instance.main=main;
		main.AddChild(instance);
	}
	/*public void _on_timer_timeout()
	{
		for (int i = 0; i < 1; i++)
		{
			Shoot();
		}		
		 
	}*/
	

}

