using Godot;
using System;
using System.Linq;

public partial class ItemsDebugUi : Label
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		string a="Items:\n";
		var itemsInTree=GetTree().GetNodesInGroup("Items");
		foreach (var item in itemsInTree.Cast<BasicItem>())
		{
			a+=""+item.data.name+" Lv "+(item.data.level-1)+"\n";
		}
		Text=a;
	}
}
