using Godot;
using System;

public partial class CharacterPickNullTile : NinePatchRect
{
	public int position;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		position=GetParent<CharacterPickTileContainer>().position;
	}
	public void _on_button_up()
	{
		var name="none";
		var scene="";
		var passive="";
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
