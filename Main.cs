using Godot;
using System;

public partial class Main : Node2D
{
	[Export]
	public Player player;
	public PackedScene Enemy = GD.Load<PackedScene>("uid://d2o55758viwrp");
	

	public override void _Process(double delta)
	{
	}


    private void SpawnEnemy(Vector2 position)
	{
		var enemy1 = Enemy.Instantiate() as BasicEnemy;
		enemy1.GlobalPosition = position;
		AddChild(enemy1);
	}
	private void _on_button_pressed()
	{
		
	}
}
