using Godot;
using System;

public partial class Duration : BasicItem
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{op=30;
		data=new itemData{
			name="Zegar",
			level=2,
			opis="Zwiększa czas trwania o 30%",
			sprite="res://Items/Textures/duration.png",
			scene=""
		};
		stats=new Stats{durationMult=1.2f};
		base._Ready();
	}
public override void levelup()
    {
        level++;
		data.level++;
		switch(level)
		{
			case 2:
			stats.durationMult=1.3f;
			
			break;
			case 3:
			stats.durationMult=1.4f;
			break;
			case 4:
			stats.durationMult=1.5f;
			break;
			case 5:
			stats.durationMult=1.6f;
			break;
			case 6:
			stats.durationMult=1.7f;
			break;
			case 7:
			stats.durationMult=2f;
			break;
		}
		op+=10;
		data.opis="Zwiększa czas trwania o "+op+"%";
		player.updateStats();
    }
}
