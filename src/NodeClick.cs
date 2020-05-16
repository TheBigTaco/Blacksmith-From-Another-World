using Godot;
using System;

public class NodeClick : Area2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    Entity parentNode;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        parentNode = GetParent<Entity>();
        // Connect("input_event", this, nameof(_on_Player_input_event));
    }
    public void _on_Clickable_input_event(Godot.Object viewport, InputEvent @event, int shapeIdx)
    {
       if(Input.IsActionJustPressed("click"))// && GlobalVars.CurrentClickMode == ClickMode.Select)
       {
           GlobalVars.SelectedEntity = parentNode;
        //    GlobalVars.CurrentClickMode = ClickMode.Move;
       }
    }


//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
