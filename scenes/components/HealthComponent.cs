using Godot;
using Godot.NativeInterop;
using System;
using System.Runtime.Serialization;

public partial class HealthComponent : Node
{

    // events
    public Action died;


    [Export] public double MaxHealth = 10;
    public double CurrentHealth;


    public override void _Ready()
    {
        CurrentHealth = MaxHealth;
    }

    // ---

    public void TakeDamage(double damage)
    {
        CurrentHealth = Math.Max(CurrentHealth - damage, 0);
        if (CurrentHealth == 0) died?.Invoke();
    }


}
