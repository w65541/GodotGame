using Godot;
using System;

public partial class CharacterShopTile : NinePatchRect
{
	public Core core;
	public int cost;
	public TextureButton buton;
	public string name;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		buton=GetChild<TextureButton>(2);
		core=GetTree().Root.GetChild<Core>(0);
		buton.GetChild<RichTextLabel>(0).Text=""+cost;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(core.inventory[0].amount<cost){
			buton.Disabled=true;
		}else{
			buton.Disabled=false;
		}
	}
	public  void _on_button_play_5_button_up(){
		if(core.inventory[0].amount<cost){
		core.updateMat("money",core.inventory[core.inventory.FindIndex(x=>x.name.Equals("money"))].amount-cost);
		core.updateChar(name);
		QueueFree();}
	}
}
