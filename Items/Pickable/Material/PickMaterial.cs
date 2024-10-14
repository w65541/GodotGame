using Godot;
using System;

public partial class PickMaterial : PickableBasic
{
	[Export] public String name;
	[Export] public long amount;
	[Export] public Texture2D sprite;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GetChild<Sprite2D>(2).Texture=sprite;
	}

	public override void picked(Area2D area)
	{
		var p=area.GetParent();
		if(p.GetType().IsAssignableTo(new Player().GetType()))
		{
			GetTree().Root.GetChild<Core>(0).updateMat(name,amount);
		//	GetTree().GetFirstNodeInGroup("Main").addMat(name,amount);
		QueueFree();
		}
	}
}
