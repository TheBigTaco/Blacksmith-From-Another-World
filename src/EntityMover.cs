using Godot;
using System;

public class EntityMover : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        // if (GlobalVars.CurrentClickMode == ClickMode.Move)
        // {
        if (Input.IsActionJustPressed("click"))
        {
            if (GlobalVars.SelectedEntity != null)
            {
            GlobalVars.SelectedEntity.targetLocation = GlobalVars.MousePos;
            GlobalVars.SelectedEntity.CanMove = true;
            }
            // GlobalVars.CurrentClickMode = ClickMode.Select;
        }
        // }
    }
}
