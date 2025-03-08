using Godot;
using System;
using System.Linq;

public partial class UiBasic : Control
{
	Player player;
	BasicLevel main;
	ProgressBar hpbar,expbar, specialbar;
	Control itemicons,itemlevels;
	ColorRect dodge;
	RichTextLabel explabel;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		player=(Player) GetTree().GetFirstNodeInGroup("Player");
		main=(BasicLevel) GetTree().GetFirstNodeInGroup("Main");
		hpbar=GetChild<ProgressBar>(5);
		expbar=GetChild<ProgressBar>(3);
		specialbar=GetChild<ProgressBar>(4);
		itemicons=GetChild<Control>(7);
		itemlevels=GetChild<Control>(8);
		dodge=GetChild<ColorRect>(6);
		explabel=GetChild<RichTextLabel>(9);
		updateItems();
	}
	long prev=0;
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("ui_special") && specialbar.Value==100)
			{
				specialbar.Value=0;
			}
		hpbar.MaxValue=player.stats.maxHp;
		hpbar.Value=player.hp;
		expbar.MaxValue=main.nextLevelExp;
		expbar.Value=main.exp;
		explabel.Text="Level "+main.levelcount;
		if(player.DodgeCooldown.TimeLeft==0){
			dodge.Color=Color.FromString("Green",Color.Color8(255,255,255));
		}else{
			dodge.Color=Color.Color8(0,0,0);
		}
		if(prev<main.deathcount && specialbar.Value<100){
			specialbar.Value+=main.deathcount-prev;
			}else{
				specialbar.Value=100;
				player.specialReady=true;
			}
			prev=main.deathcount;
	}

	public void updateItems(){
		var itemsInTree=GetTree().GetNodesInGroup("Items");
		var weaponsInTree=GetTree().GetNodesInGroup("Weapons");
		int i=0;
		foreach (var item in weaponsInTree.Cast<Weapon>())
		{
			var temp=itemicons.GetChild<TextureRect>(i);
			temp.Texture=(Texture2D) GD.Load(item.GetItemData().sprite);
			temp=itemlevels.GetChild<TextureRect>(i);
			temp.Texture=(Texture2D) GD.Load("res://UI/Texures/InGame/ItemLevel/level"+(item.GetItemData().level-1)+".png");
			i++;
		}
		i=6;
		foreach (var item in itemsInTree.Cast<BasicItem>())
		{
			var temp=itemicons.GetChild<TextureRect>(i);
			temp.Texture=(Texture2D) GD.Load(item.GetItemData().sprite);
			temp=itemlevels.GetChild<TextureRect>(i);
			temp.Texture=(Texture2D) GD.Load("res://UI/Texures/InGame/ItemLevel/level"+(item.GetItemData().level-1)+".png");
			i++;
		}
	}
}
