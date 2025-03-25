using Godot;
using System;

public partial class AbilityUpgradeCard : PanelContainer
{

    public Action upgradeSelected;

    [Export] Label nameLabel;
    [Export] Label descriptionLabel;

    public override void _Ready()
    {
        GuiInput += OnGuiInput;
    }

    private void OnGuiInput(InputEvent @event)
    {
        if (@event.IsActionPressed("left_click"))
        {
            upgradeSelected?.Invoke();
        }
    }


    public void SetAbilityUpgrade(AbilityUpgrade upgrade)
    {
        nameLabel.Text = upgrade.Name;
        descriptionLabel.Text = upgrade.Description;
    }
}
