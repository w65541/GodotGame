using Godot;
using System;

public partial class LevelButton : TextureButton
{
	public Core core;
	public ConfigFile level;
	[Export]public string name;
	PackedScene scene;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		core=GetTree().Root.GetChild<Core>(0);
		//level=GetParent().GetParent<LevelSelect>().levels;
		level=new ConfigFile();
		level.Load("res://Configs/Levels.ini");
		GetChild<RichTextLabel>(0).Text=(string)level.GetValue(name,"name");
		GetChild<RichTextLabel>(1).Text=(string)level.GetValue(name,"opis");
		if((int)core.file.GetValue("Level",name)==0) {Disabled=true;
		foreach (CanvasItem item in GetChildren())
		{
			item.Visible=false;
		}
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _on_button_up()
	{
		var team=GetTree().GetFirstNodeInGroup("Team") as PickedTeam;
		if(team.player!=""){
		scene=GD.Load<PackedScene>((string)level.GetValue(name,"scene"));
		var instance=scene.Instantiate<BasicLevel>();
		instance.level=level;
		instance.name=name;
		instance.charatcer=team.player;
		instance.passive1=team.support1;
		instance.passive2=team.support2;
		GetTree().Root.GetChild(0).AddChild(instance);
		var m=GetTree().GetFirstNodeInGroup("LevelSelectMenu") as CanvasItem;
		m.Visible=false;
		}
	}
}
