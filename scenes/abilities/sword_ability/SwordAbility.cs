using Godot;
using System;
using System.Net;
using System.Net.Security;
using System.Numerics;
using Vector2 = Godot.Vector2;

public partial class SwordAbility : Node2D
{
	public Node2D TargetEnemy;
	public Vector2 TargetPosition = new Vector2(0, 0);
	public Vector2 OffsetDirection;
	private double MaxOffset = 25;
	private double CurrentOffset = 25;
	private double maxSpeed = 64;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		OffsetDirection = new Vector2( GD.RandRange(-1,1), GD.RandRange(-1,1) ).Normalized();
		var animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		animationPlayer.Play("swing");
		animationPlayer.AnimationFinished += str => QueueFree();
		
	}

    public override void _PhysicsProcess(double delta)
    {
		if (IsInstanceValid(TargetEnemy)) TargetPosition = TargetEnemy.GlobalPosition;
		
		var offsetRatio = MaxOffset / CurrentOffset;
		var speed = maxSpeed * Math.Pow( offsetRatio, 2 );
		CurrentOffset = Math.Clamp(CurrentOffset - speed * delta, 0 ,99);
		

		
        GlobalPosition = TargetPosition + ((float)CurrentOffset * OffsetDirection );
		LookAt(TargetPosition);
    }







}
