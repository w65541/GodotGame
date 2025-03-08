using Godot;
using System;

public partial class Expup : BasicItem
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{op=30;
		data=new itemData{
			name="Expup",
			level=2,
			opis="Zwiększa  zdobywane doswiadczenie o 30%",
			sprite="res://Items/Textures/Exp.png",
			scene=""
		};
		stats=new Stats{expMult=1.2f};
		base._Ready();
	}
public override void levelup()
    {
        level++;
		data.level++;
		switch(level)
		{
			case 2:
			stats.expMult=1.3f;
			
			break;
			case 3:
			stats.expMult=1.4f;
			break;
			case 4:
			stats.expMult=1.5f;
			break;
			case 5:
			stats.expMult=1.6f;
			break;
			case 6:
			stats.expMult=1.7f;
			break;
			case 7:
			stats.expMult=2f;
			break;
		}
		op+=10;
		data.opis="Zwiększa  zdobywane doswiadczenie o  "+op+"%";
		player.updateStats();
    }

}

