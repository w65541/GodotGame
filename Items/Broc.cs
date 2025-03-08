using Godot;
using System;

public partial class Broc : BasicItem
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		op=30;
		data=new itemData{
			name="Brokuł",
			level=2,
			opis="Zwiększa obrażenia o 30%",
			sprite="res://Items/Textures/brokuł.png",
			scene=""
		};
		stats=new Stats{damageMult=1.2f};
		base._Ready();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	/*public override void _Process(double delta)
	{
	}*/

    public override void levelup()
    {
        level++;
		data.level++;
		switch(level)
		{
			case 2:
			stats.damageMult=1.3f;
			
			break;
			case 3:
			stats.damageMult=1.4f;
			break;
			case 4:
			stats.damageMult=1.5f;
			break;
			case 5:
			stats.damageMult=1.6f;
			break;
			case 6:
			stats.damageMult=1.7f;
			break;
			case 7:
			stats.damageMult=2f;
			break;
		}
		player.updateStats();
		op+=10;
		data.opis="Zwiększa obrazenia o "+op+"%";
    }
}
