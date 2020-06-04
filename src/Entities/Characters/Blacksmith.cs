using System;
using Godot;

public class Blacksmith : Entity {

    public int Level { get; set; } = 0;

    public override void _Ready() {
        Level = 1;
    }

    public override void _Process(float delta) {

    }
}
