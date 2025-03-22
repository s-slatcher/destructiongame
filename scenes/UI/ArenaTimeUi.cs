using Godot;
using System;

public partial class ArenaTimeUi : CanvasLayer
{
    [Export]
    public ArenaTimeManager ArenaTimeManager;

    public override void _Process(double delta)
    {
        var timeElapsed = ArenaTimeManager.GetTimeElapsed();
        GetChild(0).GetChild<Label>(0).Text = Math.Floor(timeElapsed).ToString();
    }
}
