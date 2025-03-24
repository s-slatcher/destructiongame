using Godot;
using System;
using System.Diagnostics;

public partial class ExperienceVialDropComponent : Node
{
    
    [Export] private PackedScene _experienceVial; // hard code UID to the packed scene?
    [Export] private HealthComponent _healthComponent;

    [Export] public double DropChance = 0.5;

    public override void _Ready()
    {
        Debug.Assert(_experienceVial != null);
        _healthComponent.died += OnDied;
    }

    private void OnDied()
    {
        var spawnPosition = GetOwner<Node2D>().GlobalPosition;
        var vileInstance = _experienceVial.Instantiate() as ExperienceVial;
        vileInstance.GlobalPosition = spawnPosition;
        
        Owner.GetParent().CallDeferred("add_child", vileInstance);

    }
}
