using Godot;
using System;

public partial class UpL2 : ChunkBase
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
	}

    
    public override void generateChunks()
    {
		ChunkBase instance;
        foreach (RayCast2D item in GetChild(1).GetChildren())
		{
			if(item.GetCollider() == null)
			{
				//int num= ((int)(Math.Abs(item.GlobalPosition.X))+(int)(Math.Abs(item.GlobalPosition.Y))+seed)%chunkNumber+1;
				//var instance=chunks[num].Instantiate() as ChunkBase;
				if(item.Name.ToString().Contains("U"))
				{
					instance=chunks.Instantiate() as ChunkBase;//temp
				}
				if(item.Name.ToString().Contains("D"))
				{
					instance=chunks.Instantiate() as ChunkBase;//temp
				}else{
					instance=chunks.Instantiate() as MiddleL2;//temp
				}
				
				instance.GlobalPosition=item.GlobalPosition;
				GD.Print(item.GlobalPosition);
				main.AddChild(instance);
			}
		}
    }
}
