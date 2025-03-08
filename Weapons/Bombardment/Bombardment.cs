using Godot;
using System;

public partial class Bombardment : Weapon
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		bulletType="Rang";
		targeting=Targeting.Random;
		stats=new Stats{
			damage=20f,
			count=2,
			penetrationInf=false,
			penetration=2,
			cooldown=5f,
			durationMult=1,
			fireRate=1,
			speed=200f,
			size=5f,
			duration=2f
		};
		r= 00f;
		//GD.Print(stats.penetration);
		data=new itemData{
			name="Bombardment",
			level=2,
			opis="Zwieksza ilosc wybuchow o 2",
			sprite="res://Items/Textures/bomb.png",
			scene=""
		};
		projectile=GD.Load<PackedScene>("res://Weapons/Bombardment/Projectile/Bombard.tscn");
		
		base._Ready();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		base._Process(delta);
	}
	public override void levelup()
	{
		level++;
		data.level++;
		switch(level)
		{
			case 2:
			baseStats.count+=2;
			updateStats();
			data.opis="Zwieksza wielkosc o 50%";
			break;
			case 3:
			baseStats.size=1.5f;
			updateStats();
			
			data.opis="Zwieksza obrazenia o 10";
			break;
			case 4:
			baseStats.damage=30f;
			data.opis="Zwieksza ilosc wybuchow o 2";
			updateStats();
			break;
			case 5:
			baseStats.count+=2;
			data.opis="Zmniejsza przerwe ataku do 2,5s";
			updateStats();
			break;
			case 6:
			baseStats.cooldown=2.5f;
			data.opis="Aktywuje laser ktory zadaje obrazenia przez caly czas";
			updateStats();
			break;
			case 7:
			stats.duration=10f;
			projectile=GD.Load<PackedScene>("res://Weapons/Bombardment/Projectile/OrbitalLaser.tscn");
			updateStats();
			break;
		}
	}
public override void _on_timer_timeout()
	{
		Shoot();
		Cooldown.WaitTime=stats.cooldown*stats.fireRate;
		Cooldown.Start();
	}

	public override void Shoot()
	{
		var enemies=GetTree().GetNodesInGroup("Enemy");
		if(enemies.Count>0)
			{
		var instance = projectile.Instantiate() as Bombard;
		
		instance.stats=stats;
		
		int rng1=new RandomNumberGenerator().RandiRange(0,enemies.Count-1);
		int rng2=(rng1+10)%enemies.Count;
		//GD.Print(instance.stats.penetration+"/"+stats.penetration);
		//GD.Print("ShootRotate"+Rotation);
		
		Node2D temp1=enemies[rng1] as Node2D;
		Node2D temp2=enemies[rng2] as Node2D;
		var dire=temp1.GlobalPosition.AngleTo(temp2.GlobalPosition);
		instance.spawnPos=temp1.GlobalPosition;
		instance.spawnRot=dire;
		instance.dir =dire;
		main.AddChild(instance);
			}
	}
	
}
