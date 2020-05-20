using System;
using Godot;

public class EntitySelectable : Entity {
    public void _on_ClickBox_input_event(Godot.Object viewport, InputEvent @event, int shapeIdx) {
        if (Input.IsActionJustPressed("click")) {
            GD.Print("Clicked");
            SelectionController.AddToSelectionQueue(this);
        }
    }
}
