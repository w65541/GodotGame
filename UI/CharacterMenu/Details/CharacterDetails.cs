using Godot;
using System;

public partial class CharacterDetails : Control
{
	public  ConfigFile character;
	public ConfigFile items;
	public int level;
	public string name;
	public string weapon;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		int[] ints= (int[])character.GetValue(name,"stats");
		GetChild(0).GetChild<RichTextLabel>(0).Text=ints[level-1]+"";
		
		GetChild<TextureRect>(1).Texture=(Texture2D)GD.Load((string)character.GetValue(name,"sprite"));

		GetChild(2).GetChild<TextureRect>(0).Texture=(Texture2D)GD.Load((string)items.GetValue(weapon,"sprite"));
		GetChild(2).GetChild<RichTextLabel>(1).Text=weapon;
		GetChild(2).GetChild<RichTextLabel>(2).Text=(string)items.GetValue(weapon,"opis");

		GetChild(3).GetChild<TextureRect>(0).Texture=(Texture2D)GD.Load((string)character.GetValue(name,"specialSprite"));
		GetChild(3).GetChild<RichTextLabel>(1).Text=(string)character.GetValue(name,"specialName");
		GetChild(3).GetChild<RichTextLabel>(2).Text=(string)character.GetValue(name,"specialOpis");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
