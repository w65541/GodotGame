using Godot;
using System;

public partial class Hpack : PickableBasic
{
	public override void picked(Area2D area)
	{
		var p=area.GetParent();
		if(p.GetType().IsAssignableTo(new Player().GetType()))
		{
			player.hp=player.stats.maxHp;
		QueueFree();
		}
		
		
	}
}
