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
	[Export] PackedScene swordAbility;  // hard code UID?
	
	public double damage = 5;

	[Export]public float MaxRange = 125f;
	
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
		foreach (var item in enemies.Cast<Node2D>())  // get rid of 'in range' filter, just sort and check 0 idx
		{
			if ((item.GlobalPosition - player.GlobalPosition).Length() < MaxRange)
			{
				inRangeList.Add(item);
			}
		}
		inRangeList = [.. inRangeList.OrderBy(el => (el.GlobalPosition - player.GlobalPosition).Length())];
		if (inRangeList.Count < 1) return;
		
		// set sword target and base damage, add to scene
		var sword = swordAbility.Instantiate() as SwordAbility;
		player.GetParent().AddChild(sword);

		// AddChild must be run first for components to connect -- 
		// find way to avoid this? an interface with .getHurtbox? 
		sword.HitboxComponent.damage = damage;
		sword.TargetEnemy = inRangeList[0];		
		
		
	}


}
