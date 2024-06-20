using Godot;
using System;

public partial class spawner_basic : Node2D
{
	Player player;
	PackedScene enemy;
	Node main;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		player=(Player) GetParent();
		main= GetTree().Root.GetNode("Main");
		enemy=GD.Load<PackedScene>("res://Enemies/Basic/enemy_basic.tscn");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void spawnEnemy()
	{
		var r=700f;
		var instance = enemy.Instantiate() as EnemyBasic;
		var rng=new RandomNumberGenerator().RandfRange(0f,6f);
		Position=new Vector2{
			Y=((float)Math.Sin(rng))*r,
			X=((float)Math.Cos(rng))*r
		};
		
		instance.spawnPos=GlobalPosition;
		//GD.Print("ShootRotate"+Rotation);
		
		main.AddChild(instance);

	}
	public void _on_timer_timeout()
	{
		for (int i = 0; i < 30; i++)
		{
			spawnEnemy();
		}		
		 
	}
}
