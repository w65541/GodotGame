using Godot;
using System;

public partial class rocket : ProjectilePlayer
{
	public PackedScene  projectile;
	public Node main;
	public override void _Ready()
	{
		base._Ready();
		//GlobalPosition=spawnPos;
		//GlobalRotation=spawnRot+Vector2.Down.Angle();
		//GD.Print("rotate"+GlobalRotation);
		//Rotation=spawnRot;
		//dir+=Vector2.Down.Angle();
		//damage=5f;
		main=GetTree().Root.GetNode("Main");
		
	}
	bool boom=true;
	public override void _on_area_2d_body_entered(Node2D bullet)
	{
		if(boom){
			boom=false;
		var instance = projectile.Instantiate() as explosion;
		instance.spawnPos=GlobalPosition;
		//GD.Print("ShootRotate"+Rotation);
		instance.spawnRot=Rotation;
		main.CallDeferred("add_child",instance);
		Visible=false;
		}
		
		base._on_area_2d_body_entered(bullet);
	}
	public  void _on_tree_exiting(){
		
	}
}
