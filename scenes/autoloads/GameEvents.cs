using Godot;
using System;
using System.Collections;
using System.Collections.Generic;

public partial class GameEvents : Node
{
    public static GameEvents Instance {get; private set;}
    
    
    // XP pickup events
    public Action<double> ExperienceGet;


    // Upgrade management events
    public event EventHandler<UpgradeAddedEventArgs> UpgradeAdded;
    
    
    
    public override void _Ready()
    {
        Instance = this;
    }

    internal void InvokeUpgradeAdded(AbilityUpgrade upgradeSelected, Dictionary<string, AbilityUpgrade> currentUpgrades)
    {
        UpgradeAdded?.Invoke(this, new UpgradeAddedEventArgs{ 
            UpgradeSelected = upgradeSelected, CurrentUpgrades = currentUpgrades
        });
    }

}

public class UpgradeAddedEventArgs : EventArgs
{
    public AbilityUpgrade UpgradeSelected;
    public Dictionary<string, AbilityUpgrade> CurrentUpgrades;

}
