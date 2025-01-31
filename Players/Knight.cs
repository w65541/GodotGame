using Godot;
using System;

public partial class Knight : Player
{
	public bool chargeReady=true;//false ładowanie 
	public bool horse=false,charging=false;
	Timer SpeedCooldown;
	Timer ChargeTime;
	Texture2D normalSprite =(Texture2D) GD.Load("res://Players/Textures/Knightwide.png");
	Texture2D chargingSprite =(Texture2D) GD.Load("res://Players/Textures/Knight2.png");
	Sprite2D sprite;
	public override void _Ready()
	{
		DodgeCooldown= (Timer)GetNode("CooldownDodge");
		SpeedCooldown= (Timer)GetNode("SpeedBoost");
		ChargeTime= (Timer)GetNode("Chargetime");
		stats=new Stats{
		maxHp=100.0f,
		speed=500f,
		speedMove=500f,
		cooldown=5f,
		penetration=0
		};
		baseStats=stats;
		updateStats();
		dodge=true;
		sprite=GetChild<Sprite2D>(2);
		var ps=GD.Load<PackedScene>("res://Weapons/Lance/Lance.tscn");
		AddChild(ps.Instantiate());
		
		main=(Main) GetTree().Root.GetNode("Main");
	}



	public override void _PhysicsProcess(double delta)
	{
		if (Input.IsActionJustPressed("ui_accept") && dodge && !horse)
		{dodge=false;
		horseOn();}
		if (Input.IsActionJustPressed("ui_special") && chargeReady)
		{
			chargeReady=false;
			charge();
		}
		if(horse)Speed=stats.speed*stats.speedMult*10f;
		base._PhysicsProcess(delta);
		MoveAndSlide();
	}
	public void horseOn(){
		horse=true;
		unstopable=true;
		Speed*=10;
		SpeedCooldown.Start();
		GD.Print("horseOn");
		sprite.Texture=chargingSprite;
	}
	public void horseOff(){
		horse=false;
		unstopable=false;
		updateStats();
		DodgeCooldown.Start();
		GD.Print("horseOff");
		sprite.Texture=normalSprite;
	}
	public void charge(){
		horse=true;
		charging=true;
		ChargeTime.Start();
		GD.Print("ChargeOn");
		sprite.Texture=chargingSprite;
	}
	public override void updateStats()
	{
		base.updateStats();
		if(horse)Speed*=10;
	}
	public void _on_speed_boost_timeout()
	{
		horseOff();
	}

	public void _on_chargetime_timeout()
	{
		sprite.Texture=normalSprite;
		horse=false;
		charging=false;
		GD.Print("Chargeoff");
	}
	public void _on_cooldown_dodge_timeout(){dodge=true;}
	public void _on_charge_body_entered(Node2D node)
	{
		if(node.GetType().IsAssignableTo(new EnemyBasic().GetType()) && charging)
		{
			EnemyBasic enemy=(EnemyBasic)node;
			 enemy.Position+=(Position.DirectionTo(enemy.Position)*500);
			
		}
	}
}
