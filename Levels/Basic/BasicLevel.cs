using Godot;
using System;

public partial class BasicLevel : Node2D
{
	public ConfigFile level;
	public string name;
	public string charatcer="res://Players/Trooper/trooper.tscn";
	public string passive1;
	public string passive2;
	public levelupmenu levelupmenu;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print(level.GetSectionKeys(name));
		//level.Load("res://Configs/Levels.ini");
		var player=GD.Load<PackedScene>(charatcer);
		var instance=player.Instantiate<Player>();
		instance.Name="Player";
		AddChild(instance);
		GD.Print(GetTreeStringPretty());
		foreach(String y in level.GetSectionKeys(name))
		{
			string x=(String)level.GetValue(name,y);
			if(x.Contains("res") && !x.Contains(".png")){
			var ele=GD.Load<PackedScene>(x);
			GetNode("Player").AddChild(ele.Instantiate());
			}
		}
		
		levelupmenu=GetNode<levelupmenu>("Player/LevelUpMenu");
		GD.Print(GetTree().Root.GetTreeStringPretty());
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		//
		if (Input.IsActionJustPressed("ui_focus_next"))
		{
			levelupmenu.Visible=true;
			levelupmenu.rollLevelUp();
		}
	}
}
