using System;
using Godot;

public class HideClick : Area2D {
    Node2D parentNode;
    public override void _Ready() {
        parentNode = GetParent<Node2D>();
    }

    public void _on_Clickable_input_event(Godot.Object viewport, InputEvent @event, int shapeIdx) {
        if (Input.IsActionJustPressed("click")) {
            parentNode.Visible = false;
            SelectionController.DeselectAll();
            //ProjectSettings.SetSetting("physics/common/enable_object_picking", false);
        }
    }
}
