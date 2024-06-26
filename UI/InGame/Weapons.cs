using Godot;
using System;
using System.Linq;

public partial class Weapons : Label
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		string a="Weapons:\n";
		var itemsInTree=GetTree().GetNodesInGroup("Weapons");
		foreach (var item in itemsInTree.Cast<Weapon>())
		{
			a+=""+item.data.name+" Lv "+(item.data.level-1)+"\n";
		}
		Text=a;
	}
}
