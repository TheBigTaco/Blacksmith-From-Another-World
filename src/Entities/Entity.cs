using System;
using Godot;

public class Entity : KinematicBody2D {
    [Export] public int speed = 300;

    public string EntityName { get; set; } = "";
    public Vector2 TargetLocation { get; private set; }
    public bool CanMove { get; private set; }

    public override void _Ready() {

    }

    public override void _Process(float delta) {
        if (CanMove) {
            Vector2 velocity = new Vector2();
            Vector2 targetVec = TargetLocation - GlobalPosition;
            // If Node will pass up target at max speed
            if (targetVec.Length() / delta <= speed) {
                // Move the distance from node to target
                velocity = targetVec;
            } else {
                // Move at constant speed
                velocity = targetVec.Normalized() * speed;
            }

            MoveAndSlide(velocity);
            if (Position == TargetLocation) {
                CanMove = false;
            }
        }
    }

    public void MoveTo(Vector2 target) {
        PathController.GetPath(GlobalPosition, TargetLocation);
        CanMove = true;
        TargetLocation = target;
    }
}
