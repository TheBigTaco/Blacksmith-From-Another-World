using System;
using Godot;

public class Blacksmith : Entity {

    public int level { get; set; } = 0;

    public override void _Ready() {
        level = 1;
    }

    public override void _Process(float delta) {

    }
}
