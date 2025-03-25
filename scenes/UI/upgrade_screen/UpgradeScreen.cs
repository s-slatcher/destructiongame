using Godot;
using System;
using System.Collections.Generic;

public partial class UpgradeScreen : CanvasLayer
{
    public Action<AbilityUpgrade> UpgradeSelected;

    [Export] PackedScene upgradeCardScene;
    [Export] HBoxContainer upgradeCardSceneContainer;

    public override void _Ready()
    {
        GetTree().Paused = true;
        
    }

    public void SetAbilityUpgrade(List<AbilityUpgrade> upgrades)
    {
        foreach (var upgrade in upgrades)
        {  
            
            var card = upgradeCardScene.Instantiate() as AbilityUpgradeCard;
            card.SetAbilityUpgrade(upgrade);
            upgradeCardSceneContainer.AddChild(card);
            card.upgradeSelected += () => OnUpgradeSelected(upgrade);
        }
    }

    private void OnUpgradeSelected(AbilityUpgrade upgrade)
    {
        UpgradeSelected?.Invoke(upgrade);
        QueueFree();
    }

    public override void _ExitTree()
    {
        GetTree().Paused = false;
    }
}

