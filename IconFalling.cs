using Godot;
using System;
using System.Numerics;
using Vector2 = Godot.Vector2;

public partial class IconFalling : Node2D
{
	public Sprite2D icon;
	Tween tween;
	
	Vector2 Velocity = new Vector2(GD.RandRange(-15, 15), GD.RandRange(-20, -10));
	double RotationSpeed = GD.RandRange(0 , Math.PI);
	double Gravity = 50;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		RotationSpeed *= Math.Sign(Velocity.X);

		icon = GetNode<Sprite2D>("Icon");
		GD.Print(icon.Scale);
		icon.Scale = new Vector2(0f, 0f);
		tween = CreateTween();
		tween.SetTrans(Tween.TransitionType.Elastic);
		tween.TweenProperty(icon, "scale", new Vector2(1.0f, 1.0f), 0.25);
		
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		icon.Rotation += (float)(delta * RotationSpeed);
		icon.Position += Velocity;
		Velocity.Y += (float)(Gravity * delta);

		if(icon.Position.Y > 1500)
		{
			QueueFree();
		}
	}
}
