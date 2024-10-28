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
		stats=new Stats{
		maxHp=100.0f,
		speed=500f,
		speedMove=500f,
		cooldown=5f,
		penetration=0
		};
		baseStats=stats;
		updateStats();

		GD.Print(stats.damageMult);
		var ps=GD.Load<PackedScene>("res://Weapons/Shotgun.tscn");
		AddChild(ps.Instantiate());
		specialObject=GD.Load<PackedScene>("res://Weapons/Special/explosion.tscn");
		specialReady=true;
		//main=(Main) GetTree().Root.GetNode("Main");
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
