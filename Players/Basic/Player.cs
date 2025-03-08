using Godot;
using System;
using System.Linq;
using System.Runtime.CompilerServices;

public partial class Player : CharacterBody2D
{
	//[Export] Position;
	public  float Speed = 300.0f;
	public Timer SpecialCooldown;
	public bool unstopable=false;
	public bool dodge=true;
	public bool specialReady=false;
	public bool hold=false;
	public float hp=100f;
	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
	public Timer DodgeCooldown;
	 public Stats baseStats;
	 public Stats stats,shop;
	public BasicLevel main;
	public Area2D hitbox;
	public int level=1;
	
public override void _Ready()
	{
		
		DodgeCooldown= (Timer)GetNode("CooldownDodge");
		var core=GetTree().Root.GetChild<Core>(0) as Core;
		baseStats.maxHp*=((core.shopStatus["hp"]/10)+1);
		hp=baseStats.maxHp;
		baseStats.damage*=((core.shopStatus["damage"]/10)+1);
		baseStats.defense*=((core.shopStatus["defense"]/10)+1);
		baseStats.fireRate*=(1-(core.shopStatus["firerate"]/10));
		baseStats.durationMult*=((core.shopStatus["duration"]/10)+1);
		baseStats.speedMove*=((core.shopStatus["movespeed"]/10)+1);
		baseStats.speed*=((core.shopStatus["movespeed"]/10)+1);
		baseStats.expMult*=((core.shopStatus["expboost"]/10)+1);
		baseStats.goldMult*=((core.shopStatus["goldboost"]/10)+1);
		/*stats=new Stats{
		maxHp=100.0f,
		speed=200f,
		speedMove=200f,
		cooldown=5f,
		};*/
		//GD.Print(stats.fireRate);
		main=(BasicLevel) GetTree().GetFirstNodeInGroup("Main");
		//GD.Print(main.Score);
	}
	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		//GD.Print("Pos="+Position);
		//GD.Print(GetGlobalMousePosition().AngleToPoint(Position)*(180/Math.PI));
		// Add the gravity.
		//public override void _Ready() {
		//	base._Ready();
		//}
		hitbox=GetChild<Area2D>(3);
		if(hitbox.HasOverlappingBodies())hp-=touchCounter*basicEnemydameg;
		if(hp<=0) Death();
			
	//	if (Input.IsActionJustPressed("ui_accept") && dodge && Speed<BaseSpeed)
		//	{Speed=BaseSpeed;}
		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
			velocity.Y = direction.Y * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);
		}
		Velocity=Vector2.Zero;
		if(!hold)Velocity = velocity;
		/*if (Input.IsActionJustPressed("ui_accept") && dodge)
			{Velocity *= 100;
			dodge=false;
			DodgeCooldown.Start();
			}*/
		//MoveAndSlide();
		//if(touchCounter>0)Speed=100f;
	}

	private void Death()
	{
		main.death();
	   // QueueFree();
	}
	public void ResetDodge(){
		dodge=true;
	}
	int touchCounter=0;
	float basicEnemydameg=0.1f;
	public void _on_area_2d_body_entered(Node2D node)
	{
		
		if(node.GetType().IsAssignableTo(new EnemyBullet().GetType()))
		{
			EnemyBullet bullet=node as EnemyBullet;
			hp-=bullet.stats.damage;
			bullet.QueueFree();
		}
			 
			
		if(node.GetType().IsAssignableTo(new EnemyBasic().GetType()))
		{
			touchCounter++;
			if(!unstopable)Speed=stats.speed*(stats.speedMult-(touchCounter*0.1f));
			GD.Print("entered - "+touchCounter);
		}
		if(node.GetType()==new charger().GetType())
		{
			 
			GD.Print("touchCounter");
		}
	}
	public void _on_area_2d_body_exited(Node2D node)
	{
		if(node.GetType()==new EnemyBasic().GetType())
		{
			touchCounter--;
			if(touchCounter==0 && !unstopable)Speed=stats.speed*stats.speedMult;
			GD.Print("left - "+touchCounter);
		}
		if(node.GetType()==new charger().GetType())
		{
			 
			GD.Print("touchCounter");
		}
	}


	public virtual void updateStats()
	{
		var perhp=hp/stats.maxHp;
		stats=baseStats;
		var items=GetTree().GetNodesInGroup("Items"); 
		var weapons=GetTree().GetNodesInGroup("Weapons"); 
		var pasives=GetTree().GetNodesInGroup("Pasives"); 
		
		foreach (BasicItem item in items.Cast<BasicItem>())
		{
			stats*=item.stats;
		}
		foreach (Weapon item in weapons.Cast<Weapon>())
		{
			item.updateStats();
		}
		foreach (PasiveBasic item in pasives.Cast<PasiveBasic>())
		{
			item.activate();
		}
		Speed=stats.speed*stats.speedMult;
		hp=stats.maxHp*perhp;
	}
	public virtual void setLeveledStats(){
		
	}
}
