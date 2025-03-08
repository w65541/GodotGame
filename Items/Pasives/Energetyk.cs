using Godot;
using System;

public partial class Energetyk : BasicItem
{
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		op=30;
		data=new itemData{
			name="Brokuł",
			level=2,
			opis="Zwiększa prędkość poruszania o 30%",
			sprite="res://Items/Textures/brokuł.png",
			scene=""
		};
		stats=new Stats{damageMult=1.2f};
		base._Ready();
	}

	public override void levelup()
    {
        level++;
		data.level++;
		switch(level)
		{
			case 2:
			stats.speedMult=1.3f;
			
			break;
			case 3:
			stats.speedMult=1.4f;
			break;
			case 4:
			stats.speedMult=1.5f;
			break;
			case 5:
			stats.speedMult=1.6f;
			break;
			case 6:
			stats.speedMult=1.7f;
			break;
			case 7:
			stats.speedMult=2f;
			break;
		}
		op+=10;
		data.opis="Zwiększa prędkość poruszania o "+op+"%";
		player.updateStats();
    }
}
