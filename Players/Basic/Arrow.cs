using Godot;
using System;

public partial class Arrow : Sprite2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}
float d=0.0f;
float r=200.0f;
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var pPosition=(Vector2)GetParent().Get(Node2D.PropertyName.Position);
		d+=(float)delta;
		var dir=pPosition.DirectionTo(GetGlobalMousePosition());
		//LookAt(GetGlobalMousePosition());
		var ang=(pPosition.AngleToPoint(GetGlobalMousePosition()));
		Position=new Vector2{
			Y=((float)Math.Sin(ang))*r,
			X=((float)Math.Cos(ang))*r
		};
Rotation=ang;
		/*GD.Print("Sin:"+Math.Sin(ang));
GD.Print("Cos:"+Math.Cos(ang));
		
		GD.Print("pos:"+pPosition);
		GD.Print("mouse:"+GetGlobalMousePosition());
GD.Print("angle:"+ang);*/
		
		//Position=dir.LimitLength(50);
		/*Vector2 up=new Vector2{X=pPosition.X,Y=pPosition.Y+10};
		Rotation= pPosition.DirectionTo(GetGlobalMousePosition()).AngleTo(up);// AngleToPoint(GetGlobalMousePosition());
		//global_position = GetParent(). + Vector2.RIGHT.rotated(angle)*radius

GD.Print("up:"+up);
GD.Print("dir:"+pPosition.DirectionTo(GetGlobalMousePosition()));

GD.Print("angle:"+pPosition.DirectionTo(GetGlobalMousePosition()).AngleTo(pPosition));*/
	}
}
