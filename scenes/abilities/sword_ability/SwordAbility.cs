using Godot;
using System;
using System.Net;
using System.Net.Security;
using System.Numerics;
using Vector2 = Godot.Vector2;

public partial class SwordAbility : Node2D
{
	public Node2D TargetEnemy;
	public Vector2 TargetPosition;
	public Vector2 OffsetDirection;
	public const int OFFSET_PIXELS = 16;

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
		if (TargetEnemy == null ) return;
		if (TargetEnemy.IsQueuedForDeletion()) TargetEnemy = null;
        GlobalPosition = TargetEnemy.GlobalPosition + (OFFSET_PIXELS * OffsetDirection );
		LookAt(TargetEnemy.GlobalPosition);
    }







}
