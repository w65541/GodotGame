using Godot;
using System;

public partial class TentacleTest : BasicLevel
{
	

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		base._Process(delta);
		if (Input.IsActionJustPressed("ui_text_completion_accept"))
		{
			var t=GetChild<Tentacle>(2);
			t.Visible=true;
			t.speed=1000f;
			t.retract=true;
			 t=GetChild<Tentacle>(3);
			t.Visible=true;
			t.speed=1000f;
			t.retract=true;
		}
	}
}
