using Godot;
using System;

public partial class Broc : BasicItem
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		stats=new Stats{damageMult=1.2f};
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	/*public override void _Process(double delta)
	{
	}*/

    public override void levelup()
    {
        level++;
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
    }
}
