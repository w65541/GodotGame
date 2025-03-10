using Godot;
using System;
using System.Linq;

public partial class EnemyBasic : CharacterBody2D
{
	public Stats stats;
	public float hp=5f;
	public float difficulty;
	//float speed=80f;
	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
public Player player;
public BasicLevel main;
public Vector2 spawnPos{get;set;} 
	public override void _Ready()
	{
		player=(Player) GetTree().GetFirstNodeInGroup("Player");
		main=(BasicLevel) GetTree().GetFirstNodeInGroup("Main");
		GlobalPosition=spawnPos;
		stats=new Stats{maxHp=5f*difficulty,speed=230f,speedMove=80f};
		hp=stats.maxHp;
		//Velocity=Position.DirectionTo(player.Position)*speed;
		//MoveAndSlide();
	}
	public override void _PhysicsProcess(double delta)
	{
		
		if(hp<=0)Death();
		if(Position.DistanceTo(player.Position)>5000) Despawn();
		//player=(Player) GetTree().Root.GetNode("Node2D").GetNode("Player");
		//Velocity=
		Vector2 dir= Position.DirectionTo(player.Position);//*speed;
		MoveAndCollide(dir*stats.speed*(float)delta);
		//MoveAndSlide();
	}
public void Death(){
	main.exp+=(1+difficulty)*player.stats.expMult;
	main.deathcount++;
	main.activeEnemies--;
	var rng=new RandomNumberGenerator().RandiRange(1,100);
	if(rng<11){
		var instance=main.material.Instantiate<PickMaterial>();
		rng=new RandomNumberGenerator().RandiRange(0,main.materials.Count()-1);
		instance.name=main.materials[rng];
		instance.GlobalPosition=GlobalPosition;
		rng=new RandomNumberGenerator().RandiRange(1, (int)Math.Floor(difficulty));
		instance.amount=(long)Math.Floor(rng*player.stats.goldMult);
		main.AddChild(instance);
	}
	QueueFree();
}
public void Despawn(){
	main.activeEnemies--;
	QueueFree();
}
public virtual void _on_area_2d_body_entered(Node2D bullet)
	{
if(bullet.GetType()==new explosion().GetType())
		{
			var x=(explosion) bullet;
			hp-=x.damage;
			GD.Print("hp: "+hp);
		}
		if(bullet.GetType().IsAssignableTo(new ProjectilePlayer().GetType()))
		{
			var x=(ProjectilePlayer) bullet;
			hp-=(x.stats.damage*x.stats.damageMult);
		}
		//GD.Print(bullet.GetType());
		/*if(bullet.GetType()==new ShotgunBullet().GetType())
		{
			var x=(ShotgunBullet) bullet;
			hp-=x.stats.damage;
			//GD.Print("hp: "+hp);
		}
		
		if(bullet.GetType()==new rocket().GetType())
		{
			var x=(rocket) bullet;
			hp-=x.stats.damage;
			//GD.Print("hp: "+hp);
		}*/
	}
	
}
