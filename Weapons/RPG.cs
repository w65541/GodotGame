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
			cooldown=7f,
			durationMult=1,
			fireRate=1,
			speed=500f
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
			sprite="res://Items/Textures/Rakieta.png",
			scene="res://Weapons/rpg.tscn"
		};
		base._Ready();
	}
	public override void levelup()
    {
        level++;
		data.level++;
		switch(level)
		{
			case 2:
			baseStats.count++;
			baseStats.cooldown=1.5f;
			data.opis="Zwieksza rozmiar o 20%";
			updateStats();
			break;
			case 3:
			baseStats.count++;
			baseStats.penetration++;
			baseStats.size=1.2f;
			data.opis="Zmniejsza przerwe ataku do 1s";
			updateStats();
			break;
			case 4:
			baseStats.count++;
			baseStats.cooldown=1f;
			data.opis="Zwieksza rozmiar o 50%";
			updateStats();
			break;
			case 5:
			baseStats.count++;
			baseStats.penetration++;
			baseStats.size=1.5f;
			data.opis="Zwieksza obrazenia o 4";
			updateStats();
			break;
			case 6:
			baseStats.count++;
			baseStats.damage=5f;
			data.opis="Nieskonczona penetracja pociskow";
			updateStats();
			break;
			case 7:
			baseStats.count++;
			baseStats.penetrationInf=true;
			
			updateStats();
			break;
		}
    }
	public override void Shoot()
	{
		GetChild<AudioStreamPlayer>(1).Play();
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

