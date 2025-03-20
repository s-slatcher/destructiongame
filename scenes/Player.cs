using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[Export]
	public float MoveSpeed = 200f;
	public override void _Ready() 
	{
		GD.Print(MoveSpeed);
	}
	public override void _PhysicsProcess(double delta)
	{
		Velocity = GetMoveVector() * MoveSpeed;
		MoveAndSlide();
	}

	private static Vector2 GetMoveVector()
	{
		Vector2 moveVector = Input.GetVector("move_left", "move_right", "move_up", "move_down");
		return moveVector.Normalized();
	}
}
