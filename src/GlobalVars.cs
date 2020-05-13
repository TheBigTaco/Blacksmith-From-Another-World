using Godot;
using System;

// public enum ClickMode
// {
//     Select,
//     Move,
// }
public class GlobalVars : Resource
{
    
    public static Entity SelectedEntity { get; set; }
    // public static ClickMode CurrentClickMode { get; set; } = ClickMode.Select;

    public static Vector2 MousePos { get; set; }

}
