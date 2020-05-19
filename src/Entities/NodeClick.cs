using Godot;
using System;

public class NodeClick : Area2D
{

    Entity parentNode;

    public override void _Ready()
    {
        parentNode = GetParent<Entity>();
    }
    public void _on_Clickable_input_event(Godot.Object viewport, InputEvent @event, int shapeIdx)
    {
       if(Input.IsActionJustPressed("click"))
       {
           GlobalVars.SelectedEntity = parentNode;
       }
    }
}
