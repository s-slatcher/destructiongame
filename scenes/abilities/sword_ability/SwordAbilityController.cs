using Godot;
using Godot.Collections;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using Vector2 = Godot.Vector2;

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
		GetNode<Timer>("Timer").Start(1.5f);
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
		
		inRangeList = [.. inRangeList.OrderBy(el => (el.GlobalPosition - player.GlobalPosition).Length())];

		if (inRangeList.Count < 1) return;
		
		var sword = swordAbility.Instantiate() as SwordAbility;
		var enemyPosition = inRangeList[0].GlobalPosition;

		sword.TargetEnemy = inRangeList[0];		
		player.GetParent().AddChild(sword);
		
	}


}
