using Godot;
using System;

public partial class Lightning : Weapon
{
	PackedScene follow;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		bulletType="ShotgunBullet";
		targeting=Targeting.Closest;
		stats=new Stats{
			damage=10f,
			count=2,
			penetrationInf=false,
			penetration=2,
			cooldown=4f,
			durationMult=1,
			fireRate=1,
			speed=5000f
		};
		
		data=new itemData{
			name="Lightning",
			level=2,
			opis="Zwiekszenie rozmiaru o 50%",
			sprite="res://Items/Textures/bolt.png",
			scene=""
		};
		projectile=GD.Load<PackedScene>("res://Weapons/Lightning/Projectile/Bolt.tscn");
		follow=GD.Load<PackedScene>("res://Weapons/Lightning/FollowBolt.tscn");
		
		//baseStats=stats;
		base._Ready();
		
	}
	public override void Shoot()
	{
		var path=new Path2D();
		path.Curve=new Curve2D();
		path.Curve.AddPoint(player.GlobalPosition);
		path.Curve.AddPoint(closest.position);
		for (int i = 1; i < stats.count+1; i++)
		{
			path.Curve.AddPoint(closest.position*1.5f*1);
		}
		var foll=follow.Instantiate() as LightingFollow;
		path.AddChild(foll);

		

		
		var instance = projectile.Instantiate() as Bolt;
		
		instance.dir =Rotation;
		//instance.speed=5000;
		instance.spawnPos=GlobalPosition;
		instance.stats=stats;
		instance.targetPos=closest.position;
		//GD.Print(instance.stats.penetration+"/"+stats.penetration);
		GD.Print("ShootRotate"+Rotation);
		instance.spawnRot=Rotation;
		foll.AddChild(instance);
		main.AddChild(path);
		GD.Print(GetTreeStringPretty());
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		//base._Process(delta);
	}
	public override void levelup()
    {
		level++;
		data.level++;
		switch(level)
		{
			case 2:
			baseStats.size=1.5f;
			updateStats();
			data.opis="Zwieksza ilosc o 1";
			break;
			case 3:
			baseStats.count++;
			updateStats();
			data.opis="Zwieksza obrazenia o 5";
			break;
			case 4:
			baseStats.damage=15f;
			updateStats();
			data.opis="Zwieksza ilosc o 1";
			break;
			case 5:
			baseStats.count++;
			updateStats();
			data.opis="Zmniejsza przerwe ataku do 2s";
			break;
			case 6:
			baseStats.cooldown=2f;
			updateStats();
			data.opis="Zwiekszenie rozmiaru o 50%";
			break;
			case 7:
			baseStats.size=2f;
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

}
