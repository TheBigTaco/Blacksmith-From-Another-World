using Godot;
using System;

public class StationClick : Area2D
{

    Station parentNode;

    public override void _Ready()
    {
        parentNode = GetParent<Station>();
    }
    public void _on_StationClick_input_event(Godot.Object viewport, InputEvent @event, int shapeIdx)
    {
        if (Input.IsActionJustPressed("click"))
        {
            parentNode.InProgress = true;
        }
    }
}
