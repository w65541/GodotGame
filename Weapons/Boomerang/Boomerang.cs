using Godot;
using System;

public partial class Boomerang : Weapon
{
	public float rangs;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		bulletType="Rang";
		targeting=Targeting.Closest;
		stats=new Stats{
			damage=10f,
			count=2,
			penetrationInf=false,
			penetration=2,
			cooldown=2f,
			durationMult=1,
			fireRate=1,
			speed=200f,
			size=5f,
			duration=5f
		};
		r= 00f;
		//GD.Print(stats.penetration);
		data=new itemData{
			name="Shotgun",
			level=2,
			opis="afdgsdg",
			sprite="res://Items/Textures/Shotgun.png",
			scene=""
		};
		projectile=GD.Load<PackedScene>("res://Weapons/Boomerang/Projectile/Rang.tscn");
		//baseStats=stats;
		rangs=stats.count;
		base._Ready();
	}
	public override void Shoot()
	{
		if(rangs>stats.count) rangs=stats.count;
		if(rangs>0){
			rangs--;
		var instance = projectile.Instantiate() as Rang;
		instance.dir =Rotation;
		//instance.speed=5000;
		instance.spawnPos=GlobalPosition;
		instance.stats=stats;
		instance.player=player;
		instance.boomerang=this;
		//GD.Print(instance.stats.penetration+"/"+stats.penetration);
		//GD.Print("ShootRotate"+Rotation);
		instance.spawnRot=Rotation;
		main.AddChild(instance);
		GD.Print("Rangs "+rangs+"/"+stats.count);
		}
	}
    public override void updateStats()
    {
		var newrangs=stats.count;
        base.updateStats();
		rangs+=stats.count-newrangs;
    }
    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
		base._Process(delta);
	}

	public void _on_area_2d_body_entered(Node2D node)
	{
		if(node.GetType().IsAssignableTo(new Rang().GetType()))
		{
			var x=(Rang) node;
			if(x.penetrable<1)
			{
				x.Visible=false;
				x.Despawn();
			}
		}
	}
	public override void _on_timer_timeout()
	{
		Shoot();
		Cooldown.WaitTime=stats.cooldown*stats.fireRate;
		Cooldown.Start();
	}
}
