using Godot;
using System;

public partial class ArenaTimeUi : CanvasLayer
{
    [Export]
    public ArenaTimeManager ArenaTimeManager;

    public override void _Process(double delta)
    {
        var timeElapsed = ArenaTimeManager.GetTimeElapsed();
        var timeElapsedString = Math.Floor(timeElapsed).ToString();
        GetChild(0).GetChild<Label>(0).Text = "Time Left: " + timeElapsedString;
    }
}
