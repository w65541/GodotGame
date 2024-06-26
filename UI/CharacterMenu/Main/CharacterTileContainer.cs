using Godot;
using System;

public partial class CharacterTileContainer : GridContainer
{
	public ConfigFile character=new ConfigFile();
	public ConfigFile items=new ConfigFile();
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Error err= character.Load("res://Configs/Characters.ini");
		items.Load("res://Configs/Items.ini");
		GD.Print(err);
		var menu=GD.Load<PackedScene>("res://UI/CharacterMenu/Main/CharacterMenuTile.tscn");
		foreach(String x in character.GetSections())
		{
			GD.Print((string)character.GetValue(x, "name"));
		var instance =menu.Instantiate() as ToCharacterDetails;
		GD.Print(instance);
		instance.name=(string)character.GetValue(x, "name");
		instance.weapon=(string)character.GetValue(x, "weapon");
		instance.GetChild<TextureRect>(0).Texture=(Texture2D)GD.Load((string)character.GetValue(x,"sprite"));
		instance.character=character;
		instance.items=items;
		instance.level=1;
		AddChild(instance);
		}
		
		
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}