using Godot;
using System;

public partial class PasiveBasic : Node
{
	public int level=1;
	public itemData data;
	public Player player;
	public BasicLevel main;
	public PasiveBasic(int x){
		level=x;
	}
	public override void _Ready()
	{
		player=(Player) GetTree().GetFirstNodeInGroup("Player");
		main=(BasicLevel) GetTree().GetFirstNodeInGroup("Main");
	}
	public virtual void activate(){}

}
