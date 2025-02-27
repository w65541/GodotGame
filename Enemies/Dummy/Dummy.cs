using Godot;
using System;

public partial class Dummy : EnemyBasic
{
	
	public override void _Ready()
	{
		//player=(Player) GetTree().GetFirstNodeInGroup("Player");
		
		
		stats=new Stats{maxHp=5f*difficulty,speed=200f,speedMove=80f};
		hp=stats.maxHp;
		//Velocity=Position.DirectionTo(player.Position)*speed;
		//MoveAndSlide();
	}
	public override void _PhysicsProcess(double delta)
	{
		
	}
}
