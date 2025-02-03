using Godot;
using System;
using System.Collections.Generic;

public partial class StatShopContainer : NinePatchRect
{
	public void updateAllCost(){
		foreach (StatShop item in GetChildren())
		{
			item.updateCost();
		}
	}
}
