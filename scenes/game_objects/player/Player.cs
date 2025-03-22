using Godot;
using System;

public partial class Player : CharacterBody2D
{
	
	public float MaxSpeed = 90f;
	public float AccelSmoothing = 15f;
	public override void _Ready() 
	{
	}
	public override void _PhysicsProcess(double delta)
	{
		var targetVelocity = GetMoveVector() * MaxSpeed;
		Velocity = Velocity.Lerp(targetVelocity, (float)(1.0 - Math.Exp(-delta * AccelSmoothing)));
		MoveAndSlide();
	}

	private static Vector2 GetMoveVector()
	{
		Vector2 moveVector = Input.GetVector("move_left", "move_right", "move_up", "move_down");
		return moveVector.Normalized();
	}
}
