using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class levelupmenu : NinePatchRect
{
	
	// Called when the node enters the scene tree for the first time.
	ConfigFile file=new ConfigFile();
	List<itemData> items=new List<itemData>();
	List<itemData> weapons=new List<itemData>();
	public override void _Ready()
	{
		file.Load("res://Configs/Items.ini");
		foreach(String x in file.GetSections())
		{
		var toSort=new itemData{
			name=(String)file.GetValue(x, "name"),
			opis=(String)file.GetValue(x, "opis"),
			sprite=(String)file.GetValue(x, "sprite"),
			scene=(String)file.GetValue(x, "scene")
			};
			if((bool) file.GetValue(x,"passive"))
			{
				items.Add(toSort); 
			}else{
				weapons.Add(toSort); 
			}
		}
		GD.Print(items.Count);
	}

	public void rollLevelUp()
	{
		int childCount=0;
		var wep=GetTree().GetNodesInGroup("Weapons");
		var ite=GetTree().GetNodesInGroup("Items");
		//var newIte=items.Where(x=>)
		if(wep.Count<6 || ite.Count<6)
			{
				var pasives=new RandomNumberGenerator().RandiRange(0,4);
				int coin,x;
				for (int i = 0; i < 4-pasives; i++)
				{
					coin=new RandomNumberGenerator().RandiRange(0,1);
					if(coin==1 || wep.Count==6)
					{
						x=new RandomNumberGenerator().RandiRange(0,wep.Count-1);
						GetChild<level_up_choice>(childCount).updateOld( (Levelable)wep[x]);
					}else{
						x=new RandomNumberGenerator().RandiRange(0,weapons.Count-1);
						GetChild<level_up_choice>(childCount).updateNew(weapons[x]);
						weapons.RemoveAt(x);
					}
					childCount++;
				}
				for (int i = 0; i < pasives; i++)
				{
					coin=new RandomNumberGenerator().RandiRange(0,1);
					if(coin==1 || ite.Count==6)
					{
						x=new RandomNumberGenerator().RandiRange(0,wep.Count-1);
						GetChild<level_up_choice>(childCount).updateOld((Levelable)ite[x]);
					}else{
						x=new RandomNumberGenerator().RandiRange(0,weapons.Count-1);
						GetChild<level_up_choice>(childCount).updateNew(items[x]);
						items.RemoveAt(x);
					}
					childCount++;
				}
			}else{

			}
		
	}
}
