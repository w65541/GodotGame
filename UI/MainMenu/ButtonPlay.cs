using Godot;
using System;

public partial class ButtonPlay : TextureButton
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{//menu=GetParent<CanvasItem>();
		//main= GetTree().Root.GetNode("Main");
		Level=GD.Load<PackedScene>("res://UI/LevelSelect/LevelSelect.tscn");
	}
PackedScene  Level;
Control menu;
Node main;
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
	public void _on_button_up()
	{
		
		GetParent<CanvasItem>().Visible=false;
		var instance = Level.Instantiate();
		GetParent().AddChild(instance);
	}
}
