using Godot;
using System;

public class GlobalVars : Resource
{
    /// <summary>
    /// The current entity selected for inspection/movement
    /// </summary>
    public static Entity SelectedEntity { get; set; }


    /// <summary>
    /// Mouse Position
    /// </summary>
    public static Vector2 MousePos { get; set; }

}
