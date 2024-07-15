using Godot;
using System;

public partial class character_details : Node
{
	public  ConfigFile character;
	public ConfigFile items;
	public int level;
	public string name;
	public string weapon;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var instance=GetChild<CharacterDetails>(0);
		instance.character=character;
		instance.items=items;
		instance.name=name;
		instance.weapon=weapon;
		instance.level=level;
		instance._Ready();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
