using Godot;
using System;

public partial class Dodge : Label
{
	// Called when the node enters the scene tree for the first time.
	Player player;
	public override void _Ready()
	{
		player=(Player) GetTree().GetFirstNodeInGroup("Player");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Text="Dodge: "+Math.Floor(player.DodgeCooldown.TimeLeft);
	}
}
