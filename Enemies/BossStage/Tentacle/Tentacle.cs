using Godot;
using System;

public partial class Tentacle : Node2D
{
	// Called when the node enters the scene tree for the first time.
	Vector2 destination;
	Line2D macka;
	RayCast2D a,b,c;
	public float speed=0;
	Player player;
	int inputCounter=0;
	public bool retract=true;
	[Export]public float minAng,maxAng;
	public override void _Ready()
	{
		player=GetTree().GetFirstNodeInGroup("Player") as Player;
		macka=GetChild<Line2D>(0);
		a=GetChild<RayCast2D>(2);
		b=GetChild<RayCast2D>(3);
		c=GetChild<RayCast2D>(4);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		///temp
		player=GetTree().GetFirstNodeInGroup("Player") as Player;
		
		///
		
		if(!player.hold){
		if(delta*speed+a.TargetPosition.X>2800){
			GetChild<Timer>(6).Start();
		}
		var v=new Vector2((float) delta*speed+a.TargetPosition.X,0);
		if(v.X<=0) {
			Visible=false;
			speed=0;
		}
		a.TargetPosition=v;
		b.TargetPosition=v;
		c.TargetPosition=v;
		macka.SetPointPosition(1,v);
		if(a.CollideWithBodies){
			var n=a.GetCollider() as Node2D;
			
			if(n!=null && n.IsInGroup("Player") && retract){
				hold();
				GD.Print("Hold");
			}else if(n!=null && n.GetType().IsAssignableTo(new wall().GetType()) && retract){
				retra();
			}
		}}else{
			if (Input.IsActionJustPressed("ui_left"))
			{
				inputCounter++;
			}
			if (Input.IsActionJustPressed("ui_right"))
			{
				inputCounter++;
			}
			if (Input.IsActionJustPressed("ui_up"))
			{
				inputCounter++;
			}
			if (Input.IsActionJustPressed("ui_down"))
			{
				inputCounter++;
			}
			if(inputCounter>20){
				unhold();
			}
			}
		
	}
	public void retra(){
		GD.Print("raz");
		if(retract ){
			retract=false;
			speed=0;
				GD.Print("RetractSTART");
				GetChild<Timer>(6).Start();
		}
	}
	public void hold(){
		player.hold=true;
		GetChild<Node2D>(5).Visible=true;
		GetChild<Node2D>(5).GlobalPosition=player.GlobalPosition;
		var vec=new Vector2(	Math.Abs(	GlobalPosition.DistanceTo(	player.GlobalPosition)),0);
		macka.SetPointPosition(1,vec);
		speed=0;
	}
	public void unhold(){
		player.hold=false;
		GetChild<Node2D>(5).Visible=false;
	speed=-5000f;
	}
	public void _on_retract_timeout(){
		GD.Print("Retract");
		speed=-5000f;
	}
}
