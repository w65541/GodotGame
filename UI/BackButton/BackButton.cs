using Godot;
using System;

public partial class BackButton : TextureButton
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print(new Stats());
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Visible=GetParent().GetChild<CanvasItem>(0).Visible;
	}
	public void _on_button_up()
	{
		GetParent().GetParent<CanvasItem>().Visible=true;
		GetParent().QueueFree();
	}
}
