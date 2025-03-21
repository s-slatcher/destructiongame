using Godot;
using System;
using System.ComponentModel;

public partial class CSharpTesting : Node2D
{
	public int TotalGuys = 0;
	public int AddAmount = 1;
	public int PassiveAdditionAmount = 0;

	private double timeSincePassiveCount = 0;
	private double passiveCountDelay = 1;
	private int passivePurchaseCost = 10;

	PackedScene FallingIcon = GD.Load<PackedScene>("res://iconfalling.tscn");

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		timeSincePassiveCount += delta;
		if(timeSincePassiveCount >= passiveCountDelay)
		{
			timeSincePassiveCount = 0;
			AddGuys(PassiveAdditionAmount);
		}
	}
	public void AddGuys(int num)
	{
		RichTextLabel label = GetNode<RichTextLabel>("guys_counter");
		TotalGuys += num;
		label.Text = "Guys Total: " + TotalGuys.ToString();
		for (int i = 0; i < num; i++)
		{
			PlayAnimation();	
		}
		
	}
	public void PlayAnimation()
	{
		IconFalling icon = (IconFalling)FallingIcon.Instantiate();
		icon.Position = new(800, 300);
		AddChild(icon);
		
	}
	public void _on_add_button_pressed(){
		AddGuys(AddAmount);
	}

	public void _on_purchase_passive_pressed()
	{
		if (TotalGuys >= passivePurchaseCost)
		{
			AddGuys(-10);
			PassiveAdditionAmount += 1;
		}
		else
		{
			RichTextLabel ErrorLabel = GetNode<RichTextLabel>("error_label");
			ErrorLabel.Text = "Not Enough Guys!";
			GetTree().CreateTimer(2.0f).Timeout += () => ErrorLabel.Text = " ";
		}
	}
}
