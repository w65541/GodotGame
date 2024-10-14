using Godot;
using System;

public partial class Laser : Node2D
{
	public Player player;
	RayCast2D cast;
	Line2D line;
	
float r=100.0f;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		player=(Player) GetParent();
		line=GetChild<Line2D>(0);
		cast=GetChild<RayCast2D>(1);
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var pPosition=(Vector2)GetParent().Get(Node2D.PropertyName.Position);
		
		var dir=pPosition.DirectionTo(GetGlobalMousePosition());
		//LookAt(GetGlobalMousePosition());
		var ang=(pPosition.AngleToPoint(GetGlobalMousePosition()));
		Position=new Vector2{
			Y=((float)Math.Sin(ang))*r,
			X=((float)Math.Cos(ang))*r
		};
		Rotation=ang;
		line=GetChild<Line2D>(0);
		cast=GetChild<RayCast2D>(1);
		//line.Rotation=-Rotation;
		line.GlobalPosition=GlobalPosition;
		line.SetPointPosition(0,GetParent<Node2D>().GlobalPosition) ;
		if(cast.IsColliding())
		{
			var enem=cast.GetCollider() as EnemyBasic;
			//enem.hp-=1;
			var dist =player.GlobalPosition.DistanceTo(cast.GetCollisionPoint());
			var newPosition=new Vector2{
			Y=((float)Math.Sin(ang))*dist,
			X=((float)Math.Cos(ang))*dist
										};
			line.SetPointPosition(0,Vector2.Zero);//line.SetPointPosition(0,cast.GlobalPosition) ;
			var vec=new Vector2(	Math.Abs(	GlobalPosition.DistanceTo(	cast.GetCollisionPoint())),0);
			line.SetPointPosition(1,vec);//cast.GetCollisionPoint()) ;
			//line.SetPointPosition(1,newPosition.Rotated(Vector2.Down.Angle())+Vector2.Right) ;
			GD.Print(cast.GetCollisionPoint());
			GD.Print("Line2: "+line.Points[1].X+" "+line.Points[1].Y+"Ray2Col: "+cast.GetCollisionPoint());
		}else{
			line.SetPointPosition(0,Vector2.Zero);//cast.GlobalPosition) ;
			line.SetPointPosition(1,cast.TargetPosition);
			GD.Print("Line2: "+line.Points[1].X+" "+line.Points[1].Y+"Ray2: "+cast.TargetPosition);
		}
		GD.Print("Line1: "+line.Points[0].X+" "+line.Points[0].Y+"Ray1: "+cast.GlobalPosition);
	}
}
