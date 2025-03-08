using Godot;
using System;

public partial class CharacterDetails : Control
{
	Core core;
	public  ConfigFile character=new ConfigFile();
	public ConfigFile items;
	public int level;
	public string name;
	public string weapon;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("Name: "+name);
		if(name!=""){
		//character.Load("res://Configs/Characters.ini");
		core=GetTree().Root.GetChild<Core>(0);
		//character=GetParent<character_details>().character;
		var tex=(Texture2D)GD.Load((string)character.GetValue(name,"sprite"));
		GetChild<TextureRect>(1).Texture=tex;
		var ps=GD.Load<PackedScene>((string)character.GetValue(name,"scene"));
		var ss=ps.Instantiate<Player>();
		string ints= (string)character.GetValue(name,"stats");
		ss.setLeveledStats();
		ints=ss.stats.wypisz();

		var passiveScene=GD.Load<PackedScene>((string)character.GetValue(name,"passive"));
		
		var status=core.unlocked.Find(x=>x.name.Equals(name));
		var passive=passiveScene.Instantiate<PasiveBasic>();
		passive.level=status.skill;

		passive.opis();
		GetChild(4).GetChild<RichTextLabel>(0).Text=passive.data.name;
		GetChild(4).GetChild<RichTextLabel>(1).Text=passive.data.opis;
		GetChild(4).GetChild<TextureRect>(2).Texture=(Texture2D)GD.Load("res://UI/Texures/Star"+status.skill+".png");

		GetChild(0).GetChild<RichTextLabel>(0).Text=ints;
		GetChild(2).GetChild<TextureRect>(0).Texture=(Texture2D)GD.Load((string)items.GetValue(weapon,"sprite"));
		GetChild(2).GetChild<RichTextLabel>(1).Text=weapon;
		GetChild(2).GetChild<RichTextLabel>(2).Text=(string)items.GetValue(weapon,"opis");

		GetChild(3).GetChild<TextureRect>(0).Texture=(Texture2D)GD.Load((string)character.GetValue(name,"specialSprite"));
		GetChild(3).GetChild<RichTextLabel>(1).Text=(string)character.GetValue(name,"specialName");
		GetChild(3).GetChild<RichTextLabel>(2).Text=(string)character.GetValue(name,"specialOpis");
		}
	}

	public void updatepasive(){
		
	}
}
