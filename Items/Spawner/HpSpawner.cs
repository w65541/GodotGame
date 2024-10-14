using Godot;
using System;

public partial class HpSpawner : Node2D
{
	PackedScene pack;
	Node main;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
		main= GetTree().GetFirstNodeInGroup("Main");
		pack=GD.Load<PackedScene>("res://Items/Pickable/Hpack/hpack.tscn");
		//spawnCount=5;
		///D.Print("ReadyHp");
	}

	public void _on_timer_timeout()
	{
		var r=700f;
		var instance = pack.Instantiate() as Node2D;
		var rng=new RandomNumberGenerator().RandfRange(0f,6f);
		Position=new Vector2{
			Y=((float)Math.Sin(rng))*r,
			X=((float)Math.Cos(rng))*r
		};
		instance.GlobalPosition=GlobalPosition;
		//GD.Print("ShootRotate"+Rotation);
		
		main.AddChild(instance);
		//GD.Print("HpAdd");
	}
}
