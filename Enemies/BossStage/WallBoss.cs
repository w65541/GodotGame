using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

public partial class WallBoss : CharacterBody2D
{
	public Player player;

	public float speed=100f,spikeDelay=3f,hp=1000f,chargeboost=0,distanceboost=1f;
	float damagedone=0;
	int tentaclesNumber=3,bullets=5,rotatecounter=0,targetRotation;
	List<SpikeGroup> spikes=new List<SpikeGroup>();
	List<Tentacle> tentacles=new List<Tentacle>();
	PackedScene bullet=GD.Load<PackedScene>("res://Enemies/Projectile/EnemyBullet.tscn");
	BasicLevel main;
	bool charge=false,rotate=false;
	public override void _Ready()
	{
		player=GetTree().GetFirstNodeInGroup("Player") as Player;
		main=GetTree().GetFirstNodeInGroup("Main") as BasicLevel;
		for (int i = 1; i < 6; i++)
		{
			spikes.Add(GetNode<SpikeGroup>("SpikeGroup"+i));
		}
		for (int i = 1; i < 5; i++)
		{
			tentacles.Add(GetNode<Tentacle>("Tentacle"+i));
		}
	}
	public void tentacleAttack(){
		var rng=new RandomNumberGenerator().RandfRange(-3.5f,6f);
		var m=new RandomNumberGenerator().RandiRange(0,5);
		for (int i = 0; i < tentaclesNumber; i++)
		{
			rng=new RandomNumberGenerator().RandfRange(-7f,11f);
		tentacles[i].Rotation=rng;
		tentacles[i].speed=1000f;
		tentacles[i].Visible=true;
		}
		
	}
	public override void _PhysicsProcess(double delta)
	{
		///temp
		player=GetTree().GetFirstNodeInGroup("Player") as Player;
		main=GetTree().GetFirstNodeInGroup("Main") as BasicLevel;
		///
	/*	if (Input.IsActionJustPressed("ui_left")){
			tentacleAttack();
		}
		if (Input.IsActionJustPressed("ui_right")){
			changeRotatation();
		}
		if (Input.IsActionJustPressed("ui_up")){
			bulletAttack();
		}
		if (Input.IsActionJustPressed("ui_down")){
			spikeAttack();
		}*/
		if(hp<=0) death();
		if(damagedone>=250) phaseChange();
		if(GlobalPosition.DistanceTo(player.GlobalPosition)>6000){distanceboost=2f;}else{distanceboost=1f;}
		
		if(rotate){
			rotatecounter++;
			if(rotatecounter>30){
				if(RotationDegrees<targetRotation){
					RotationDegrees++;
				}
				if(RotationDegrees>targetRotation){
					RotationDegrees++;
				}
				if (RotationDegrees==targetRotation) rotate=false;
				rotatecounter=0;
			}
		}
		Velocity = Vector2.Right.Rotated(Rotation) * (speed+chargeboost);
		//Velocity=new Vector2(100f,0);
		MoveAndSlide();
	}
	public void _on_area_2d_body_entered(Node2D node){
		if(node.IsInGroup("Player")){
			player.hp-=player.stats.maxHp*0.1f;
			node.Position+=(Position.DirectionTo(node.Position)*500);
			return;
		}
		if(node.GetType().IsAssignableTo(new ProjectilePlayer().GetType())){
			var x=node as ProjectilePlayer;
			hp-=x.stats.damage*x.stats.damageMult;
			GD.Print("BossHp: "+hp);
		}
	}
	public void changeRotatation(){
		rotate=true;
		targetRotation+=90;
		
	}
    public void death()
    {
        throw new NotImplementedException();
    }
	public void bulletAttack(){
		for (int i = 0; i < bullets; i++)
		{
			var instance=bullet.Instantiate() as EnemyBullet;
		instance.stats=new Stats{speed=1000f};
		instance.Rotation=Rotation;
		instance.dir=Rotation;
		var rng=new RandomNumberGenerator().RandfRange(0f,1040f);
		instance.GlobalPosition=GlobalPosition+new Vector2(0,rng);
		main.AddChild(instance);
		instance.GlobalPosition=GlobalPosition+new Vector2(0,rng);
		instance.Rotation=Rotation;
		}
		
	}
	public void chargeAttack()
	{
		if(charge){
charge=false;
			chargeboost=0f;
		}else{
			charge=true;
			chargeboost=speed*1.25f;
		}
	}
    public void phaseChange()
    {
        if(hp<=750 && hp>500){

		}
		if(hp<=500 && hp>250){

		}
		if(hp<=250 && hp>0){

		}
    }

    public void spikeAttack(){
		var temp=new List<SpikeGroup>(spikes);
		var closest=0;
		for (int i = 1; i < spikes.Count; i++)
		{
			if(spikes[i].GlobalPosition.DistanceSquaredTo(player.GlobalPosition)<spikes[closest].GlobalPosition.DistanceSquaredTo(player.GlobalPosition)) closest=i;
		}
		
		temp[closest].attack(spikeDelay);
		if(closest+1<=spikes.Count-1)temp[closest+1].attack(spikeDelay+2f);
		//temp[1].attack(spikeDelay+2f);
		//temp[2].attack(spikeDelay+4f);
	}

}
