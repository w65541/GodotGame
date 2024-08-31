using Godot;
using System;

public partial class Knight : Player
{
	public bool chargeReady=true;//false ładowanie 
	public bool horse=false,charging=false;
	Timer SpeedCooldown;
	Timer ChargeTime;
	public override void _Ready()
	{
		DodgeCooldown= (Timer)GetNode("CooldownDodge");
		SpeedCooldown= (Timer)GetNode("SpeedBoost");
		ChargeTime= (Timer)GetNode("Chargetime");
		stats=new Stats{
		maxHp=100.0f,
		speed=200f,
		speedMove=200f,
		cooldown=5f,
		penetration=0
		};
		baseStats=stats;
		updateStats();
		dodge=true;
		
		var ps=GD.Load<PackedScene>("res://Weapons/Flamet/Flamet.tscn");//("res://Weapons/Lance/Lance.tscn");
		AddChild(ps.Instantiate());
		
		//main=(Main) GetTree().Root.GetNode("Main");
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
	}
	public void horseOff(){
		horse=false;
		unstopable=false;
		updateStats();
		DodgeCooldown.Start();
		GD.Print("horseOff");
	}
	public void charge(){
		horse=true;
		charging=true;
		ChargeTime.Start();
		GD.Print("ChargeOn");
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
