using Godot;
using System;
using System.Collections.Generic;

public partial class UpgradeManager : Node
{

    [Export] public PackedScene AbilityUpgradeScene;
    [Export] public Godot.Collections.Array<AbilityUpgrade> UpgradePool;
    [Export] private ExperienceManager experienceManager;
    

    public Dictionary<string, AbilityUpgrade> CurrentUpgrades = [];

    public override void _Ready()
    {
        experienceManager.LeveledUp += OnLevelUp;
        
    }

    private void OnLevelUp(int obj)
    {
        GD.Print("leveled up");
        AbilityUpgrade chosenUpgrade = UpgradePool.PickRandom();
       
       var upgradeSceneInstance = AbilityUpgradeScene.Instantiate() as UpgradeScreen;
       AddChild(upgradeSceneInstance);
       List<AbilityUpgrade> abilityList = [chosenUpgrade];
       upgradeSceneInstance.SetAbilityUpgrade( abilityList );
       upgradeSceneInstance.UpgradeSelected += OnUpgradeSelected;

        
        
    }

    private void OnUpgradeSelected(AbilityUpgrade upgrade)
    {
        ApplyUpgrade(upgrade);
    }


    private void ApplyUpgrade(AbilityUpgrade upgrade)
    {
        bool hasUpgrade = CurrentUpgrades.ContainsKey(upgrade.Id);
        if (!hasUpgrade)
        {
            CurrentUpgrades.Add(upgrade.Id, upgrade);
        }
        else
        {
            CurrentUpgrades[upgrade.Id].EffectMultiplier += 1;
        }

        GameEvents.Instance.InvokeUpgradeAdded(upgrade, CurrentUpgrades);

    }
}
