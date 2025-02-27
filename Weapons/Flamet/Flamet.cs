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
			opis="Zwieksza czas pocisku o 1s",
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
			baseStats.duration=4f;
			updateStats();
			data.opis="Zwieksza predkosc pocisku o 30%";
			break;
			case 3:
			baseStats.speed=400f;
			updateStats();
			data.opis="Zwieksza obrazenia o 2";
			break;
			case 4:
			baseStats.damage=3f;
			updateStats();
			data.opis="Zwieksza czas pocisku o 1s";
			break;
			case 5:
			baseStats.duration=5f;
			updateStats();
			data.opis="Zwieksza predkosc pocisku o 60%";
			break;
			case 6:
			baseStats.speed=500f;
			updateStats();
			data.opis="Zmniejsza przerwe ataku do 3s";
			break;
			case 7:
			baseStats.cooldown=3f;
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
