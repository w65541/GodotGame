using Godot;
using System;

public partial class wall : StaticBody2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}
	float Speed=50f;
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
		Vector2 velocity = new Vector2(1,0);
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
			//velocity.Y = direction.Y * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(1, 0, Speed);
			//velocity.Y = Mathf.MoveToward(0, 0, Speed);
		}

		
		MoveAndCollide(velocity);
	}
}
