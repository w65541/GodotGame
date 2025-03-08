using Godot;
using System;
using System.Linq;

public partial class BasicLevel : Node2D
{
	public ConfigFile level;
	public string name;
	public string charatcer="";//"res://Players/Trooper/trooper.tscn";//
	public string passive1="";
	public string passive2="";
	public levelupmenu levelupmenu;
	public float exp=0f;
	public int levelcount=1;
	public long deathcount=0;
	public float nextLevelExp=10f; 
	public long activeEnemies=0;
	public long enemyProjectiles=0;
	public PackedScene material=GD.Load<PackedScene>("res://Items/Pickable/Material/material.tscn");
	[Export] public string[] materials={"red","green","blue"};
	Core core;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var core=GetTree().Root.GetChild<Core>(0);
		GD.Print(level.GetSectionKeys(name));
		//level.Load("res://Configs/Levels.ini");
		if(charatcer.Equals("")) charatcer="res://Players/Trooper/trooper.tscn";
		var player=GD.Load<PackedScene>(charatcer);
		var instance=player.Instantiate<Player>();
		instance.Name="Player";
		AddChild(instance);
		instance.GlobalPosition=new Vector2(0,0);
		string x;
		PackedScene ele;
		GD.Print(GetTreeStringPretty());
			int spawnNum=(int)level.GetValue(name,"spawnerNumber");
			for (int i = 0; i < spawnNum; i++)
			{
			x=(String)level.GetValue(name,"spawner"+(i+1));
			ele=GD.Load<PackedScene>(x);
			GetNode("Player").AddChild(ele.Instantiate());
			}
			

			x=(String)level.GetValue(name,"camera");
			ele=GD.Load<PackedScene>(x);
			GetNode("Player").AddChild(ele.Instantiate());

			int itemNum=(int)level.GetValue(name,"itemSpawnerNumber");
			for (int i = 0; i < itemNum; i++)
			{
			x=(String)level.GetValue(name,"itemSpawner"+(i+1));
			ele=GD.Load<PackedScene>(x);
			GetNode("Player").AddChild(ele.Instantiate());
			}

			x=(String)level.GetValue(name,"levelupMenu");
			ele=GD.Load<PackedScene>(x);
			GetNode("Player").AddChild(ele.Instantiate());

			x=(String)level.GetValue(name,"pauseMenu");
			ele=GD.Load<PackedScene>(x);
			GetNode("Player").AddChild(ele.Instantiate());

			x=(String)level.GetValue(name,"gameoverMenu");
			ele=GD.Load<PackedScene>(x);
			GetNode("Player").AddChild(ele.Instantiate());
			x=(String)level.GetValue(name,"winMenu");
			ele=GD.Load<PackedScene>(x);
			GetNode("Player").AddChild(ele.Instantiate());
			x=(String)level.GetValue(name,"ui");
			ele=GD.Load<PackedScene>(x);
			GetNode("Player").AddChild(ele.Instantiate());
			
		levelupmenu=GetTree().GetFirstNodeInGroup("LevelUpMenu") as levelupmenu;
	
			if(passive1!=""){
			ele=GD.Load<PackedScene>(passive1);
			GetNode("Player").AddChild(ele.Instantiate());}
			if(passive2!=""){
			ele=GD.Load<PackedScene>(passive2);
			GetNode("Player").AddChild(ele.Instantiate());}

	}
	public  void _on_timer_timeout(){
		int number=name.Last()+1;
		if(number<5){
			core.file.SetValue("Level","Level"+number,1);
			core.file.Save("user://Save.ini");
		}
		GetNode<EndScreen>("Winscreen").activate();
	}
	public void death(){
		GetNode<EndScreen>("EndScreen").activate();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(exp>=nextLevelExp)
		{
			levelcount++;
			exp-=nextLevelExp;
			nextLevelExp*=1.5f;
			levelupmenu.Visible=true;
			levelupmenu.rollLevelUp();
		}
		//
		 /*
		if (Input.IsActionJustPressed("ui_focus_next"))
		{
			levelupmenu.Visible=true;
			levelupmenu.rollLevelUp();
		}
		*/
	}
}
