using Godot;
using System;

public partial class EnemyShooter : EnemyBasic
{
	public PackedScene  projectile;
	bool readyToShoot=false;
	public override void _Ready()
	{
		base._Ready();
		stats=new Stats{maxHp=5f*difficulty,speed=80f,speedMove=80f};
		hp=stats.maxHp;
		projectile=GD.Load<PackedScene>("res://Enemies/Projectile/EnemyBullet.tscn");
	}
	public override void _PhysicsProcess(double delta)
	{
		readyToShoot=true;
		if(Position.DistanceTo(player.Position)>1000)
		{
			Vector2 dir= Position.DirectionTo(player.Position);//*speed;
		MoveAndCollide(dir*stats.speed*(float)delta);
		readyToShoot=false;
		return;
		}
		if(Position.DistanceTo(player.Position)<700)
		{
			Vector2 dir= Position.DirectionTo(player.Position);//*speed;
		MoveAndCollide(dir*stats.speed*(float)delta*-1);
		readyToShoot=false;
		return;
		}
	}
	public void _on_timer_timeout()
	{
		if(main.enemyProjectiles<100 && readyToShoot){
		main.enemyProjectiles++;
		var instance = projectile.Instantiate() as EnemyBullet;
		var rng=new RandomNumberGenerator().RandfRange(-0.25f,0.25f);
		var rotate=GlobalPosition.AngleToPoint(player.GlobalPosition);
		instance.dir =rotate+rng;
		instance.main=main;
		//instance.speed=5000;
		instance.spawnPos=GlobalPosition;
		instance.stats=stats;
		//GD.Print(instance.stats.penetration+"/"+stats.penetration);
		//GD.Print("ShootRotate"+Rotation);
		instance.spawnRot=rotate+rng;
		main.AddChild(instance);
		}
	}
}
