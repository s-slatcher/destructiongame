using Godot;
using System;

public partial class BasicEnemy : CharacterBody2D
{
	private Player target;

    public float MaxSpeed {get; set;} = 60f;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
		var targetNodes = GetTree().GetNodesInGroup("PlayerGroup");
		if (targetNodes.Count > 0) target = targetNodes[0] as Player;

		GetNode<Area2D>("Area2D").AreaEntered += OnCollisionDetected;
	}

    private void OnCollisionDetected(Area2D area)
    {
		QueueFree();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
		if (target == null) return;

		var targetDir = (target.GlobalPosition - GlobalPosition).Normalized();
		Velocity = MaxSpeed * targetDir;
		MoveAndSlide();
	}
}
