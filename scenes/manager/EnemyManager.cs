using Godot;
using System;

public partial class EnemyManager : Node
{

	[Export]
	public PackedScene BasicEnemyScene;
	public override void _Ready()
	{
	
		GetNode<Timer>("Timer").Timeout += OnTimeout;
	}

    private void OnTimeout()
    {
		GetNode<Timer>("Timer").Start(1.0f);

		var player = (Player)GetTree().GetFirstNodeInGroup("PlayerGroup");
		if (player == null) return;

		var screenWidth = GetViewport().GetWindow().Size;
		Vector2 spawnDir = Vector2.Right.Rotated((float)GD.RandRange(0, Math.Tau));
		Vector2 spawnPos = player.GlobalPosition + spawnDir * (screenWidth.X/2);

		var enemyInstance = BasicEnemyScene.Instantiate() as BasicEnemy;
		enemyInstance.Position = spawnPos;
		GetParent().AddChild(enemyInstance);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}
}
