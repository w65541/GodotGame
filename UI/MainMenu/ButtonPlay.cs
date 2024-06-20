using Godot;
using System;

public partial class ButtonPlay : TextureButton
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}
PackedScene  Level;
Control menu;
Node main;
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		menu=(Control)GetParent();
		main= GetTree().Root.GetNode("Main");
		Level=GD.Load<PackedScene>("res://Main.tscn");
	}
	public void _on_button_up()
	{
		
		menu.Visible=!menu.Visible;
		var instance = Level.Instantiate();
		main.AddChild(instance);
	}
}
