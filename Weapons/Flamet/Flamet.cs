using Godot;
using System;

public partial class Flamet : Weapon
{
	// Called when the node enters the scene tree for the first time.
	Timer Tflame;
	bool flameOn=false;
	public override void _Ready()
	{
		Tflame=GetChild<Timer>(1);
		bulletType="Flame";
		targeting=Targeting.Mouse;
		stats=new Stats{
			damage=1f,
			count=3,
			penetrationInf=true,
			penetration=2,
			cooldown=5f,
			durationMult=1,
			duration=3f,
			fireRate=1,
			speed=300f
		};
		//GD.Print(stats.penetration);
		data=new itemData{
			name="Flamer",
			level=2,
			opis="afdgsdg",
			sprite="res://Items/Textures/Shotgun.png",
			scene=""
		};
		projectile=GD.Load<PackedScene>("res://Weapons/Flamet/Projectile/Flame.tscn");
		
		base._Ready();
	}

	public override void _Process(double delta)
	{
		base._Process(delta);

	}
	public void shootFlame()
	{
		if(!flameOn) return;
		var instance = projectile.Instantiate() as Flame;
		instance.dir =Rotation;
		//instance.speed=5000;
		instance.spawnPos=GlobalPosition;
		instance.stats=stats;
		//GD.Print(instance.stats.penetration+"/"+stats.penetration);
		//GD.Print("ShootRotate"+Rotation);
		instance.spawnRot=Rotation;
		main.AddChild(instance);
	}
	public override void levelup()
    {
		level++;
		data.level++;
		switch(level)
		{
			case 2:
			
			updateStats();
			break;
			case 3:
			baseStats.speed=400f;
			updateStats();
			break;
			case 4:
			baseStats.damage=3f;
			updateStats();
			break;
			case 5:
			baseStats.duration=5f;
			updateStats();
			break;
			case 6:
			baseStats.speed=500f;
			updateStats();
			break;
			case 7:
			
			updateStats();
			break;
		}
	}
	public override void _on_timer_timeout()
	{
		flameOn=true;
		GetChild<AudioStreamPlayer>(3).Play();
		Tflame.Start();
	}
	public void FlameEnd()
	{
		if(level<7){
			flameOn=false;
		Cooldown.Start();
		}
	}
}
