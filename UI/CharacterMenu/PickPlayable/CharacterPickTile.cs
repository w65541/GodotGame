using Godot;
using System;

public partial class CharacterPickTile : NinePatchRect
{
	public int level{get;set;}
	public string name{get;set;}
	public string weapon{get;set;}
	public ConfigFile character;
	public ConfigFile items;
	public int position;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GetChild(1).GetChild<RichTextLabel>(0).Text=name;
		GetChild(1).GetChild<RichTextLabel>(1).Text="LV "+level;
	}
	public void _on_button_up()
	{
		var scene=(string)character.GetValue(name,"scene");
		var passive=(string)character.GetValue(name,"passive");
		var team=GetTree().GetFirstNodeInGroup("Team") as PickedTeam;
		switch(position){
			case 1:
			team.support1=passive;
			team.GetChild<CharacterPickedTile>(0).updateLook(name);
			break;
			case 2:
			team.player=scene;
			team.GetChild<CharacterPickedTile>(1).updateLook(name);
			break;
			case 3:
			team.support2=passive;
			team.GetChild<CharacterPickedTile>(2).updateLook(name);
			break;
		}
		BackButton back =GetParent().GetParent().GetParent().GetChild<BackButton>(1);
		back._on_button_up();
	}
}
