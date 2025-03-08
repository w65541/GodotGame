using Godot;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
public partial class Wizard : Player
{
	Timer specialtime;
	bool specialActive=false;
	Texture2D normalSprite =(Texture2D) GD.Load("res://Players/Textures/Wizard1.png");
	Texture2D chargingSprite =(Texture2D) GD.Load("res://Players/Textures/Wizard2.png");
	Sprite2D sprite;
	public override void _Ready()
	{specialtime= (Timer)GetNode("SpecialTime");
		setLeveledStats();
		baseStats=stats;
		sprite=GetChild<Sprite2D>(2);
		var ps=GD.Load<PackedScene>("res://Weapons/Lightning/Lightning.tscn");
		AddChild(ps.Instantiate());
		base._Ready();
	}

	public override void _PhysicsProcess(double delta)
	{
		if (Input.IsActionJustPressed("ui_special") && specialReady)
			{
				specialReady=false;
				special();
			}
		base._PhysicsProcess(delta);
		if (Input.IsActionJustPressed("ui_accept") && dodge)
			{
				dodge=false;
			DodgeCooldown.Start();
				teleport();
				}

		MoveAndSlide();
	}
public override void setLeveledStats(){
	try
	{
		level=GetTree().Root.GetChild<Core>(0).unlocked[2].level;
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
	public void special()
	{
		
		specialActive=true;
		sprite.Texture=chargingSprite;
		updateStats();
		specialtime.Start();
	}

	public void teleport()
	{
		var mous=GetGlobalMousePosition();
		Vector2 direction=GlobalPosition.DirectionTo(mous);
		if(GlobalPosition.DistanceTo(mous)>1000f)
		{
			GlobalPosition+=direction*1000f;
		}else{
			if(GlobalPosition.DistanceTo(mous)<100f)
			{
				GlobalPosition+=direction*100f;
			}else{
				GlobalPosition=mous;
			}
		}

	}
public override void updateStats()
	{
		stats=baseStats;
		var items=GetTree().GetNodesInGroup("Items"); 
		var weapons=GetTree().GetNodesInGroup("Weapons"); 
		foreach (BasicItem item in items.Cast<BasicItem>())
		{
			stats*=item.stats;
		}
		if(specialActive)stats.fireRate*=0.5f;
		foreach (Weapon item in weapons.Cast<Weapon>())
		{
			item.updateStats();
		}
		Speed=stats.speed*stats.speedMult;
	}

	public void _on_cooldown_special_timeout()
	{
		specialReady=true;
	}
	public void	_on_special_time_timeout(){
		specialActive=false;
		sprite.Texture=normalSprite;
		updateStats();
		SpecialCooldown.Start();
	}
}
