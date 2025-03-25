using Godot;
using System;
using System.Net;
using System.Net.Security;
using System.Numerics;
using Vector2 = Godot.Vector2;

public partial class SwordAbility : Node2D
{
	public HitboxComponent HitboxComponent;
 	
	public Node2D TargetEnemy;
	public Vector2 TargetPosition = new(0, 0);
	public Vector2 OffsetDirection;
	private double maxOffset = 25;
	private double currentOffset = 25;
	private double maxSpeed = 64;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Component attachment
		HitboxComponent = GetNode<HitboxComponent>("HitboxComponent");

		OffsetDirection = new Vector2( GD.RandRange(-1,1), GD.RandRange(-1,1) ).Normalized();
		var animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		animationPlayer.Play("swing");
		animationPlayer.AnimationFinished += str => QueueFree();
		
	}

    public override void _PhysicsProcess(double delta)
    {
		if (IsInstanceValid(TargetEnemy)) TargetPosition = TargetEnemy.GlobalPosition;
		
		var offsetRatio = maxOffset / currentOffset;
		var speed = maxSpeed * Math.Pow( offsetRatio, 2 );
		currentOffset = Math.Clamp(currentOffset - speed * delta, 0 ,99);
		
        GlobalPosition = TargetPosition + ((float)currentOffset * OffsetDirection );
		LookAt(TargetPosition);
    }







}
