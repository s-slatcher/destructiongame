using Godot;
using System;
using System.Xml.XPath;

public partial class ExperienceManager : Node
{

    public Action< double, double> ExperienceUpdated;

    public double CurrentExperience = 0;
    public double CurrentLevel = 1;
    public double TargetExperience = 5;

    public double ExperienceTargetGrowth = 1.5;

    public override void _Ready()
    {
        GameEvents.Instance.ExperienceGet += IncrementExperience;

    }
    public void IncrementExperience(double num = 0)
    {
        CurrentExperience = Math.Min( CurrentExperience + num, TargetExperience);
        
        if (CurrentExperience == TargetExperience)
        {
            TargetExperience *= ExperienceTargetGrowth;
            CurrentLevel += 1;
            CurrentExperience = 0;
        }
        ExperienceUpdated?.Invoke(CurrentExperience, TargetExperience);

    }


}
