using Godot;
using System;

public partial class Player : CharacterBody2D
{


	private HealthComponent healthComponent;
	private Timer damageIntervalTimer;
	private Area2D enemyCollisionArea;

	public float MaxSpeed = 90f;
	public float AccelSmoothing = 15f;

    public int NumberBodiesColliding { get; private set; }

    public override void _Ready() 
	{
		damageIntervalTimer = GetNode<Timer>("DamageIntervalTimer");
		enemyCollisionArea = GetNode<Area2D>("CollisionArea2D");
		healthComponent = GetNode<HealthComponent>("HealthComponent");

		enemyCollisionArea.BodyEntered += OnBodyEntered;
		enemyCollisionArea.BodyExited += OnBodyExited;
		damageIntervalTimer.Timeout += OnCanBeDamaged;
		healthComponent.died += OnDeath;

	}

    private void OnDeath()
    {
		Console.WriteLine("YOU DIED");
    }


    private void OnCanBeDamaged()
    {
        if( NumberBodiesColliding != 0)
		{
			healthComponent.TakeDamage(1);
		}
    }


	private void OnBodyEntered(Node2D body)
    {
		NumberBodiesColliding += 1;
    } 
	private void OnBodyExited(Node2D body)
    {
       NumberBodiesColliding -= 1;
    } 
	
	private Vector2 GetMoveVector()
	{
		Vector2 moveVector = Input.GetVector("move_left", "move_right", "move_up", "move_down");
		return moveVector.Normalized();
	}

	public override void _PhysicsProcess(double delta)
	{
		var targetVelocity = GetMoveVector() * MaxSpeed;
		Velocity = Velocity.Lerp(targetVelocity, (float)(1.0 - Math.Exp(-delta * AccelSmoothing)));
		MoveAndSlide();
	}
}
