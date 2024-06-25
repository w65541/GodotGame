using Godot;
using System;

public partial class LevelButton : TextureButton
{
	public ConfigFile level;
	[Export]public string name;
	PackedScene scene;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//level=GetParent().GetParent<LevelSelect>().levels;
		level=new ConfigFile();
		level.Load("res://Configs/Levels.ini");
		GetChild<RichTextLabel>(0).Text=(string)level.GetValue(name,"name");
		GetChild<RichTextLabel>(1).Text=(string)level.GetValue(name,"opis");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _on_button_up()
	{
		scene=GD.Load<PackedScene>((string)level.GetValue(name,"scene"));
		GD.Print("dada");
		var instance=scene.Instantiate<BasicLevel>();
		instance.level=level;
		instance.name=name;
		GetTree().Root.GetChild(0).AddChild(instance);
		var m=GetTree().GetFirstNodeInGroup("LevelSelectMenu") as CanvasItem;
		m.Visible=false;

	}
}
