using Godot;
using System;

public partial class CharacterPickedTile : NinePatchRect
{
	[Export] public int position;
	public int level{get;set;}
	public string name{get;set;}
	public string weapon{get;set;}
	public ConfigFile character=new ConfigFile();
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GetChild(1).GetChild<RichTextLabel>(0).Text=name;
		GetChild(1).GetChild<RichTextLabel>(1).Text="LV "+level;
		character.Load("res://Configs/Characters.ini");
	}
	public void _on_button_up()
	{
		var menu=GD.Load<PackedScene>("res://UI/CharacterMenu/PickPlayable/character_picker_menu.tscn");
		var instance =menu.Instantiate();
		instance.GetChild(0).GetChild<CharacterPickTileContainer>(0).position=position;
		GetParent().GetParent().AddChild(instance);
		GetParent().GetParent<CanvasItem>().Visible=false;
		GetParent().GetParent().GetParent().GetChild<CanvasItem>(1).Visible=false;
	}
	public void pick(string pl,string item)
	{
		var parent=GetParent<PickedTeam>();
		switch(position){
			case 1:
			parent.support1=item;
			break;
			case 2:
			parent.player=pl;
			break;
			case 3:
			parent.support2=item;
			break;
		}
	}

    internal void updateLook(string name)
    {
		GD.Print(name);
        GetChild<TextureRect>(0).Texture=(Texture2D)GD.Load((string)character.GetValue(name,"sprite"));
		GetChild(1).GetChild<RichTextLabel>(0).Text=name;
		
    }

}
