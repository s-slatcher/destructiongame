using Godot;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

public partial class SwordAbilityController : Node
{
	[Export]
	PackedScene swordAbility;

	[Export]
	public float MaxRange = 125f;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void OnTimerTimeout()
	{
		var player = GetTree().GetNodesInGroup("PlayerGroup")[0] as Player;
		var enemies = GetTree().GetNodesInGroup("EnemyGroup");

		List<Node2D> inRangeList = [];
		foreach (var item in enemies.Cast<Node2D>())
		{
			if ((item.GlobalPosition - player.GlobalPosition).Length() < MaxRange)
			{
				inRangeList.Add(item);
			}
		}

		if( inRangeList.Count > 0)
		{
			var sword = swordAbility.Instantiate() as SwordAbility;
			player.GetParent().AddChild(sword);
			sword.GlobalPosition = inRangeList[0].GlobalPosition;
			GD.Print("swung sword");

		}
		
		GetNode<Timer>("Timer").Start(1.5f);
	}

    

}
