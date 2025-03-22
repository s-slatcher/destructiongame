using Godot;
using System;

public partial class GameEvents : Node
{
    public static GameEvents Instance {get; private set;}
    
    
    // XP pickup events
    public Action<double> ExperienceGet;

    
    
    
    public override void _Ready()
    {
        Instance = this;
    }


}
