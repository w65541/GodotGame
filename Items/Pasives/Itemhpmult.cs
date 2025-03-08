using Godot;
using System;

public partial class Itemhpmult : BasicItem
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		op=30;
		data=new itemData{
			name="Serce",
			level=2,
			opis="Zwiększa  ilosc zycia o 30%",
			sprite="res://Items/Textures/Hp.png",
			scene=""
		};
		stats=new Stats{hpMult=1.2f};
		base._Ready();
	}
public override void levelup()
    {
        level++;
		data.level++;
		switch(level)
		{
			case 2:
			stats.hpMult=1.3f;
			
			break;
			case 3:
			stats.hpMult=1.4f;
			break;
			case 4:
			stats.hpMult=1.5f;
			break;
			case 5:
			stats.hpMult=1.6f;
			break;
			case 6:
			stats.hpMult=1.7f;
			break;
			case 7:
			stats.hpMult=2f;
			break;
		}
		op+=10;
		data.opis="Zwiększa ilosc zycia o "+op+"%";
		player.updateStats();
    }

}
