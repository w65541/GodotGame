using Godot;
using System;

public partial class Mleko : BasicItem
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		op=30;
		data=new itemData{
			name="Brokuł",
			level=2,
			opis="Zwiększa Wielkosc o 30%",
			sprite="res://Items/Textures/Mleko.png",
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
			stats.size=1.3f;
			
			break;
			case 3:
			stats.size=1.4f;
			break;
			case 4:
			stats.size=1.5f;
			break;
			case 5:
			stats.size=1.6f;
			break;
			case 6:
			stats.size=1.7f;
			break;
			case 7:
			stats.size=2f;
			break;
		}
		op+=10;
		data.opis="Zwiększa wielkosc o "+op+"%";
		player.updateStats();
    }
}
