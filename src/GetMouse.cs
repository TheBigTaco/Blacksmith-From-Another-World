using Godot;
using System;

public class GetMouse : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Process(float delta)
    {
        GlobalVars.MousePos = GetViewport().GetMousePosition();
        GD.Print($"x: {GlobalVars.MousePos.x}, y: {GlobalVars.MousePos.y}");
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
