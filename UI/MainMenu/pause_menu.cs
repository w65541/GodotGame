using Godot;
using System;

public partial class pause_menu : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("ui_cancel"))
    {
        // Move as long as the key/button is pressed.
        this.Visible=!this.Visible;
		GetTree().Paused = !GetTree().Paused;
    }
	}
}
