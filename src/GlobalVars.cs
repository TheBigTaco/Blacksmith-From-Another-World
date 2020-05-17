using Godot;
using System;
using System.Collections.Generic;

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

    public static List<Weapon> RefinableWeapons { get; set;} = new List<Weapon>();
    public static List<Weapon> FinishableWeapons { get; set; } = new List<Weapon>();
    public static List<Weapon> SellableWeapons { get; set; } = new List<Weapon>();

}
