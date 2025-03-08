using Godot;
using System;

public partial class trooper : Player
{
	PackedScene specialObject;
	public String startingWeapon="Shotgun";
	//public Timer SpecialCooldown;
	int dodgeframes=10;
	public override void _Ready()
	{
		SpecialCooldown= (Timer)GetNode("CooldownSpecial");
		DodgeCooldown= (Timer)GetNode("CooldownDodge");
		setLeveledStats();
		baseStats=stats;
		updateStats();

		GD.Print(stats.damageMult);
		var ps=GD.Load<PackedScene>("res://Weapons/Bombardment/Bombardment.tscn");//("res://Weapons/Shotgun.tscn");
		AddChild(ps.Instantiate());
		specialObject=GD.Load<PackedScene>("res://Weapons/Special/explosion.tscn");
		specialReady=true;
		//main=(Main) GetTree().Root.GetNode("Main");
		base._Ready();
	}
	public override void setLeveledStats(){
		try
	{
		level=GetTree().Root.GetChild<Core>(0).unlocked[0].level;
	}
	catch (System.Exception)
	{
		
		level=1;
	}
		float mult= (float)(level *0.1+1);
		stats=new Stats{
		maxHp=100.0f*mult,
		speed=500f,
		speedMove=500f,
		cooldown=5f,
		penetration=0,
		damageMult=mult
		};
		baseStats=stats;
	}
	public override void _PhysicsProcess(double delta)
	{
		
		if (Input.IsActionJustPressed("ui_accept") && dodge && Speed<stats.speed*stats.speedMult)
			{Speed=stats.speed*stats.speedMult;}
		
	base._PhysicsProcess(delta);
			if (Input.IsActionJustPressed("ui_special") && specialReady)
			{
				specialReady=false;
				special();
			}
			if(dodgeframes<10){
				dodgeframes++;
				Velocity*=5;
			}
			if (Input.IsActionJustPressed("ui_accept") && dodge)
			{Velocity *= 10;
			dodge=false;
			unstopable=true;
			dodgeframes=0;
			DodgeCooldown.Start();
			}
			MoveAndSlide();
	}
	public void CooldownSpecial()
	{
		specialReady=true;
	}
	public void special()
	{
		var instance = specialObject.Instantiate() as explosion;
		instance.spawnPos=GlobalPosition;
		//GD.Print("ShootRotate"+Rotation);
		instance.spawnRot=Rotation;
		instance.damage=100f;
		instance.Scale*=10f;
		GetParent().CallDeferred("add_child",instance);
		SpecialCooldown.Start();
	}
}
