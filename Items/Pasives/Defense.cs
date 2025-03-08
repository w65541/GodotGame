using Godot;
using System;

public partial class Defense : BasicItem
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{op=2;
		data=new itemData{
			name="Tarcza",
			level=2,
			opis="Zwiększa obrone o 2",
			sprite="res://Items/Textures/Obrona.png",
			scene=""
		};
		stats=new Stats{defense=2f};
		base._Ready();
	}
public override void levelup()
    {
        level++;
		data.level++;
		switch(level)
		{
			case 2:
			stats.defense=3f;
			
			break;
			case 3:
			stats.defense=4f;
			break;
			case 4:
			stats.defense=5f;
			break;
			case 5:
			stats.defense=6f;
			break;
			case 6:
			stats.defense=7f;
			break;
			case 7:
			stats.defense=8f;
			break;
		}
		op+=1;
		data.opis="Zwiększa obrone o "+op;
		player.updateStats();
    }
}
