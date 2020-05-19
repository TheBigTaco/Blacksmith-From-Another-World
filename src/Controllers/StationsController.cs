using Godot;
using System;
using System.Collections.Generic;

public class StationsController : Node
{
  static StationsController instance = null;
  public static List<Weapon> RefinableWeapons { get; set; } = new List<Weapon>();
  public static List<Weapon> FinishableWeapons { get; set; } = new List<Weapon>();
  public static List<Weapon> SellableWeapons { get; set; } = new List<Weapon>();


  public override void _Ready() {
    if (instance == null) {
      instance = this;
    }
    SetProcess(false);
  }
}
