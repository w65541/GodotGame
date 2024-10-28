using Godot;
using System;

public partial class PickMaterial : PickableBasic
{
	[Export] public String name;
	[Export] public long amount=1;
	[Export] public Texture2D sprite;
	// Called when the node enters the scene tre e for the first time.
	public override void _Ready()
	{
		var tex =(Texture2D) GD.Load("res://Items/Textures/Material/"+name+".png"); 
		GetChild<Sprite2D>(2).Texture=tex;
	}

	public override void picked(Area2D area)
	{
		var p=area.GetParent();
		if(p.GetType().IsAssignableTo(new Player().GetType()))
		{
			GetTree().Root.GetChild<Core>(0).addMat(name,amount);
		//	GetTree().GetFirstNodeInGroup("Main").addMat(name,amount);
		QueueFree();
		}
	}
}
