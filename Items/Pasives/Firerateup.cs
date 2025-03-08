using Godot;
using System;

public partial class Firerateup : BasicItem
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{op=30;
		data=new itemData{
			name="Magazynek",
			level=2,
			opis="Przyspiesza strzelanie o 10%",
			sprite="res://Items/Textures/doublemagazine.png",
			scene=""
		};
		stats=new Stats{hpMult=0.95f};
		base._Ready();
	}
public override void levelup()
    {
        level++;
		data.level++;
		switch(level)
		{
			case 2:
			stats.hpMult=0.9f;
			
			break;
			case 3:
			stats.hpMult=0.85f;
			break;
			case 4:
			stats.hpMult=0.8f;
			break;
			case 5:
			stats.hpMult=0.75f;
			break;
			case 6:
			stats.hpMult=0.7f;
			break;
			case 7:
			stats.hpMult=0.65f;
			break;
		}
		op+=5;
		data.opis="rzyspiesza strzelanie o "+op+"%";
		player.updateStats();
    }

}

