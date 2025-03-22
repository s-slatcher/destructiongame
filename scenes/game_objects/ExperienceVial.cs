using Godot;
using System;

public partial class ExperienceVial : Node2D
{
    public override void _Ready()
    {
        // connect signals
       GetNode<Area2D>("Area2D").AreaEntered += OnAreaEntered;

    }

    private void OnAreaEntered(Area2D area)
    {
        GameEvents.Instance.ExperienceGet?.Invoke( 1.0 );
        QueueFree();
    }


}
