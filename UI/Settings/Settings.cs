using Godot;
using System;

public partial class Settings : Control
{
	Core core;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		core=GetTree().Root.GetChild<Core>(0);
		GetChild(0).GetChild<HSlider>(1).Value=(int )core.file.GetValue("Audio","bgm");
		GetChild(0).GetChild<HSlider>(2).Value=(int )core.file.GetValue("Audio","sfx");
		GetChild(2).GetChild(1).GetChild<SpinBox>(0).Value=(int )core.file.GetValue("Gameplay","max");
		GetChild(2).GetChild(1).GetChild<SpinBox>(1).Value=(int )core.file.GetValue("Gameplay","dif");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _on_button_play_5_button_up(){
		foreach (Keybind item in GetChild(1).GetChild(0).GetChildren())
		{
			if(!item.changing)core.file.SetValue("Controls",item.akcja,item.Text);
		}
		core.file.SetValue("Audio","bgm",GetChild(0).GetChild<HSlider>(1).Value);
		core.file.SetValue("Audio","sfx",GetChild(0).GetChild<HSlider>(2).Value);
		core.file.SetValue("Gameplay","max",GetChild(2).GetChild(1).GetChild<SpinBox>(0).Value);
		core.file.SetValue("Gameplay","dif",GetChild(2).GetChild(1).GetChild<SpinBox>(1).Value);
	}
}
