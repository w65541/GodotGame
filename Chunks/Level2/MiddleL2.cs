using Godot;
using System;

public partial class MiddleL2 : ChunkBase
{
	public PackedScene up,down,mid,walled;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		up=GD.Load<PackedScene>("res://Chunks/chunk_base.tscn");//temp
		down=GD.Load<PackedScene>("res://Chunks/chunk_base.tscn");//temp
		mid=GD.Load<PackedScene>("res://Chunks/Level2/chunk_l2.tscn");//temp
		walled=GD.Load<PackedScene>("res://Chunks/chunk_base.tscn");//temp
		base._Ready();
	}

    
    public override void generateChunks()
    {
		ChunkBase instance;
        foreach (RayCast2D item in GetChild(1).GetChildren())
		{
			if(item.GetCollider() == null && (item.Name.ToString().Equals("Left") || item.Name.ToString().Equals("Right")))
			{
				//int num= ((int)(Math.Abs(item.GlobalPosition.X))+(int)(Math.Abs(item.GlobalPosition.Y))+seed)%chunkNumber+1;
				//var instance=chunks[num].Instantiate() as ChunkBase;
				
				instance=mid.Instantiate() as MiddleL2;//temp
				
				
				instance.GlobalPosition=item.GlobalPosition;
				GD.Print(item.GlobalPosition);
				main.AddChild(instance);
			}
		}
    }
}
