using Godot;
using System;

public partial class ChunkBase : Node2D
{
	public int chunkNumber=1;
	public int seed=0;
	public PackedScene chunks;
	public Node2D main,player;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//chunks=GetParent<BasicLevel>.chunks;
		//chunkNumber=GetParent<BasicLevel>.chunkNumber;
		//seed=GetParent<BasicLevel>.seed;
		chunks=GD.Load<PackedScene>("res://Chunks/chunk_base.tscn");//temp
		main= GetTree().GetFirstNodeInGroup("Main") as Node2D;
		//player= GetTree().GetFirstNodeInGroup("Player") as Node2D;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
//		if(GlobalPosition.DistanceTo(player.GlobalPosition)>6000) QueueFree();
	}
	public virtual void generateChunks()
	{
		foreach (RayCast2D item in GetChild(1).GetChildren())
		{
			if(item.GetCollider() == null)
			{
				//int num= ((int)(Math.Abs(item.GlobalPosition.X))+(int)(Math.Abs(item.GlobalPosition.Y))+seed)%chunkNumber+1;
				//var instance=chunks[num].Instantiate() as ChunkBase;
				var instance=chunks.Instantiate() as ChunkBase;//temp
				instance.GlobalPosition=item.GlobalPosition;
				GD.Print(item.GlobalPosition);
				main.AddChild(instance);
			}
		}
	}
	public void _on_area_2d_body_entered (Node2D node)
	{
		GD.Print("aaaaaaaaaaaaaaaaaaaaaaaaaaaaa"+node.Name);
		if(node.GetParent().GetType().IsAssignableTo(new Player().GetType()))//(node==player)
		{
			generateChunks();
		}
	}
}
