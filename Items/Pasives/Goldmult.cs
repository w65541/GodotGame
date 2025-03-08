using Godot;
using System;

public partial class Goldmult : BasicItem
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{op=30;
		data=new itemData{
			name="Mieszek",
			level=2,
			opis="Zwiększa ilosc zdobywanego zlota o 30%",
			sprite="res://Items/Textures/goldplus.png",
			scene=""
		};
		stats=new Stats{goldMult=1.2f};
		base._Ready();
	}
public override void levelup()
    {
        level++;
		data.level++;
		switch(level)
		{
			case 2:
			stats.goldMult=1.3f;
			
			break;
			case 3:
			stats.goldMult=1.4f;
			break;
			case 4:
			stats.goldMult=1.5f;
			break;
			case 5:
			stats.goldMult=1.6f;
			break;
			case 6:
			stats.goldMult=1.7f;
			break;
			case 7:
			stats.goldMult=2f;
			break;
		}
		op+=10;
		data.opis="Zwiększa ilosc zdobywanego zlota o "+op+"%";
		player.updateStats();
    }
}
