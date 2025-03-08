using Godot;
using System;

public partial class spawner_basic : Node2D
{
	public Player player;
	public PackedScene enemy;
	public BasicLevel main;
	[Export] public int spawnCount;
	[Export] public int spawnIncrise;
	[Export] public float difficulty=1f;
	[Export] public string enemyType;
	[Export]public string texures;
	[Export] public int texturenumber=1;
	[Export] public bool randomColor;
	[Export] public float brightness=1f;
	[Export] public bool lockX=false;
	[Export] public bool lockY=false;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
		main= GetTree().GetFirstNodeInGroup("Main") as BasicLevel;
		enemy=GD.Load<PackedScene>(enemyType);
		//spawnCount=5;
	}

	
	public virtual void spawnEnemy()
	{
		if(main.activeEnemies<100){
		var r=700f;
		var instance = enemy.Instantiate() as EnemyBasic;
		instance.difficulty=difficulty;
		var rng=new RandomNumberGenerator().RandfRange(0f,6f);
		Position=new Vector2{
			Y=((float)Math.Sin(rng))*r,
			X=((float)Math.Cos(rng))*r
		};
		if(lockX) GlobalPosition=new Vector2(0,GlobalPosition.Y);
		if(lockY) GlobalPosition=new Vector2(GlobalPosition.X,0);
		if(randomColor)instance.Modulate=Color.FromHsv(new RandomNumberGenerator().RandfRange(0f,359f),1f,brightness);
		//instance.Scale=new Vector2(new RandomNumberGenerator().RandfRange(0.9f,1.1f),new RandomNumberGenerator().RandfRange(0.9f,1.1f));
		instance.GetChild<Sprite2D>(1).Texture=(Texture2D) GD.Load(texures+new RandomNumberGenerator().RandiRange(1,texturenumber)+".png"); 
		instance.spawnPos=GlobalPosition;
		//GD.Print("ShootRotate"+Rotation);
		main.activeEnemies++;
		main.AddChild(instance);
}
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
