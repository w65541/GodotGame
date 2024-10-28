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
	 public Stats stats;
	public Main main;
public override void _Ready()
	{
		
		DodgeCooldown= (Timer)GetNode("CooldownDodge");
		/*stats=new Stats{
		maxHp=100.0f,
		speed=200f,
		speedMove=200f,
		cooldown=5f,
		};*/
		//GD.Print(stats.fireRate);
		//main=(Main) GetTree().Root.GetNode("Main");
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
		hp-=touchCounter*basicEnemydameg;
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
       // QueueFree();
    }
	public void ResetDodge(){
		dodge=true;
	}
    int touchCounter=0;
	float basicEnemydameg=0.01f;
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
			//GD.Print(touchCounter);
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
			GD.Print(touchCounter);
		}
		if(node.GetType()==new charger().GetType())
		{
			 
			GD.Print("touchCounter");
		}
	}


	public virtual void updateStats()
	{
		stats=baseStats;
		var items=GetTree().GetNodesInGroup("Items"); 
		var weapons=GetTree().GetNodesInGroup("Weapons"); 
		foreach (BasicItem item in items.Cast<BasicItem>())
		{
			stats*=item.stats;
		}
		foreach (Weapon item in weapons.Cast<Weapon>())
		{
			item.updateStats();
		}
		Speed=stats.speed*stats.speedMult;
	}
}
