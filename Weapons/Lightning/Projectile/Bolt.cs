using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class Bolt : ProjectilePlayer
{
	public List<EnemyBasic> targets=new List<EnemyBasic>();
	public Vector2 targetPos;
	public override void _Ready()
	{
		base._Ready();
		GetParent<LightingFollow>().Start();
	}
	public override void _Process(double delta)
	{
		base._Process(delta);
	}
	public void nextTarget()
	{
		var next= targets.OrderBy(x=>x.GlobalPosition.DistanceSquaredTo(this.GlobalPosition)).First();
		targetPos=next.GlobalPosition;
		Rotation=next.GlobalPosition.AngleToPoint(this.GlobalPosition);
	}
	override public void _on_area_2d_body_entered(Node2D bullet)
	{
		GD.Print(bullet.GetType());
		if(bullet.GetType().IsAssignableTo(new wall().GetType())){
			GD.Print("wall");
			stop=0;
			Despawn();
			}
		if(stats.penetrationInf==false){
		
		
		if(bullet.GetType().IsAssignableTo(new EnemyBasic().GetType()))
		{
			penetrable--;
			//GD.Print(penetrable+"/"+stats.penetration);
			
			if(penetrable<0) nextTarget();
		}else{
			if(bullet.GetType().IsAssignableTo(new wall().GetType())){
				Despawn();
			}
		}
		}
	}
/*
	public void _on_next_target_body_entered(Node2D node)
	{
		if(node.GetType().IsAssignableTo(new EnemyBasic().GetType()))
		{
			targets.Add((EnemyBasic)node);
		}
	}

	public void _on_next_target_body_exited(Node2D node)
	{
		if(node.GetType().IsAssignableTo(new EnemyBasic().GetType()))
		{
		targets.Remove((EnemyBasic)node);
		}
	}
*/


}
