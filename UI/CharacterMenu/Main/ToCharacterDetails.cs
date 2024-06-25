using Godot;
using System;

public partial class ToCharacterDetails : NinePatchRect
{	
	
	public int level{get;set;}
	public string name{get;set;}
	public string weapon{get;set;}
	public ConfigFile character;
	public ConfigFile items;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GetChild(1).GetChild<RichTextLabel>(0).Text=name;
		GetChild(1).GetChild<RichTextLabel>(1).Text="LV "+level;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _on_button_up()
	{
		var menu=GD.Load<PackedScene>("res://UI/CharacterMenu/Details/character_details.tscn");
		var instance =menu.Instantiate() as character_details;
		GD.Print(instance);
		instance.character=character;
		instance.items=items;
		instance.name=name;
		instance.weapon=weapon;
		instance.level=level;
		GetParent().GetParent().AddChild(instance);
		GetParent().GetParent<CanvasItem>().Visible=false;
		GetParent().GetParent().GetParent().GetChild<CanvasItem>(1).Visible=false;
	}
}
