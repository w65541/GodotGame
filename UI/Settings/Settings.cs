using Godot;
using System;

public partial class Settings : Control
{
	Core core;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		core=GetTree().Root.GetChild<Core>(0);
		GetChild(0).GetChild<HSlider>(1).Value=(float )core.file.GetValue("Audio","bgm");
		GetChild(0).GetChild<HSlider>(2).Value=(float )core.file.GetValue("Audio","sfx");
		GetChild(2).GetChild(1).GetChild<SpinBox>(0).Value=(int )core.file.GetValue("Gameplay","max");
		GetChild(2).GetChild(1).GetChild<SpinBox>(1).Value=(int )core.file.GetValue("Gameplay","dif");
	}

		public  void musicChanged(float f)
	{
		float volume=-72f-(-72f*(float)GetChild(0).GetChild<HSlider>(1).Value);
		//GD.Print(volume);
		AudioServer.SetBusVolumeDb(1,volume);
		core.file.SetValue("Audio","bgm",GetChild(0).GetChild<HSlider>(1).Value);
		core.file.Save("user://Save.ini");
	}
	public  void sfxChanged(float f)
	{
		float volume=-72f-(-72f*(float)GetChild(0).GetChild<HSlider>(2).Value);
		//GD.Print(volume);
		AudioServer.SetBusVolumeDb(2,volume);
		core.file.SetValue("Audio","sfx",GetChild(0).GetChild<HSlider>(2).Value);
		core.file.Save("user://Save.ini");
	}
			public  void maxenemy(float f){
				core.maxenemy=(int)f;
				core.file.SetValue("Gameplay","max",GetChild(2).GetChild(1).GetChild<SpinBox>(0).Value);
				core.file.Save("user://Save.ini");
			}
			public  void dif(float f){
				core.difficulty=(int)f;
				core.file.SetValue("Gameplay","max",GetChild(2).GetChild(1).GetChild<SpinBox>(0).Value);
				core.file.Save("user://Save.ini");
			}
	public void _on_button_play_5_button_up(){
		ConfigFile file=new ConfigFile();
			file.Load("res://Configs/Save.ini");
		foreach (var key in file.GetSectionKeys("Controls"))
		{
			string temp=(string)file.GetValue("Controls",key);
			InputMap.ActionEraseEvents(key);
			InputEventKey input=new InputEventKey();
			input.Keycode=OS.FindKeycodeFromString(temp);
					InputMap.ActionAddEvent(key,input);
		} ;
		
		core.file.SetValue("Audio","bgm",1);
		core.file.SetValue("Audio","sfx",1);
		core.file.SetValue("Gameplay","max",100);
		core.file.SetValue("Gameplay","dif",1);
		core.file.Save("user://Save.ini");
		_Ready();
		foreach (Keybind item in GetChild(1).GetChild(0).GetChildren())
		{
			item._Ready();
		}
	}
}
