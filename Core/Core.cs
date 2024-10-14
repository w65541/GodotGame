using Godot;
using System;
using System.Collections.Generic;

public partial class Core : Node
{
	public ConfigFile file=new ConfigFile();
	public List<characterStatus> unlocked=new List<characterStatus>();
	public List<material> inventory=new List<material>();
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		file.Load("res://Configs/Save.ini");
		foreach (var key in file.GetSectionKeys("Characters"))
		{
			string temp=(String)file.GetValue("Characters",key);
			var tem=temp.Split(":");
			unlocked.Add(new characterStatus{name=key,level=int.Parse(tem[1]),skill=int.Parse(tem[2])});
		} ;
		foreach (var key in file.GetSectionKeys("Inventory"))
		{
			long temp=(long)file.GetValue("Inventory",key);
			inventory.Add(new material{name=key,amount=temp});
		} ;
	}
	public void updateChar(string name,int unl=1,int level=1,int skill=1)
	{
		
		string x=unl+":"+level+":"+skill;
		GD.Print(x);
		file.SetValue("Characters",name,x);
		foreach (var key in file.GetSectionKeys("Characters"))
		{
			string temp=(String)file.GetValue("Characters",key);
			var tem=temp.Split(":");
			unlocked.Add(new characterStatus{name=key,level=int.Parse(tem[1]),skill=int.Parse(tem[2])});
		};
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
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
