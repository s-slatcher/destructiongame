using Godot;
using System;
using System.Diagnostics;

public partial class ExperienceBar : CanvasLayer
{
    [Export] private ExperienceManager _experienceManager;
    private ProgressBar _progressBar;

    public override void _Ready()
    {
        _experienceManager.ExperienceUpdated += OnExperienceUpdated; 
        _progressBar = GetNode<ProgressBar>("./MarginContainer/ProgressBar");
        
    }

    private void OnExperienceUpdated(double currentExperience, double targetExperience)
    {
        
        var progressRatio = currentExperience == 0 ? 0 : currentExperience / targetExperience;
        
        _progressBar.Value = progressRatio;
        
    }

}

