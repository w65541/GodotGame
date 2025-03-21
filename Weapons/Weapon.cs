using Godot;
using System;

public partial class Weapon: Node2D,Levelable
{//TODO template to
	public  Node main;
	public PackedScene  projectile;
	public String bulletType;
	public float r=100.0f;
	public Targeting targeting;
	public Stats stats;
	public Stats baseStats;
	public Player player;
	public Timer Cooldown;
	public int level=1;
	public itemData data;
	public TargetClosest closest;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		main= GetTree().GetFirstNodeInGroup("Main");
		GD.Print("res://Weapons/Projectiles/"+bulletType+".tscn");
		//projectile=GD.Load<PackedScene>("res://Weapons/Projectiles/"+bulletType+".tscn");
		player=(Player) GetParent();
		baseStats=stats;
		Cooldown= (Timer)GetNode("Timer");
		//GD.Print(stats.penetration);
		stats=baseStats*player.stats;
	//	GD.Print(stats.penetration);
		Cooldown.WaitTime=stats.cooldown*stats.fireRate+0.1f;
		Cooldown.Start();
		closest=GetTree().GetFirstNodeInGroup("Closest") as TargetClosest;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		switch(targeting){

			case Targeting.Mouse:
			var pPosition=player.Position;
			var ang=pPosition.AngleToPoint(GetGlobalMousePosition());
			Rotation=ang;
			Position=new Vector2{
			Y=((float)Math.Sin(ang))*r,
			X=((float)Math.Cos(ang))*r
			};
			break;

			case Targeting.Closest:
			Rotation=closest.rotate;
			//Position=Position;
			break;
		}
		
	}
	public itemData GetItemData()
    {
        return data;
    }
	virtual public void updateStats()
	{
		stats=baseStats*GetParent<Player>().stats;
		Cooldown.WaitTime=stats.cooldown*stats.fireRate;
		GD.Print(Name+": Update stats damage multiplayer: "+stats.damageMult);
	}
	public virtual void Shoot(){}
	/*void Shoot()
	{
		var instance = projectile.Instantiate() as TBType;
		instance.dir =Rotation;
		instance.speed=500;
		instance.spawnPos=GlobalPosition;
		GD.Print("ShootRotate"+Rotation);
		instance.spawnRot=Rotation;
		main.AddChild(instance);
	}*/
	public virtual void _on_timer_timeout()
	{
		
		for (int i = 0; i < stats.count; i++)
		{
			Shoot();
		}	
		Cooldown.WaitTime=stats.cooldown*stats.fireRate;
		Cooldown.Start();
	}
	public virtual void levelup()
    {
		level++;
		data.level++;
		switch(level)
		{
			case 2:
			
			updateStats();
			break;
			case 3:
			
			updateStats();
			break;
			case 4:
			
			updateStats();
			break;
			case 5:
			
			updateStats();
			break;
			case 6:
			
			updateStats();
			break;
			case 7:
			
			updateStats();
			break;
		}
	}
}
