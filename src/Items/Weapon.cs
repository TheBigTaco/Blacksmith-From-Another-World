using System;
using Godot;

public enum WeaponStage {
    Null,

    Forge,

    Refine,
    // Enchanted,
    Finish,
    Sell,

    Owned,
    // Broken,
}

public class Weapon : Resource {
    public string Name { get; set; }
    public int Power { get; set; } = 0;
    public WeaponStage Stage { get; set; } = WeaponStage.Null;

    public int Price { get; set; } = 0;

}
