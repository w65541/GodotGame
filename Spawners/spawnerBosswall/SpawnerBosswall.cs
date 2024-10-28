using Godot;
using System;

public partial class SpawnerBosswall : spawner_basic
{
	
	public override void _Ready()
	{
		
		//main= GetTree().GetFirstNodeInGroup("Main") as BasicLevel;
		enemy=GD.Load<PackedScene>(enemyType);
		//spawnCount=5;
	}
	public override void spawnEnemy()
	{
		///
		player=GetTree().GetFirstNodeInGroup("Player") as Player;
		main=GetTree().GetFirstNodeInGroup("Main") as BasicLevel;
		///
		if(main.activeEnemies<100){
		var r=1f;
		var instance = enemy.Instantiate() as EnemyBasic;
		instance.difficulty=difficulty;
		var rng=new RandomNumberGenerator().RandfRange(-800f,800f);
		var point=GetParent().GetChild<Line2D>(30).Points[1];
		Position=new Vector2{
			Y=rng,
			X=point.X/2+175//Math.Abs(	GetParent<Node2D>().GlobalPosition.DistanceTo(	player.GlobalPosition))/9+50f
		};
		GD.Print(player.GlobalPosition+" "+GetParent<Node2D>().GlobalPosition);
		GD.Print(Position+" GP:"+GlobalPosition);
		instance.spawnPos=new Vector2{
			Y=rng,
			X=point.X//Math.Abs(	GetParent<Node2D>().GlobalPosition.DistanceTo(	player.GlobalPosition))/9+50f
		
		};//GlobalPosition;
		//GD.Print("ShootRotate"+Rotation);
		main.activeEnemies++;
		main.AddChild(instance);
		instance.GlobalPosition=GlobalPosition;
		}
	}
}
