using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class Items : Node2D
{
	List<BasicItem> items;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//items=GetChildren().ToList()	.ToList<Items>();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
