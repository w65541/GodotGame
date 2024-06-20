using Godot;
using System;

public partial class TextPlay : RichTextLabel
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _on_button_play_mouse_entered()
	{
		AddThemeColorOverride("default_color",Colors.White);
		//Theme.SetColor("","",Colors.White);
	}
	public void _on_button_play_mouse_exited()
	{
AddThemeColorOverride("default_color",Colors.Black);
	}
}
