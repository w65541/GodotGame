using Godot;
using System;

public partial class BasicItem : Node2D,Levelable
{
    public Stats stats;
    [Export] public string texturePath;
    public Player player;
    public int level=1;
	public itemData data;
    public int op;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        player=(Player) GetParent();
        player.updateStats();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

    public virtual void levelup()
    {}

    public itemData GetItemData()
    {
        return data;
    }
    /*
public override void levelup()
{
   level++;
   switch(level)
   {
       case 2:

       break;
       case 3:

       break;
       case 4:

       break;
       case 5:

       break;
       case 6:

       break;
       case 7:

       break;
   }
}
*/
}