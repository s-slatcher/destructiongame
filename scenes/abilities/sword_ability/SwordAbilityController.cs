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
	
	public double Damage = 10;
	
	public double BaseWaitTime = 1.5; 
	private double currentWaitTime; 
	
	public float MaxRange = 125f;
	
	public override void _Ready()
	{
		// subscribe to ability events
		GameEvents.Instance.UpgradeAdded += OnUpgradeAdded;

		// set default fields
		currentWaitTime = BaseWaitTime;


		
	}




	// react to ability upgrades relevant to sword	 
    private void OnUpgradeAdded(object sender, UpgradeAddedEventArgs e)
    {
		if (e.UpgradeSelected.Id != "sword_rate") return;

		var abilityLevel = e.UpgradeSelected.EffectMultiplier;
		// sword rate level = +10% speed up (this function has to know those specifics, for now)
		currentWaitTime = BaseWaitTime / ( 1 + (abilityLevel * 0.5));

    }


    public void OnTimerTimeout()
	{
		GetNode<Timer>("Timer").Start(currentWaitTime);
		
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
		sword.HitboxComponent.Damage = Damage;
		sword.TargetEnemy = inRangeList[0];		
		
		
	}


}
