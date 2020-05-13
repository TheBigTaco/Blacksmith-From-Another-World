using Godot;
using System;

public class Entity : KinematicBody2D
{

    public Vector2 targetLocation;
    float speedConst = .7F;
    public bool CanMove { get; set; } = false;

    public override void _Ready()
    {
        
    }


    public override void _Process(float delta)
    {
        Vector2 velocity = new Vector2();
        if (CanMove)
        {
            velocity = (targetLocation - Position) * speedConst;
            MoveAndSlide(velocity);
            if (Position == targetLocation)
            {
                CanMove = false;
            }
        }
    }
}
