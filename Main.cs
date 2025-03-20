using Godot;
using System;

public partial class Main : Node2D
{
	[Export]
	public Player player;
	public PackedScene Enemy = GD.Load<PackedScene>("uid://d2o55758viwrp");
	// public PackedScene Player = GD.Load<PackedScene>("uid://ewicnjlkuawb");

	public override void _Ready()
	{
		SpawnEnemy();
		GD.Print("Hello world");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}


	private void SpawnEnemy()
	{
		var enemy1 = Enemy.Instantiate();
		// enemy1.TargetPlayer = player;
		// enemy1.GlobalPosition = Vector2.Zero;
		AddChild(enemy1);
	}
	private void _on_button_pressed()
	{
		GD.Print("Button pressed");
	}
}
