using Godot;
using System;

public partial class Node2d : Node2D
{
    public override void _Ready()
    {
        GetChild(0);
    }
    
}
