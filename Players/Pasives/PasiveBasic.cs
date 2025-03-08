using Godot;
using System;

public partial class PasiveBasic : Node
{
	public int level=1;
	public itemData data;
	public Player player;
	public BasicLevel main;
	
	public override void _Ready()
	{
		player=(Player) GetTree().GetFirstNodeInGroup("Player");
		main=(BasicLevel) GetTree().GetFirstNodeInGroup("Main");
		opis();
	}
	public virtual void activate(){}
	public virtual void opis(){}
}
