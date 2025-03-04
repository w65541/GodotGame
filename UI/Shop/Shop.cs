using Godot;
using System;

public partial class Shop : Control
{
	TabBar tabs;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		tabs=GetChild<TabBar>(2);
	}
	public void _on_tab_bar_tab_changed(int tab){
		GD.Print(tab);
		if(tab==0){
			GetChild<CanvasItem>(0).Visible=true;
			GetChild<CanvasItem>(3).Visible=false;
		}else{
			GetChild<CanvasItem>(3).Visible=true;
			GetChild<CanvasItem>(0).Visible=false;
		}
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.

}
