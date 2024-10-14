using Godot;
using System;

public partial class ExpPack : PickableBasic
{
	public long difficulty;
	public override void picked(Area2D area)
	{
		var p=area.GetParent();
		if(p.GetType().IsAssignableTo(new Player().GetType()))
		{
			var main=(BasicLevel) GetTree().GetFirstNodeInGroup("Main");
			main.exp+=100*(1+difficulty/5);
		QueueFree();
		}
	}
}
