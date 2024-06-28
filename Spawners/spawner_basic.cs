using Godot;
using System;

public partial class spawner_basic : Node2D
{
	Player player;
	PackedScene enemy;
	Node main;
	[Export] public int spawnCount;
	[Export] public int spawnIncrise;
	[Export] public float difficulty=1f;
	[Export] string enemyType;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		player=GetParent<Player>();
		main= GetTree().GetFirstNodeInGroup("Main");
		enemy=GD.Load<PackedScene>(enemyType);
		//spawnCount=5;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void spawnEnemy()
	{
		var r=700f;
		var instance = enemy.Instantiate() as EnemyBasic;
		instance.difficulty=difficulty;
		var rng=new RandomNumberGenerator().RandfRange(0f,6f);
		Position=new Vector2{
			Y=((float)Math.Sin(rng))*r,
			X=((float)Math.Cos(rng))*r
		};
		
		instance.spawnPos=GlobalPosition;
		//GD.Print("ShootRotate"+Rotation);
		
		main.AddChild(instance);

	}
	int timeElapsed=0;
	public void _on_timer_timeout()
	{
		
		for (int i = 0; i < spawnCount; i++)
		{
			spawnEnemy();
		}		
		 timeElapsed+=3;
		 if(timeElapsed%60==0)
		 {
			timeElapsed=0;
			spawnCount+=spawnIncrise;
			difficulty+=0.2f;
		 }
	}
}
