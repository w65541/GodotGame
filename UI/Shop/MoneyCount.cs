using Godot;
using System;

public partial class MoneyCount : RichTextLabel
{
	Core core;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		core=GetTree().Root.GetChild<Core>(0) as Core;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Text=core.inventory[core.inventory.FindIndex(x=>x.name.Equals("money"))].amount+"";
	}
}
