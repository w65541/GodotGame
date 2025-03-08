using Godot;
using System;

public partial class Keybind : Button
{
	[Export] public string akcja;
	public bool changing=false;
	Core core;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		core=GetTree().Root.GetChild<Core>(0);
		Text=InputMap.ActionGetEvents(akcja)[0].AsText();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void _on_button_down()
	{
		Text="Wciśnij\nklawisz";
		changing=true;
	
	}
	public void _on_gui_input(InputEvent input)
	{	
		if(changing){
			
			if(input.GetType().Equals(new InputEventKey().GetType()))
			{
				InputEventKey inputt=input as InputEventKey;
				if(inputt.Keycode!=Key.Enter && inputt.Keycode!=Key.Escape)
				{
					InputMap.ActionEraseEvents(akcja);
					InputMap.ActionAddEvent(akcja,input);
					
				}
				changing=false;
				Text=InputMap.ActionGetEvents(akcja)[0].AsText();
				core.file.SetValue("Controls",akcja,Text);
				core.file.Save("user://Save.ini");
			}
			
			
			
		}
	}
}
