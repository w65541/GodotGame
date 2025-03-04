using Godot;
using System;

public partial class UpgradeButton : TextureButton
{
	[Export] bool levelup=true;
	character_details chardata;
	Core core;
	long expBar=100;
	RichTextLabel ammount;
	 HBoxContainer box;
	 characterStatus status;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
		chardata=GetTree().GetFirstNodeInGroup("CharacterDetails") as character_details;
		core=GetTree().Root.GetChild<Core>(0) as Core;
		status=core.unlocked.Find(x=>x.name.Equals(chardata.name));
		GD.Print(status.toString());
		expBar=100*status.level;
		
		if(levelup){
			ammount=GetParent().GetChild<RichTextLabel>(1);
			var temp=core.inventory.Find(x=>x.name.Equals("money"));
			ammount.Text=temp.amount+"/"+expBar;
			if(temp.amount<expBar){
				ammount.AddThemeColorOverride("default_color",Colors.Red);
			}else{
				ammount.AddThemeColorOverride("default_color",Colors.White);
			}
		}else{
			box=GetParent().GetChild<HBoxContainer>(0);
			updateMats();
		}
	}
	public void updateMats(){
		var skilllevel=status.skill;
		var temp=(string)chardata.character.GetValue(status.name,"material");
		var mats=temp.Split(":");
			if(skilllevel<2)
		{
			var m=core.inventory.Find(x=>x.name.Equals(mats[0]));
			
			var tex =(Texture2D) GD.Load("res://Items/Textures/Material/"+mats[0]+".png"); 
			box.GetChild<TextureRect>(0).Texture=tex;
			box.GetChild<RichTextLabel>(1).Text=m.amount+"/"+skilllevel;
			if(m.amount<skilllevel)
			{
				box.GetChild<RichTextLabel>(1).AddThemeColorOverride("default_color",Colors.Red);
			//update stats in details
			}
			return;
		}	
		if(skilllevel<3)
		{

			var m1=core.inventory.Find(x=>x.name.Equals(mats[0]));
			var m2=core.inventory.Find(x=>x.name.Equals(mats[1]));

			var tex =(Texture2D) GD.Load("res://Items/Textures/Material/"+mats[0]+".png"); 
			box.GetChild<TextureRect>(0).Texture=tex;
			box.GetChild<RichTextLabel>(1).Text=m1.amount+"/"+skilllevel;

			tex =(Texture2D) GD.Load("res://Items/Textures/Material/"+mats[1]+".png"); 
			box.GetChild<TextureRect>(2).Texture=tex;
			box.GetChild<RichTextLabel>(3).Text=m1.amount+"/"+skilllevel;
			box.GetChild<TextureRect>(2).Visible=true;
			box.GetChild<RichTextLabel>(3).Visible=true;
			
			if(m1.amount<skilllevel) 
			{
				box.GetChild<RichTextLabel>(1).AddThemeColorOverride("default_color",Colors.Red);
			//update stats in details
			}
			if(m2.amount<skilllevel){
				box.GetChild<RichTextLabel>(3).AddThemeColorOverride("default_color",Colors.Red);
			//update stats in details
			}
			return;
		}	
		if(skilllevel==6)
		{

			var m1=core.inventory.Find(x=>x.name.Equals(mats[0]));
			var m2=core.inventory.Find(x=>x.name.Equals(mats[1]));
			var m3=core.inventory.Find(x=>x.name.Equals(mats[2]));

			var tex =(Texture2D) GD.Load("res://Items/Textures/Material/"+mats[0]+".png"); 
			box.GetChild<TextureRect>(0).Texture=tex;
			box.GetChild<RichTextLabel>(1).Text=m1.amount+"/"+skilllevel;

			tex =(Texture2D) GD.Load("res://Items/Textures/Material/"+mats[1]+".png"); 
			box.GetChild<TextureRect>(2).Texture=tex;
			box.GetChild<RichTextLabel>(3).Text=m1.amount+"/"+skilllevel;
			box.GetChild<TextureRect>(2).Visible=true;
			box.GetChild<RichTextLabel>(3).Visible=true;

			tex =(Texture2D) GD.Load("res://Items/Textures/Material/"+mats[2]+".png"); 
			box.GetChild<TextureRect>(4).Texture=tex;
			box.GetChild<RichTextLabel>(5).Text=m1.amount+"/"+skilllevel;
			box.GetChild<TextureRect>(4).Visible=true;
			box.GetChild<RichTextLabel>(5).Visible=true;

			if(m1.amount<skilllevel) 
			{
				box.GetChild<RichTextLabel>(1).AddThemeColorOverride("default_color",Colors.Red);
			//update stats in details
			}
			if(m2.amount<skilllevel){
				box.GetChild<RichTextLabel>(3).AddThemeColorOverride("default_color",Colors.Red);
			//update stats in details
			}
			if(m3.amount<skilllevel){
				box.GetChild<RichTextLabel>(5).AddThemeColorOverride("default_color",Colors.Red);
			//update stats in details
			}
			
			return;
		}	
	}
	public  void levelupChar()
	{
		var temp=GetTree().Root.GetChild<Core>(0).inventory.Find(x=>x.name.Equals("money"));
		GD.Print(temp.amount);
		if(temp.amount>=expBar)
		{
			core.updateChar(status.name,1,status.level+1,status.skill);
			core.updateMat("money",temp.amount-expBar);
			temp.amount-=expBar;
			//temp.amount-=expBar;
			expBar=(status.level+1)*100;
			ammount.Text=(temp.amount)+"/"+expBar;
			if(temp.amount<expBar){
				ammount.AddThemeColorOverride("default_color",Colors.Red);
			}else{
				AddThemeColorOverride("default_color",Colors.White);
			}
			status.level++;
			//update stats in details
		}
	}
	public  void levelupSkill()
	{
		var temp=(string)chardata.character.GetValue(status.name,"material");
		var mats=temp.Split(":");
		
		if(status.skill<5)
		{
			var m=core.inventory.Find(x=>x.name.Equals(mats[0]));
			if(m.amount>=status.skill)
			{
				core.updateMat(mats[0],m.amount-status.skill);
				core.updateChar(status.name,1,status.level,status.skill+1);
			
			m.amount-=status.skill;
			//update stats in details
			}
			updateMats();
			return;
		}	
		if(status.skill<6)
		{
			var m1=core.inventory.Find(x=>x.name.Equals(mats[0]));
			var m2=core.inventory.Find(x=>x.name.Equals(mats[1]));
			if(m1.amount>=status.skill && m2.amount>=status.skill)
			{
				
			core.updateMat(mats[0],m1.amount-status.skill);
			m1.amount-=status.skill;
			core.updateMat(mats[1],m2.amount-status.skill);
			m2.amount-=status.skill;
			core.updateChar(status.name,1,status.level,status.skill+1);
			//update stats in details
			}
			updateMats();
			return;
		}	
		if(status.skill==6)
		{
			var m1=core.inventory.Find(x=>x.name.Equals(mats[0]));
			var m2=core.inventory.Find(x=>x.name.Equals(mats[1]));
			var m3=core.inventory.Find(x=>x.name.Equals(mats[2]));
			if(m1.amount>=status.skill && m2.amount>=status.skill && m3.amount>=status.skill)
			{
				
			core.updateMat(mats[0],m1.amount-status.skill);
			m1.amount-=status.skill;
			core.updateMat(mats[1],m2.amount-status.skill);
			m2.amount-=status.skill;
			core.updateMat(mats[2],m3.amount-status.skill);
			m3.amount-=status.skill;
			//update stats in details
			core.updateChar(status.name,1,status.level,status.skill+1);
			}
			updateMats();
			return;
		}	
			//update stats in details
		
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
