using Godot;
using System;

public class EntityMover : Node
{
    public override void _Ready()
    {
        
    }

    public override void _Process(float delta)
    {

    }

    public override void _Input(InputEvent e)
    {
        var mouseEvent = e as InputEventMouseButton;
        if (Input.IsActionJustPressed("right_click") && SelectionController.SelectedEntity != null && mouseEvent != null)
        {
            SelectionController.SelectedEntity.TargetLocation = mouseEvent.GlobalPosition;
            SelectionController.SelectedEntity.CanMove = true;
        }
    }
}
