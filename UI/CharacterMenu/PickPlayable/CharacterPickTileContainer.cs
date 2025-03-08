using Godot;
using System;
using System.Linq;

public partial class CharacterPickTileContainer : GridContainer
{
	public ConfigFile character=new ConfigFile();
	public ConfigFile items=new ConfigFile();
	public int position;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var core=GetTree().Root.GetChild<Core>(0);
		var team=GetTree().GetFirstNodeInGroup("Team") as PickedTeam;
		Error err= character.Load("res://Configs/Characters.ini");
		items.Load("res://Configs/Items.ini");
		GD.Print(err);
		var menu=GD.Load<PackedScene>("res://UI/CharacterMenu/PickPlayable/CharacterPickTile.tscn");
		foreach(String x in character.GetSections())
		{
			if(!core.unlocked.Where(y=>y.name==x).First().Equals(null) && (string)character.GetValue(x,"passive")!=team.support0 && (string)character.GetValue(x,"passive")!=team.support1 && (string)character.GetValue(x,"passive")!=team.support2)
			{
			GD.Print((string)character.GetValue(x, "name"));
		var instance =menu.Instantiate() as CharacterPickTile;
		GD.Print(instance);
		instance.name=(string)character.GetValue(x, "name");
		instance.weapon=(string)character.GetValue(x, "weapon");
		instance.GetChild<TextureRect>(0).Texture=(Texture2D)GD.Load((string)character.GetValue(x,"sprite"));
		instance.character=character;
		instance.items=items;
		instance.level=1;
		instance.position=position;
		AddChild(instance);}
		}
		
		
		
	}


}
