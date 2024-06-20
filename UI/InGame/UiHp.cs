using Godot;
using System;

public partial class UiHp : Label
{
	// Called when the node enters the scene tree for the first time.
Player player;
	public override void _Ready()
	{
		player=(Player) GetTree().Root.GetNode("Main").GetNode("Player");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Text="HP: "+MathF.Round(player.hp,2) +"/100";
	}
}
