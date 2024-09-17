using Godot;
using System;

public partial class TargetClosest : Node2D
{
	Player player;
	public EnemyBasic enemy;
	public override void _Ready()
	{
		
	}
	public Vector2 position;
	public float rotate;
		public  void _on_timer_timeout()
		{
			player=GetTree().GetFirstNodeInGroup("Player") as Player;
			var enem=GetTree().GetNodesInGroup("Enemy");
			Node2D close=new Node2D();
			float max = 9999999999f;
			foreach (Node2D item in enem)
			{
			//GD.Print(player.GlobalPosition.DistanceSquaredTo(item.GlobalPosition));
			if(player.GlobalPosition.DistanceSquaredTo(item.GlobalPosition)<max)
			{
				max=player.Position.DistanceSquaredTo(item.Position);
				close=item;
				//GD.Print(item);
			}
			}
			enemy=close as EnemyBasic;
			position=close.Position;
			rotate=player.Position.AngleToPoint(close.Position)+Vector2.Down.Angle();;
			//GD.Print("Updated closest "+rotate+" "+position.X);
		}

	
}
