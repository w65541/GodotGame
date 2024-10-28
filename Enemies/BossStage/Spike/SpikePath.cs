using Godot;
using System;

public partial class SpikePath : PathFollow2D
{
	public float speed=0;
	bool retracted=true;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
		
		//GD.Print(ProgressRatio);
		if((float)(delta * speed)+ProgressRatio>1){
			retracted=false;
			speed=0;
			GetChild<Timer>(1).Start();
		} 
		if((float)(delta * speed)+ProgressRatio<0){
			retracted=true;
			speed=0;
			GetParent().GetParent<Node2D>().Visible=false;
		} 
		ProgressRatio+= (float)(delta * speed);
	}
	public void Start(){
		speed=0.75F;
		retracted=true;
		GetParent().GetParent<Node2D>().Visible=true;
	}
	public void _on_retract_timeout(){
		speed=-1F;
	}
}
