using Godot;
using System;

public partial class LineFollow : Line2D
{public float z;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		z=Math.Abs(	GlobalPosition.DistanceTo(	Vector2.Zero));
		GD.Print("Z:"+z);
	}
	Player player;
	
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		player=GetTree().GetFirstNodeInGroup("Player") as Player;
		var boss=GetTree().GetFirstNodeInGroup("Boss") as Node2D;
		var x=Math.Abs(	GlobalPosition.DistanceTo(	player.GlobalPosition))-5300f;
		//if(x)
		var vec=new Vector2(	Math.Abs(	GlobalPosition.DistanceTo(	player.GlobalPosition))/9+50f,0);
		SetPointPosition(1,vec);
	}
}
