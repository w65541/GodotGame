using Godot;
using System;
using System.Collections.Generic;
public partial class StatShop : NinePatchRect
{
	[Export] public string Nazwa;
	[Export] public string Opis;
	[Export] public string inCodeName;
	[Export] public string Sprite;
	[Export] public int moneyScale;

	RichTextLabel LabelOpis;
	RichTextLabel minusKasa;
	RichTextLabel plusKasa;
	TextureButton plus,minus;
	int level,refund,next;
	Core core;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GetChild<RichTextLabel>(3).Text=Nazwa;
		LabelOpis=GetChild<RichTextLabel>(4);
		plusKasa=GetChild(1).GetChild<RichTextLabel>(1);
		minusKasa=GetChild(2).GetChild<RichTextLabel>(1);
		core=GetTree().Root.GetChild<Core>(0) as Core;
		level=core.shopStatus[inCodeName];
		plus=GetChild<TextureButton>(1);
		minus=GetChild<TextureButton>(2);

		updateCost();
	}
	public void updateCost(){
		if(level==0) {minus.Disabled=true;
		minusKasa.Text="----";
		}else{
			minusKasa.Text=(level*moneyScale)+"";
		}
		next=(level+1)*moneyScale;
		plusKasa.Text=next+"";

		if(core.inventory[core.inventory.FindIndex(x=>x.name.Equals("money"))].amount<next){
			plus.Disabled=true;
			plusKasa.AddThemeColorOverride("default_color",Colors.Red);
		}else{
			plus.Disabled=false;
			plusKasa.AddThemeColorOverride("default_color",Colors.White);
		}
	}
	public void _on_plus_button_up(){
		core.updateShop(inCodeName,level+1);
		core.updateMat("money",core.inventory[core.inventory.FindIndex(x=>x.name.Equals("money"))].amount-next);
		GetParent<StatShopContainer>().updateAllCost();
	}
	public void _on_minus_button_up(){
		core.updateShop(inCodeName,level-1);
		core.updateMat("money",core.inventory[core.inventory.FindIndex(x=>x.name.Equals("money"))].amount+refund);
		GetParent<StatShopContainer>().updateAllCost();
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
