using Godot;
using System;
using System.Net;

public partial class SwordAbility : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		animationPlayer.Play("swing");
		animationPlayer.AnimationFinished += str => QueueFree();
	}



	
}
