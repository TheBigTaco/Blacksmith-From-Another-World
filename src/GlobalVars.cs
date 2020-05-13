using Godot;
using System;

// public enum ClickMode
// {
//     Select,
//     Move,
// }
public class GlobalVars : Resource
{
    /// <summary>
    /// The current entity selected for inspection/movement
    /// </summary>
    public static Entity SelectedEntity { get; set; }
    // public static ClickMode CurrentClickMode { get; set; } = ClickMode.Select;

    /// <summary>
    /// Mouse Position
    /// </summary>
    public static Vector2 MousePos { get; set; }

}
