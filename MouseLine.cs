using Godot;
using System;

public partial class MouseLine : Line2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Points[1]=GetGlobalMousePosition();
		//GD.(GetGlobalMousePosition().AngleTo(GetParent().v))
		//GD.Print(GetGlobalMousePosition());
		//Points[1].X=GetGlobalMousePosition.X;
		//Points[1].Y=GetGlobalMousePosition.Y;
	}
}
