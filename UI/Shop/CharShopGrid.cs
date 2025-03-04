using Godot;
using System;

public partial class CharShopGrid : GridContainer
{
	public ConfigFile character=new ConfigFile();
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var core=GetTree().Root.GetChild<Core>(0) as Core;
		Error err= character.Load("res://Configs/Characters.ini");
		
		GD.Print(err);
		var menu=GD.Load<PackedScene>("res://UI/Shop/CharacterShopTile.tscn");
		foreach(var x in core.locked)
		{
			GD.Print((string)character.GetValue(x.name, "name"));
		var instance =menu.Instantiate() as CharacterShopTile;
		GD.Print(instance);
		instance.name=(string)character.GetValue(x.name, "name");
		instance.GetChild<TextureRect>(0).Texture=(Texture2D)GD.Load((string)character.GetValue(x.name,"sprite"));
		instance.GetChild<RichTextLabel>(3).Text=x.name;
		instance.cost=(int)character.GetValue(x.name, "cost");
		AddChild(instance);
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
