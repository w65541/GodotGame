using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class levelupmenu : NinePatchRect
{
	
	// Called when the node enters the scene tree for the first time.
	ConfigFile file=new ConfigFile();
	public List<itemData> items=new List<itemData>();
	public List<itemData> weapons=new List<itemData>();
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
		Visible=false;
	}

	public void rollLevelUp()
	{
		GetTree().Paused = true;
		int childCount=0,x;
		for (var i=childCount;i < 4; i++)
				{
					GetChild<level_up_choice>(childCount).Visible=true;
				}
		var weaponsTemp=new List<itemData>( weapons);
		var itemTemp=new List<itemData>( items);
		var weaponsInTree=GetTree().GetNodesInGroup("Weapons");
		var itemsInTree=GetTree().GetNodesInGroup("Items");
		List<Levelable> wep=new List<Levelable>();
		List<Levelable> ite=new List<Levelable>();
		List<int> previousX1=new List<int>();
		List<int> previousX2=new List<int>();
		var pasives=new RandomNumberGenerator().RandiRange(0,4);
		foreach (var item in itemsInTree.Cast<Levelable>())
		{
			if(item.GetItemData().level<3)
			{
				ite.Add(item);
			}
		}
		foreach (var item in weaponsInTree.Cast<Levelable>())
		{
			if(item.GetItemData().level<3)
			{
				wep.Add(item);
			}
		}
		//var newIte=items.Where(x=>)
		int weaponCount=4-pasives;
		if(weaponCount>wep.Count && weaponsInTree.Count==6) 
		{
			weaponCount=wep.Count;
			pasives=4-weaponCount;
			}
		if(pasives>ite.Count && itemsInTree.Count==6) pasives=ite.Count;
				
				int coin;
				int usedweapons=0,useditems=0;
				
				for (int i = 0; i < weaponCount; i++)
				{
					coin=new RandomNumberGenerator().RandiRange(0,1);
					if((coin==1 || weaponsInTree.Count==6)&& usedweapons<wep.Count)
					{
						do
						{
							x=new RandomNumberGenerator().RandiRange(1,wep.Count);
						} while (previousX1.Find(z=>z==x)!=0);
						GetChild<level_up_choice>(childCount).updateOld( wep[x-1]);
						
						usedweapons++;
					}else{
						do
						{
							x=new RandomNumberGenerator().RandiRange(1,weaponsTemp.Count);
						} while (previousX2.Find(z=>z==x)!=0);
						GetChild<level_up_choice>(childCount).updateNew(weaponsTemp[x-1]);
					
					}
					childCount++;
				}

				previousX1=new List<int>();
		 		previousX2=new List<int>();

				for (int i = 0; i < pasives; i++)
				{
					coin=new RandomNumberGenerator().RandiRange(0,1);
					if((coin==1 || itemsInTree.Count==6) && useditems<ite.Count)
					{
						do
						{
							x=new RandomNumberGenerator().RandiRange(1,ite.Count);
						} while (previousX1.Find(z=>z==x)!=0);
						GetChild<level_up_choice>(childCount).updateOld(ite[x-1]);
						useditems++;
					}else{
						do
						{
							x=new RandomNumberGenerator().RandiRange(1,itemTemp.Count);
						} while (previousX2.Find(z=>z==x)!=0);
						GetChild<level_up_choice>(childCount).updateNew(itemTemp[x-1]);
					}
					childCount++;
				}
				GD.Print("LevelUp");
				GD.Print("Weapons: "+weaponCount);
				GD.Print("Used: "+usedweapons);
				GD.Print("Passives: "+pasives);
				GD.Print("Used: "+useditems);
				for (var i=childCount;i < 4; i++)
				{
					GetChild<level_up_choice>(childCount).Visible=false;
				}
		
	}
}
