using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class Shotgun : Weapon
{//TODO template to//
	// Node main;
	//PackedScene  projectile;
	//String bulletType;
	 //float r=100.0f;
	 //int count=5;
	// Called when the node enters the scene tree for the first time.
	//public int level=1;
	public override void _Ready()
	{
		//main= GetTree().Root.GetNode("Main");
		bulletType="ShotgunBullet";
		targeting=Targeting.Mouse;
		stats=new Stats{
			damage=1f,
			count=3,
			penetrationInf=false,
			penetration=2,
			cooldown=0.5f,
			durationMult=1,
			fireRate=1,
			speed=5000f
		};
		GD.Print(stats.penetration);
		data=new itemData{
			name="Shotgun",
			level=2,
			opis="afdgsdg",
			sprite="res://Items/Textures/Shotgun.png",
			scene=""
		};
		//baseStats=stats;
		base._Ready();
		//projectile=GD.Load<PackedScene>("res://ShotgunBullet.tscn");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	/*public override void _Process(double delta)
	{
		var pPosition=(Vector2)player.Position;
		var ang=(pPosition.AngleToPoint(GetGlobalMousePosition()));
		Rotation=ang;
		Position=new Vector2{
			Y=((float)Math.Sin(ang))*r,
			X=((float)Math.Cos(ang))*r
		};
	}
*/
    public override void Shoot()
	{
		var instance = projectile.Instantiate() as ShotgunBullet;
		var rng=new RandomNumberGenerator().RandfRange(-0.25f,0.25f);
		instance.dir =Rotation+rng;
		//instance.speed=5000;
		instance.spawnPos=GlobalPosition;
		instance.stats=stats;
		GD.Print(instance.stats.penetration+"/"+stats.penetration);
		//GD.Print("ShootRotate"+Rotation);
		instance.spawnRot=Rotation+rng;
		main.AddChild(instance);
	}

	public override void levelup()
    {
        level++;
		data.level++;
		switch(level)
		{
			case 2:
			baseStats.penetration++;
			updateStats();
			break;
			case 3:
			baseStats.penetrationInf=true;
			updateStats();
			break;
			case 4:
			
			break;
			case 5:
			
			break;
			case 6:
			
			break;
			case 7:
			
			break;
		}
    }
/*	public void _on_timer_timeout()
	{
		for (int i = 0; i < stats.count; i++)
		{
			Shoot();
		}		
		 
	}*/
}
