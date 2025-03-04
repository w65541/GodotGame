using Godot;
using System;
using System.Collections.Generic;

public partial class Core : Node
{
	public ConfigFile file=new ConfigFile();
	public List<characterStatus> unlocked=new List<characterStatus>();
	public List<characterStatus> locked=new List<characterStatus>();
	public List<material> inventory=new List<material>();
	public Dictionary<string,int> shopStatus=new Dictionary<string,int>();
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		file.Load("res://Configs/Save.ini");
		foreach (var key in file.GetSectionKeys("Characters"))
		{
			string temp=(String)file.GetValue("Characters",key);
			var tem=temp.Split(":");
			if(int.Parse(tem[0])==1){
				unlocked.Add(new characterStatus{name=key,unlocked=int.Parse(tem[0]),level=int.Parse(tem[1]),skill=int.Parse(tem[2])});
			}else{
				locked.Add(new characterStatus{name=key,unlocked=int.Parse(tem[0]),level=int.Parse(tem[1]),skill=int.Parse(tem[2])});
			}
		} ;
		foreach (var key in file.GetSectionKeys("Inventory"))
		{
			long temp=(long)file.GetValue("Inventory",key);
			inventory.Add(new material{name=key,amount=temp});
		} ;
		foreach (var key in file.GetSectionKeys("Shop"))
		{
			int temp=(int)file.GetValue("Shop",key);
			shopStatus.Add(key,temp);
		} ;
		foreach (var key in file.GetSectionKeys("Controls"))
		{
			string temp=(string)file.GetValue("Controls",key);
			InputMap.ActionEraseEvents(key);
			InputEventKey input=new InputEventKey();
			input.Keycode=OS.FindKeycodeFromString(temp);
					InputMap.ActionAddEvent(key,input);
		} ;
	}
	public void updateChar(string name,int unl=1,int level=1,int skill=1)
	{
		
		string x=unl+":"+level+":"+skill;
		GD.Print(x);
		file.SetValue("Characters",name,x);
		var ind=unlocked.FindIndex(x=>x.name.Equals(name));
		if(ind!=-1){
			unlocked[ind]=new characterStatus{name=name,level=level,skill=skill,unlocked=1};
		}else{
			unlocked.Add(new characterStatus{name=name,level=1,skill=1,unlocked=1});
		}
		/*foreach (var key in file.GetSectionKeys("Characters"))
		{
			string temp=(String)file.GetValue("Characters",key);
			var tem=temp.Split(":");
			
		};*/
		file.Save("res://Configs/Save.ini");
	}
	public void updateMat(string name,long x)
	{	
		var temp=inventory.FindIndex(x=>x.name.Equals(name));
		
		inventory[temp]=new material{name=name,amount=x};
		GD.Print(inventory[temp].amount);
		file.SetValue("Inventory",name,x);
		file.Save("res://Configs/Save.ini");
	}
	public void addMat(string name,long x)
	{	
		var temp=inventory.FindIndex(x=>x.name.Equals(name));
		
		inventory[temp]=new material{name=name,amount=inventory[temp].amount+x};
		GD.Print(inventory[temp].amount);
		file.SetValue("Inventory",name,inventory[temp].amount);
		file.Save("res://Configs/Save.ini");
	}
	public void updateShop(string name,int x)
	{	
		shopStatus[name]=x;
		
		
		file.SetValue("Shop",name,x);
		file.Save("res://Configs/Save.ini");
	}
}
