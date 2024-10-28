using Godot;
using System;

public partial class BossWallSpike : StaticBody2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		polygon2D=GetChild<CollisionPolygon2D>(0);
	}
	CollisionPolygon2D polygon2D;
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
	public void _on_area_2d_body_entered(Node2D node)
	{
		if(node.IsInGroup("Player")){
			var p=node as Player;
			p.hp-=10;
			p.Velocity*=-10f;
		 //node.Position+=(Position.DirectionTo(node.Position)*500);
		 }
	}
}
