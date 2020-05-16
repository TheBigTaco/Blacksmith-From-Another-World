using Godot;
using System;

public class Entity : KinematicBody2D
{

    public Vector2 targetLocation;
    public bool CanMove { get; set; } = false;
    [Export] public int speed = 200;

    public override void _Ready()
    {
        
    }


    public override void _Process(float delta)
    {
        Vector2 velocity = new Vector2();
        Vector2 targetVec = targetLocation - Position;

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
            if (Position == targetLocation)
            {
                CanMove = false;
            }
        }
    }
}
