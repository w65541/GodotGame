using Godot;
using System;
using System.Linq;

public partial class TargetClosest : Node2D
{

	


	Player player;
	public EnemyBasic enemy;
	public Vector2 position;
	public float rotate=0f;
	
	public Node sortByDis(Node a,Node b){
		
		Node2D a2D=a as Node2D;
		Node2D b2D=b as Node2D;
		if(player.GlobalPosition.DistanceSquaredTo(a2D.GlobalPosition)<player.GlobalPosition.DistanceSquaredTo(b2D.GlobalPosition)) return a;
		return b;
	}
		public  void _on_timer_timeout()
		{
			player=GetTree().GetFirstNodeInGroup("Player") as Player;
			var enem=GetTree().GetNodesInGroup("Enemy");
			if(enem.Count>0){
			Node2D close=new Node2D();
			float max = 9999999999f;
			
			foreach (Node2D item in enem)
			{
			//GD.Print(player.GlobalPosition.DistanceSquaredTo(item.GlobalPosition));
			if(player.GlobalPosition.DistanceSquaredTo(item.GlobalPosition)<max)
			{
				max=player.GlobalPosition.DistanceSquaredTo(item.GlobalPosition);
				close=item;
				//GD.Print(item);
			}
			}
			
			enemy=close as EnemyBasic;
			//enemy.Modulate=Color.Color8(0,0,0);
			position=close.GlobalPosition;
			rotate=player.Position.AngleToPoint(close.GlobalPosition);//+Vector2.Down.Angle();
			//GD.Print("Updated closest "+rotate+" "+position.X);
			}
		}

	
}
