using Godot;
using System;

public partial class CharacterButton : TextureButton
{
	PackedScene charMenu;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		charMenu=GD.Load<PackedScene>("res://UI/CharacterMenu/Main/character_collection_menu.tscn");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void _on_button_up()
	{
		var instance=charMenu.Instantiate();
		GetParent().AddChild(instance);
		GetParent<CanvasItem>().Visible=false;
	}
}
