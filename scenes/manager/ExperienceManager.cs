using Godot;
using System;

public partial class ExperienceManager : Node
{
    public double CurrentExperience = 0;

    public override void _Ready()
    {
        GameEvents.Instance.ExperienceGet += IncrementExperience;
    }
    public void IncrementExperience(double num = 0)
    {
        CurrentExperience += num;
    }


}
