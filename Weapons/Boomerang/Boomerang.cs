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
			count=1,
			penetrationInf=false,
			penetration=20,
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
			name="Boomerang",
			level=2,
			opis="Zwieksza rozmiar o 20%",
			sprite="res://Items/Textures/rang.png",
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
			GetChild<AudioStreamPlayer>(2).Play();
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
		if(level>6){
			instance.dir =-1f*Rotation;
			main.AddChild(instance);
		}
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
	public override void levelup()
    {
		level++;
		data.level++;
		switch(level)
		{
			case 2:
			baseStats.size=1.2f;
			updateStats();
			data.opis="Zwieksza liczbe bumerangow";
			break;
			case 3:
			baseStats.count++;
			updateStats();
			data.opis="Zwieksza szybkosc pocisku o 50%";
			break;
			case 4:
			baseStats.speed=300f;
			updateStats();
			data.opis="Zwieksza obrazenia o 10";
			break;
			case 5:
			baseStats.damage=20f;
			updateStats();
			data.opis="Zwieksza liczbe bumerangow";
			break;
			case 6:
			baseStats.count++;
			updateStats();
			data.opis="Podwaja liczbe bumerangow";
			break;
			case 7:
			baseStats.count*=2;
			updateStats();
			break;
		}
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
		GetChild<AudioStreamPlayer>(2).Play();
		Shoot();
		Cooldown.WaitTime=stats.cooldown*stats.fireRate+0.1f;
		Cooldown.Start();
	}
}
