using Godot;
using System;

public partial class Lance : Weapon
{
	public PackedScene  projectile2;public PackedScene  projectile3;
	Timer nextAttack;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		nextAttack=GetChild<Timer>(1);
		bulletType="Slash";
		projectile2=GD.Load<PackedScene>("res://Weapons/Lance/Projectile/Slash.tscn");
		projectile3=GD.Load<PackedScene>("res://Weapons/Lance/Projectile/Stab.tscn");
		targeting=Targeting.Mouse;
		stats=new Stats{
			damage=5f,
			count=4,
			penetrationInf=true,
			penetration=2,
			cooldown=4f,
			durationMult=1,
			duration=0.2f,
			fireRate=1,
			speed=0f
		};
		r=200f;
		//GD.Print(stats.penetration);
		data=new itemData{
			name="Lanca",
			level=2,
			opis="Zmniejsza przerwe ataku do 3s",
			sprite="res://Items/Textures/lanca.png",
			scene=""
		};
		base._Ready();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	
	int remaining;
	public override void _on_timer_timeout()
	{
		if(nextAttack.TimeLeft==0){
			GetChild<AudioStreamPlayer>(2).Play();
		remaining=1;
		Shoot();}
	}

	public override void levelup()
    {
		level++;
		data.level++;
		switch(level)
		{
			case 2:
			baseStats.cooldown=3f;
			updateStats();
			data.opis="Zwieksza ilosc pociskow o 1";
			break;
			case 3:
			baseStats.count++;
			updateStats();
			data.opis="Zwieksza pbrazenia o 2";
			break;
			case 4:
			baseStats.damage=7f;
			updateStats();
			data.opis="Zwieksza ilosc pociskow o 1";
			break;
			case 5:
			baseStats.count++;
			updateStats();
			data.opis="Zwieksza pbrazenia o 3";
			break;
			case 6:
			baseStats.damage=10f;
			updateStats();
			data.opis="Zwieksza ilosc pociskow o 1 i podwaja rozmiar";
			break;
			case 7:
			baseStats.count++;
			baseStats.size=2f;
			updateStats();
			break;
		}
	}


	public override void Shoot()
	{
		if (remaining<=stats.count)
		{
			switch(remaining%3)
			{
				case 1:
				
				GD.Print(projectile2.ResourcePath);
						var instance = projectile2.Instantiate() as Slash;
						instance = projectile2.Instantiate() as Slash;
						GD.Print(projectile2.Instantiate() as Slash);
						instance.dir =Rotation;
						instance.spawnPos=GlobalPosition;
						instance.stats=stats;
						instance.spawnRot=Rotation+10f;
						main.AddChild(instance);
						remaining++;
						
				break;
				case 2:
				
						var instance2 = projectile2.Instantiate() as Slash;
						instance2.dir =Rotation;
						instance2.spawnPos=GlobalPosition;
						instance2.stats=stats;
						instance2.spawnRot=Rotation-20f;
						main.AddChild(instance2);
						remaining++;
						
				break;
				case 0:
				
						var instance3 = projectile3.Instantiate() as Stab;
						instance3.dir =Rotation;
						instance3.spawnPos=GlobalPosition;
						instance3.stats=stats;
						instance3.spawnRot=Rotation;
						main.AddChild(instance3);
						remaining++;
						
				break;
			}
			if (remaining<=stats.count) nextAttack.Start();
		}
		
		
	}
}
