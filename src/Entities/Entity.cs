using Godot;
using System;

public class Entity : KinematicBody2D
{
    public string EntityName { get; set; } = "";
    public Vector2 TargetLocation { get; set; }
    public bool CanMove { get; set; } = false;
    [Export] public int speed = 9999;

    public override void _Ready()
    {
        
    }


    public override void _Process(float delta)
    {
        Vector2 velocity = new Vector2();
        Vector2 targetVec = TargetLocation - Position;

        if (CanMove)
        {
            // If Node will pass up target at max speed
            if (targetVec.Length() / delta <= speed)
            {
                // Move the distance from node to target
                velocity = targetVec;
            }
            else
            {
                // Move at constant speed
                velocity = targetVec.Normalized() * speed;
            }

            MoveAndSlide(velocity);
            if (Position == TargetLocation)
            {
                CanMove = false;
            }
        }
    }
}
