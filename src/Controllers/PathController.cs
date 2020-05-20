using System;
using Godot;

public class PathController : Node {
    static PathController instance;

    public static void GetPath(Vector2 from, Vector2 to) {
        TraverseChildren(instance.GetTree().Root);

        void TraverseChildren(Node parent) {
            var children = parent.GetChildren();
            foreach (Node child in children) {
                TraverseChildren(child);
                GD.Print(child.Name);
            }
        }
    }

    public override void _Ready() {
        if (instance == null) {
            instance = this;
        } else {
            SetProcess(false);
        }
    }
}
