using Godot;
using System;

public partial class AbilityUpgrade : Resource
{
    [Export] public String Id;
    [Export] public String Name;
    [Export(PropertyHint.MultilineText)] public String Description;
    [Export] public bool Stackable;

    private int effectMultiplier = 1;

    public int EffectMultiplier{
        get {
            return effectMultiplier;
        }
        set {
            if (Stackable) 
            {
                effectMultiplier = value;
            }
            else
            {
                Console.WriteLine(Name + "can't be leveled up!");
            }
        }
    }
        
}
