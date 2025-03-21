using Godot;
using System;
using System.Numerics;
using Vector2 = Godot.Vector2;

public partial class GameCamera : Camera2D
{
	[Export]
	public Player Player;
	public Vector2 TargetPos;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		MakeCurrent();
		GlobalPosition = Player.GlobalPosition;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		TargetPos = Player.GlobalPosition;
		GlobalPosition = GlobalPosition.Lerp(TargetPos, (float)(1.0 - Math.Exp(-delta * 20)) );
	}

	
}
